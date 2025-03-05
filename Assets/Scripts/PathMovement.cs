using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PathMovement : MonoBehaviour
{
    [SerializeField] PathSO pathSO;
    private float speed;

    List<Vector3> waypointsPositions;

    int currentWaypoint = 0;
    
    private void Start() {
        InitializeWaypointsPositions();
        speed = GetPathSpeed(pathSO);
        transform.position = waypointsPositions[currentWaypoint];
        StartCoroutine(MovePathRoutine());
    }

    IEnumerator MovePathRoutine(){
        while(currentWaypoint < waypointsPositions.Count){
            if(Vector3.Distance(transform.position, waypointsPositions[currentWaypoint]) < 0.1f){
                transform.position = waypointsPositions[currentWaypoint];
                currentWaypoint++;
            }
            else transform.position = Vector3.MoveTowards(transform.position, waypointsPositions[currentWaypoint], speed * Time.deltaTime);
            yield return null;
        }
    }

    private void InitializeWaypointsPositions()
    {
        foreach(Transform waypointTransform in pathSO.waypointsTransform)
        {
            waypointsPositions.Add(waypointTransform.position);   
        }
    }

    private float GetPathSpeed(PathSO pathSO){
        return Random.Range(pathSO.minSpeed, pathSO.maxSpeed);
    }
}
