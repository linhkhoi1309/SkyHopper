using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    [SerializeField] List<Boid> boids;

    public Vector2 minBounds;
    public Vector2 maxBounds;
    public float minSpeed = 2f;
    public float maxSpeed = 3f;
    public float turnFactor = 0.2f;
    public float matchingFactor = 0.05f;
    public float avoidFactor = 0.05f;
    public float centeringFactor = 0.0005f;
    public float visualRange = 20f;
    public float protectedRange = 2f;
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
                if (Mathf.Abs(d.x) < visualRange && Mathf.Abs(d.y) < visualRange)
                {
                    float squared_distance = d.magnitude;
                    if (squared_distance < protectedRange)
                    {
                        close_d += new Vector2(d.x, d.y);
                    }
                    else if (squared_distance < visualRange)
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
                boid.velocity += (avg_pos - (Vector2)boid.transform.position) * centeringFactor;
                boid.velocity += (avg_vel - boid.velocity) * matchingFactor;
            }
            boid.velocity += close_d * avoidFactor;
            if (boid.transform.position.y > maxBounds.y)
                boid.velocity.y -= turnFactor;
            if (boid.transform.position.y < minBounds.y)
                boid.velocity.y += turnFactor;
            if (boid.transform.position.x > maxBounds.x)
                boid.velocity.x -= turnFactor;
            if (boid.transform.position.x < minBounds.x)
                boid.velocity.x += turnFactor;

            float speed = boid.velocity.magnitude;
            if (speed > maxSpeed) boid.velocity = boid.velocity.normalized * maxSpeed;
            if (speed < minSpeed) boid.velocity = boid.velocity.normalized * minSpeed;
            boid.transform.position += (Vector3)boid.velocity * Time.fixedDeltaTime;

            if (boid.velocity.sqrMagnitude > 0.01f) 
            {
                float angle = Mathf.Atan2(boid.velocity.y, boid.velocity.x) * Mathf.Rad2Deg;
                boid.transform.rotation = Quaternion.Euler(0, 0, angle - 90); 
            }
        }
    }
}
