using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Path/PathSO", fileName = "Path_")]
public class PathSO : ScriptableObject
{
    [HideInInspector] public List<Vector3> waypointsPositions = new List<Vector3>();
    public  GameObject[] gameObjectArray;
    public float minSpeed;
    public float maxSpeed;
    public float interval;

    public void InitializeWaypointsPositions(List<Transform> waypointsTransforms){
        waypointsPositions.Clear();
        foreach(Transform waypointTransform in waypointsTransforms){
            waypointsPositions.Add(waypointTransform.position);
        }
    }
}
