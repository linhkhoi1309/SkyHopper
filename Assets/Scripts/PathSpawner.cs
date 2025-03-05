using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct Path
    {
        [SerializeField] public PathSO pathSO;
        [SerializeField] public List<Transform> waypointsTransforms;
    }

    [SerializeField] List<Path> pathList;

    void Start()
    {
        foreach (Path path in pathList)
        {
            path.pathSO.InitializeWaypointsPositions(path.waypointsTransforms);
            StartCoroutine(SpawnPathObjectRoutine(path.pathSO));
        }
    }
    private IEnumerator SpawnPathObjectRoutine(PathSO pathSO)
    {
        while (true)
        {
            GameObject pathObject = Instantiate(pathSO.gameObjectArray[0], pathSO.waypointsPositions[0], Quaternion.identity, transform);
            pathObject.GetComponent<PathMovement>().pathSO = pathSO;
            yield return new WaitForSeconds(pathSO.interval);
        }
    }
}
