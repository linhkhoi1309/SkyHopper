using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BoidZone : MonoBehaviour
{
    [SerializeField] BoidZoneSO boidZoneSO;
    List<Boid> boids = new List<Boid>();

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
        for (int i = 0; i < boidZoneSO.numOfBoids; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(boidZoneSO.minBounds.x, boidZoneSO.maxBounds.x), Random.Range(boidZoneSO.minBounds.y, boidZoneSO.maxBounds.y), 0f);
            GameObject boidObj = Instantiate(boidZoneSO.boidPrefab, randomPosition, boidZoneSO.boidPrefab.transform.rotation, transform);
            boids.Add(boidObj.GetComponent<Boid>());
        }
    }
    private void FixedUpdate()
    {
        foreach (Boid boid in boids)
        {
            Vector2 noise = new Vector2(
                Random.Range(-0.1f, 0.1f),
                Random.Range(-0.1f, 0.1f)
            );
            boid.velocity += noise;
            Vector2 avg_pos = Vector2.zero;
            Vector2 avg_vel = Vector2.zero;
            Vector2 close_d = Vector2.zero;
            int neighboring_boids = 0;
            foreach (Boid neighbor in boids)
            {
                if (neighbor == boid) continue;
                Vector2 d = neighbor.transform.position - boid.transform.position;
                if (Mathf.Abs(d.x) < boidZoneSO.visualRange && Mathf.Abs(d.y) < boidZoneSO.visualRange)
                {
                    float squared_distance = d.magnitude;
                    if (squared_distance < boidZoneSO.protectedRange)
                    {
                        close_d -= new Vector2(d.x, d.y);
                    }
                    else if (squared_distance < boidZoneSO.visualRange)
                    {
                        avg_pos += new Vector2(neighbor.transform.position.x, neighbor.transform.position.y);
                        avg_vel += new Vector2(neighbor.velocity.x, neighbor.velocity.y);
                        neighboring_boids += 1;
                    }
                }
            }

            if (neighboring_boids > 0)
            {
                avg_pos /= neighboring_boids;
                avg_vel /= neighboring_boids;
                boid.velocity += (avg_pos - (Vector2)boid.transform.position) * boidZoneSO.centeringFactor;
                boid.velocity += (avg_vel - boid.velocity) * boidZoneSO.matchingFactor;
            }
            boid.velocity += close_d * boidZoneSO.avoidFactor;
            if (boid.transform.position.y > boidZoneSO.maxBounds.y)
                boid.velocity.y -= boidZoneSO.turnFactor;
            if (boid.transform.position.y < boidZoneSO.minBounds.y)
                boid.velocity.y += boidZoneSO.turnFactor;
            if (boid.transform.position.x > boidZoneSO.maxBounds.x)
                boid.velocity.x -= boidZoneSO.turnFactor;
            if (boid.transform.position.x < boidZoneSO.minBounds.x)
                boid.velocity.x += boidZoneSO.turnFactor;

            float speed = boid.velocity.magnitude;
            if (speed > boidZoneSO.maxSpeed) boid.velocity = boid.velocity.normalized * boidZoneSO.maxSpeed;
            if (speed < boidZoneSO.minSpeed) boid.velocity = boid.velocity.normalized * boidZoneSO.minSpeed;
            boid.transform.position += (Vector3)boid.velocity * Time.fixedDeltaTime;

            if (boid.velocity.sqrMagnitude > 0.01f)
            {
                float angle = Mathf.Atan2(boid.velocity.y, boid.velocity.x) * Mathf.Rad2Deg;
                boid.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            }
        }
    }
}
