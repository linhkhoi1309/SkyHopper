using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Path/PathSO", fileName = "Path_")]
public class PathSO : ScriptableObject
{
    [HideInInspector] public List<Vector3> waypointsPositions = new List<Vector3>();

    [Tooltip("Array of GameObjects that can be spawned along the path")]
    public GameObject[] gameObjectArray;

    [Tooltip("Minimum speed of the path object")]
    [Min(0f)]
    public float minSpeed;

    [Tooltip("Maximum speed of the path object")]
    [Min(0f)]
    public float maxSpeed;

    [Tooltip("Delay time before going to the next waypoint")]
    [Min(0f)]
    public float delayTime;

    [Tooltip("Time between each spawn of the path object")]
    [Min(0f)]
    public float interval;

    [Tooltip("Variation in the interval time between each spawn of the path object")]
    [Min(0f)]
    public float intervalVariation = 0f;

    [Tooltip("If true, the path will move back and forth")]
    public bool pingPong = false;

    [Tooltip("If true, the path will spawn objects infinitely")]
    public bool infiniteSpawning = true;

    [Tooltip("Maximum number of objects that can be spawned along the path. If infinite spawning is true, this value will be ignored.")]
    [Min(0)]
    public int maxSpawnedObjects;

    public void InitializeWaypointsPositions(List<Transform> waypointsTransforms){
        waypointsPositions.Clear();
        foreach(Transform waypointTransform in waypointsTransforms){
            waypointsPositions.Add(waypointTransform.position);
        }
    }
}
