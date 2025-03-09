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
        int spawnedObjects = 0;
        while (pathSO.infiniteSpawning || (!pathSO.infiniteSpawning && spawnedObjects < pathSO.maxSpawnedObjects))
        {
            foreach (GameObject pathObjectPrefab in pathSO.gameObjectArray)
            {
                GameObject pathObject = Instantiate(pathObjectPrefab, pathSO.waypointsPositions[0], pathObjectPrefab.transform.rotation, transform);
                pathObject.GetComponent<PathMovement>().pathSO = pathSO;
                spawnedObjects++;
                if(!pathSO.infiniteSpawning && spawnedObjects == pathSO.maxSpawnedObjects) break;
                yield return new WaitForSeconds(pathSO.interval);
            }
        }
    }
}
