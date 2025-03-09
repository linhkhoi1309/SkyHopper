using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class PathMovement : MonoBehaviour
{
    [HideInInspector]public PathSO pathSO;
    private float speed;

    List<Vector3> waypointsPositions;

    int currentWaypoint = 0;

    private void Start()
    {
        if (pathSO != null)
        {
            waypointsPositions = pathSO.waypointsPositions;
            speed = GetPathSpeed();
            transform.position = waypointsPositions[currentWaypoint];
            StartCoroutine(MovePathRoutine());
        }
    }

    IEnumerator MovePathRoutine()
    {
        bool isReversed = false;
        while (currentWaypoint < waypointsPositions.Count || pathSO.isLooping)
        {   
            transform.position = Vector3.MoveTowards(transform.position, waypointsPositions[currentWaypoint], speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, waypointsPositions[currentWaypoint]) < 0.1f)
            {
                if(pathSO.isLooping)
                {
                    if(currentWaypoint == waypointsPositions.Count - 1) isReversed = true;
                    if(currentWaypoint == 0) isReversed = false;
                }
                transform.position = waypointsPositions[currentWaypoint];
                if(!isReversed) currentWaypoint++;
                else currentWaypoint--;
            }
            yield return null;
        }
        if(!pathSO.isLooping) Destroy(gameObject);
    }
    private float GetPathSpeed()
    {
        return Random.Range(pathSO.minSpeed, pathSO.maxSpeed);
    }
}
