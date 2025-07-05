using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSO ammoSO;
    public void Move(Vector3 origin, Vector3 directionVector)
    {
        Vector3 targetPosition = origin + directionVector.normalized * ammoSO.ammoRange;
        StartCoroutine(MoveAmmoRoutine(targetPosition));
    }

    IEnumerator MoveAmmoRoutine(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, ammoSO.ammoSpeed * Time.deltaTime);
            yield return null;
        }
        ObjectPoolManager.instance.ReturnToPool(gameObject.tag, gameObject);
    }
}
