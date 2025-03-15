using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject rotationPoint;
    [SerializeField] GameObject shootingPoint;

    [SerializeField] float maxAngle;
    [SerializeField] float minAngle;

    [Tooltip("Interval between shots is the time between shots")]
    [SerializeField] float intervalBetweenShots;

    [Tooltip("Interval between turns is the time between turns. Each turn can have multiple shots")]
    [SerializeField] float intervalBetweenTurns;

    [SerializeField] float rotateSpeed;

    [Tooltip("How many shots are shot at the same turn")]
    [SerializeField] int numberOfConcurrentShots = 1;

    [SerializeField] bool isLaserBeam;

    [SerializeField] Material laserMaterial;

    [SerializeField] GameObject ammoPrefab;

    private void Start()
    {
        StartCoroutine(RotateRoutine());
    }

    IEnumerator RotateRoutine()
    {
        while (true)
        {
            Quaternion targetRotation = GetRandomRotation();
            while (Quaternion.Angle(targetRotation, rotationPoint.transform.rotation) >= 0.1f)
            {
                float step = rotateSpeed * Time.deltaTime;
                rotationPoint.transform.rotation = Quaternion.RotateTowards(rotationPoint.transform.rotation, targetRotation, step);
                yield return null;
            }
            StartCoroutine(ShootAmmoRoutine());
            yield return new WaitForSeconds(intervalBetweenTurns);
        }
    }
    IEnumerator ShootAmmoRoutine()
    {
        for (int i = 0; i < numberOfConcurrentShots; i++)
        {
            GameObject ammo = ObjectPoolManager.instance.SpawnFromPool(ammoPrefab.tag, shootingPoint.transform.position, rotationPoint.transform.rotation);
            ammo.GetComponent<Ammo>().Move(shootingPoint.transform.position, GetDirectionVectorFromAngle(rotationPoint.transform.eulerAngles.z));
            yield return new WaitForSeconds(intervalBetweenShots);
        }
    }
    Quaternion GetRandomRotation()
    {
        return Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
    }

    public Vector3 GetDirectionVectorFromAngle(float angle)
    {
        Vector3 directionVector = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0f);
        return directionVector;
    }
}
