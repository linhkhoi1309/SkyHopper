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
        while (currentWaypoint < waypointsPositions.Count)
        {   transform.position = Vector3.MoveTowards(transform.position, waypointsPositions[currentWaypoint], speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, waypointsPositions[currentWaypoint]) < 0.1f)
            {
                transform.position = waypointsPositions[currentWaypoint];
                currentWaypoint++;
            }
            yield return null;
        }
        Destroy(gameObject);
    }
    private float GetPathSpeed()
    {
        return Random.Range(pathSO.minSpeed, pathSO.maxSpeed);
    }
}
