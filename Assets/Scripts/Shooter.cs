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

    [SerializeField] bool isMultiShots = false;

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
            while (Quaternion.Angle(targetRotation, transform.rotation) >= 0.1f)
            {
                float step = rotateSpeed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
                yield return null;
            }
            yield return new WaitForSeconds(intervalBetweenTurns);
        }
    }
    Quaternion GetRandomRotation()
    {
        return Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
    }
}
