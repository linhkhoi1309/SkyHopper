using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
public class BoidZone : MonoBehaviour
{
    [SerializeField] BoidZoneSO boidZoneSO;

    List<Boid> boids = new List<Boid>();
    TransformAccessArray transformAccessArray;
    NativeArray<BoidData> boidData;

    struct BoidData
    {
        public float3 position;
        public float3 velocity;
    };

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(boidZoneSO.minBounds.x, boidZoneSO.minBounds.y, 0), new Vector3(boidZoneSO.maxBounds.x, boidZoneSO.minBounds.y, 0));
        Gizmos.DrawLine(new Vector3(boidZoneSO.maxBounds.x, boidZoneSO.minBounds.y, 0), new Vector3(boidZoneSO.maxBounds.x, boidZoneSO.maxBounds.y, 0));
        Gizmos.DrawLine(new Vector3(boidZoneSO.maxBounds.x, boidZoneSO.maxBounds.y, 0), new Vector3(boidZoneSO.minBounds.x, boidZoneSO.maxBounds.y, 0));
        Gizmos.DrawLine(new Vector3(boidZoneSO.minBounds.x, boidZoneSO.maxBounds.y, 0), new Vector3(boidZoneSO.minBounds.x, boidZoneSO.minBounds.y, 0));
    }

    void Start()
    {
        boids = new List<Boid>(boidZoneSO.numOfBoids);
        transformAccessArray = new TransformAccessArray(boidZoneSO.numOfBoids);
        boidData = new NativeArray<BoidData>(boidZoneSO.numOfBoids, Allocator.Persistent);

        for (int i = 0; i < boidZoneSO.numOfBoids; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(boidZoneSO.minBounds.x, boidZoneSO.maxBounds.x),
                Random.Range(boidZoneSO.minBounds.y, boidZoneSO.maxBounds.y),
                0f
            );

            GameObject boidObj = Instantiate(boidZoneSO.boidPrefab, randomPosition, Quaternion.identity, transform);
            Boid boid = boidObj.GetComponent<Boid>();

            boids.Add(boid);
            transformAccessArray.Add(boid.transform);

            boidData[i] = new BoidData
            {
                position = boid.transform.position,
                velocity = (Vector3)boid.velocity
            };
        }
    }

    [BurstCompile]
    struct BoidZoneJob : IJobParallelForTransform
    {
        [ReadOnly] public NativeArray<BoidData> boidData;
        public NativeArray<BoidData> updatedBoidData;
        public float deltaTime;
        public float3 minBounds;
        public float3 maxBounds;
        public float visualRange;
        public float protectedRange;
        public float centeringFactor;
        public float matchingFactor;
        public float avoidFactor;
        public float turnFactor;
        public float maxSpeed;
        public float minSpeed;

        public void Execute(int index, TransformAccess transform)
        {
            float3 position = boidData[index].position;
            float3 velocity = boidData[index].velocity;

            float3 avgPos = float3.zero;
            float3 avgVel = float3.zero;
            float3 closeDist = float3.zero;
            int neighboringBoids = 0;

            for (int i = 0; i < boidData.Length; i++)
            {
                if (i == index) continue;

                float3 diff = boidData[i].position - position;
                float squaredDistance = math.lengthsq(diff);

                if (squaredDistance < visualRange * visualRange)
                {
                    if (squaredDistance < protectedRange * protectedRange)
                    {
                        closeDist -= diff;
                    }
                    else
                    {
                        avgPos += boidData[i].position;
                        avgVel += boidData[i].velocity;
                        neighboringBoids++;
                    }
                }
            }

            if (neighboringBoids > 0)
            {
                avgPos /= neighboringBoids;
                avgVel /= neighboringBoids;

                // Cohesion
                velocity += (avgPos - position) * centeringFactor;

                // Alignment
                velocity += (avgVel - velocity) * matchingFactor;
            }

            // Separation
            velocity += closeDist * avoidFactor;

            // Boundaries
            if (position.x < minBounds.x) velocity.x += turnFactor;
            if (position.x > maxBounds.x) velocity.x -= turnFactor;
            if (position.y < minBounds.y) velocity.y += turnFactor;
            if (position.y > maxBounds.y) velocity.y -= turnFactor;

            // Speed limit
            float speed = math.length(velocity);
            if (speed > maxSpeed) velocity = math.normalize(velocity) * maxSpeed;
            if (speed < minSpeed) velocity = math.normalize(velocity) * minSpeed;

            // Update position
            position += velocity * deltaTime;

            // Write back data
            updatedBoidData[index] = new BoidData
            {
                position = position,
                velocity = velocity
            };

            transform.position = position;

            if (math.lengthsq(velocity) > 0.01f)
            {
                float angle = math.degrees(math.atan2(velocity.y, velocity.x)) - 90f;
                transform.rotation = quaternion.Euler(0, 0, angle * math.PI / 180f);
            }
        }
    }

    void FixedUpdate()
    {
        NativeArray<BoidData> updatedData = new NativeArray<BoidData>(boidZoneSO.numOfBoids, Allocator.TempJob);

        BoidZoneJob job = new BoidZoneJob
        {
            boidData = boidData,
            updatedBoidData = updatedData,
            deltaTime = Time.fixedDeltaTime,
            minBounds = (Vector3)boidZoneSO.minBounds,
            maxBounds = (Vector3)boidZoneSO.maxBounds,
            visualRange = boidZoneSO.visualRange,
            protectedRange = boidZoneSO.protectedRange,
            centeringFactor = boidZoneSO.centeringFactor,
            matchingFactor = boidZoneSO.matchingFactor,
            avoidFactor = boidZoneSO.avoidFactor,
            turnFactor = boidZoneSO.turnFactor,
            maxSpeed = boidZoneSO.maxSpeed,
            minSpeed = boidZoneSO.minSpeed
        };

        JobHandle handle = job.Schedule(transformAccessArray);
        handle.Complete();

        for (int i = 0; i < boidZoneSO.numOfBoids; i++)
        {
            boidData[i] = updatedData[i];
        }

        updatedData.Dispose();
    }

    void OnDestroy()
    {
        if (boidData.IsCreated)
            boidData.Dispose();

        if (transformAccessArray.isCreated)
            transformAccessArray.Dispose();
    }
}
