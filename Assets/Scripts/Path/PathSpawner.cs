using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
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
                GameObject pathObj = ObjectPoolManager.instance.SpawnFromPool(pathObjectPrefab.tag, pathSO.waypointsPositions[0], pathObjectPrefab.transform.rotation);
                pathObj.GetComponent<PathMovement>().MovePath(pathSO);
                spawnedObjects++;
                if (!pathSO.infiniteSpawning && spawnedObjects == pathSO.maxSpawnedObjects) yield break;
                yield return new WaitForSeconds(GetSpawningInterval(pathSO));
            }
        }
    }
    
    private float GetSpawningInterval(PathSO pathSO)
    {
        if(pathSO.intervalVariation <= 0f) return pathSO.interval;
        float variation = Random.Range(-pathSO.intervalVariation, pathSO.intervalVariation);
        return pathSO.interval + variation;
    }
}
