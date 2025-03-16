using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
public class PathMovement : MonoBehaviour
{
    [HideInInspector] PathSO pathSO;
    private float speed;

    List<Vector3> waypointsPositions;

    int currentWaypoint;

    public void MovePath(PathSO pathSO)
    {
        this.pathSO = pathSO;
        currentWaypoint = 0;
        waypointsPositions = pathSO.waypointsPositions;
        speed = GetPathSpeed();
        transform.position = waypointsPositions[currentWaypoint];
        StartCoroutine(MovePathRoutine());
    }

    IEnumerator MovePathRoutine()
    {
        bool isReversed = false;
        while (currentWaypoint < waypointsPositions.Count || pathSO.pingPong)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypointsPositions[currentWaypoint], speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, waypointsPositions[currentWaypoint]) < 0.1f)
            {
                if (pathSO.pingPong)
                {
                    if (currentWaypoint == waypointsPositions.Count - 1) isReversed = true;
                    else if (currentWaypoint == 0) isReversed = false;
                }
                transform.position = waypointsPositions[currentWaypoint];
                if (!isReversed) currentWaypoint++;
                else currentWaypoint--;
                yield return new WaitForSeconds(pathSO.delayTime);
            }
            yield return null;
        }
        if (!pathSO.pingPong) ObjectPoolManager.instance.ReturnToPool(gameObject.tag, gameObject);
    }
    private float GetPathSpeed()
    {
        return Random.Range(pathSO.minSpeed, pathSO.maxSpeed);
    }
}
