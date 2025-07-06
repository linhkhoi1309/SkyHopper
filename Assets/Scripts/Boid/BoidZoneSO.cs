using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Boid/BoidZoneSO", fileName = "BoidZone_")]
public class BoidZoneSO : ScriptableObject
{
    [Tooltip("Minimum bounds of the boid zone. This defines the lower left corner of the zone.")]
    public Vector2 minBounds;

    [Tooltip("Maximum bounds of the boid zone. This defines the upper right corner of the zone.")]
    public Vector2 maxBounds;
    
    [Tooltip("Minimum speed of the boids")]
    public float minSpeed;

    [Tooltip("Maximum speed of the boids")]
    public float maxSpeed;

    [Tooltip("Acceleration factor for the boids")]
    public float turnFactor;

    [Tooltip("Factor for matching the velocity of nearby boids")]
    public float matchingFactor;

    [Tooltip("Factor for avoiding nearby boids")]
    public float avoidFactor;

    [Tooltip("Factor for centering the boids within the zone")]
    public float centeringFactor;

    [Tooltip("Range within which boids can see each other")]
    public float visualRange;

    [Tooltip("Range within which boids will avoid each other")]
    public float protectedRange;

    [Tooltip("Number of boids to spawn in this zone")]
    public int numOfBoids;

    [Tooltip("Prefab for the boid object")]
    public GameObject boidPrefab;
}
