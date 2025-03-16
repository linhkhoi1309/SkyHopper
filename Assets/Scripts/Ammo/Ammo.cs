using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] float ammoSpeed;
    [SerializeField] float ammoRange;

    public void Move(Vector3 origin, Vector3 directionVector)
    {
        Vector3 targetPosition = origin + directionVector.normalized * ammoRange;
        StartCoroutine(MoveAmmoRoutine(targetPosition));
    }

    IEnumerator MoveAmmoRoutine(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, ammoSpeed * Time.deltaTime);
            yield return null;
        }
        ObjectPoolManager.instance.ReturnToPool(gameObject.tag, gameObject);
    }
}
