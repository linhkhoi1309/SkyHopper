using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Path/PathSO", fileName = "Path_")]
public class PathSO : ScriptableObject
{
    public List<Transform> waypointsTransform;
    public  GameObject[] gameObjectArray;
    public float minSpeed;
    public float maxSpeed;
    public float interval;
}
