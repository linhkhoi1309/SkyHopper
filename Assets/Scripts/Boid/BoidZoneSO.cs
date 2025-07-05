using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Boid/BoidZoneSO", fileName = "BoidZone_")]
public class BoidZoneSO : ScriptableObject
{
    public Vector2 minBounds;
    public Vector2 maxBounds;
    public float minSpeed;
    public float maxSpeed;
    public float turnFactor;
    public float matchingFactor;
    public float avoidFactor;
    public float centeringFactor;
    public float visualRange;
    public float protectedRange;
    public int numOfBoids;
    public GameObject boidPrefab;

#if UNITY_EDITOR
    public void OnValidate()
    {
        if (boidPrefab != null)
        {
            if (boidPrefab.GetComponent<Boid>() == null)
            {
                boidPrefab.AddComponent<Boid>(); // make sure it has a Boid component
            }
        }
    }
#endif
}
