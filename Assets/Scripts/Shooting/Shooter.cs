using System.Collections;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

[DisallowMultipleComponent]
public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject rotationPoint;
    [SerializeField] GameObject shootingPoint;

    [Tooltip("Can the shooter rotate?")]
    [SerializeField] bool canRotate = true;

    [Tooltip("Maximum angle for rotation")]
    [Min(0f)]
    [SerializeField] float maxAngle;

    [Tooltip("Minimum angle for rotation")]
    [Min(0f)]
    [SerializeField] float minAngle;

    [Tooltip("Interval between shots is the time between shots")]
    [Min(0f)]
    [SerializeField] float intervalBetweenShots;

    [Tooltip("Variation in the interval between shots. If set to 0, the interval is constant.")]
    [Min(0f)]
    [SerializeField] float intervalBetweenShotsVariation = 0f;

    [Tooltip("Interval between turns is the time between turns. Each turn is a rotation to a new angle.")]
    [Min(0f)]
    [SerializeField] float intervalBetweenTurns;

    [Tooltip("Variation in the interval between turns. If set to 0, the interval is constant.")]
    [Min(0f)]
    [SerializeField] float intervalBetweenTurnsVariation = 0f;

    [Tooltip("The speed at which the shooter rotates")]
    [Min(0f)]
    [SerializeField] float rotationSpeed = 0f;

    [Tooltip("Variation in rotation speed. If set to 0, the rotation speed is constant.")]
    [Min(0f)]
    [SerializeField] float rotationSpeedVariation = 0f;

    [Tooltip("How many shots are shot at the same turn")]
    [Min(1)]
    [SerializeField] int numberOfConcurrentShots = 1;

    [Tooltip("Variation in the number of concurrent shots. If set to 0, the number of concurrent shots is constant.")]
    [Min(0)]
    [SerializeField] int numberOfConcurrentShotsVariation = 0;

    [SerializeField] GameObject ammoPrefab;

    [SerializeField] bool hasLaserBeam = false;

    [SerializeField] Material laserMaterial;

    private void Start()
    {
        StartCoroutine(RotateRoutine());
    }

    IEnumerator RotateRoutine()
    {
        while (true)
        {
            float currentIntervalBetweenTurns = GetIntervalBetweenTurns();
            if (canRotate)
            {
                Quaternion targetRotation = GetRotation();
                float currentRotationSpeed = GetRotationSpeed();
                while (Quaternion.Angle(targetRotation, rotationPoint.transform.rotation) >= 0.1f)
                {
                    float step = currentRotationSpeed * Time.deltaTime;
                    rotationPoint.transform.rotation = Quaternion.RotateTowards(rotationPoint.transform.rotation, targetRotation, step);
                    yield return null;
                }
            }
            if(hasLaserBeam) StartCoroutine(ShootLaserRoutine());
            else StartCoroutine(ShootAmmoRoutine());
            yield return new WaitForSeconds(currentIntervalBetweenTurns);
        }
    }

    IEnumerator ShootLaserRoutine()
    {
        yield return new WaitForSeconds(GetIntervalBetweenTurns());
    }

    IEnumerator ShootAmmoRoutine()
    {
        int currentNumberOfConcurrentShots = GetNumberOfConcurrentShots();
        for (int i = 0; i < currentNumberOfConcurrentShots; i++)
        {
            float currentIntervalBetweenShots = GetIntervalBetweenShots();
            Vector3 directionVector = GetDirectionVector();
            GameObject ammo = ObjectPoolManager.instance.SpawnFromPool(ammoPrefab.tag, shootingPoint.transform.position, Quaternion.Euler(0f, 0f, rotationPoint.transform.rotation.eulerAngles.z));
            ammo.GetComponent<Ammo>().Move(shootingPoint.transform.position, directionVector);
            yield return new WaitForSeconds(currentIntervalBetweenShots);
        }
    }
    private Quaternion GetRotation()
    {
        return Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
    }

    private Vector3 GetDirectionVector()
    {
        return (shootingPoint.transform.position - rotationPoint.transform.position).normalized;
    }

    private float GetRotationSpeed()
    {
        return Mathf.Clamp(rotationSpeed + Random.Range(-rotationSpeedVariation, rotationSpeedVariation), 0f, float.MaxValue);
    }

    private int GetNumberOfConcurrentShots()
    {
        return Mathf.Clamp(numberOfConcurrentShots + Random.Range(-numberOfConcurrentShotsVariation, numberOfConcurrentShotsVariation), 1, int.MaxValue);
    }

    private float GetIntervalBetweenShots()
    {
        return Mathf.Clamp(intervalBetweenShots + Random.Range(-intervalBetweenShotsVariation, intervalBetweenShotsVariation), 0f, float.MaxValue);
    }

    private float GetIntervalBetweenTurns()
    {
        return Mathf.Clamp(intervalBetweenTurns + Random.Range(-intervalBetweenTurnsVariation, intervalBetweenTurnsVariation), 0f, float.MaxValue);
    }


    // private Vector3 GetDirectionVectorFromAngle(float angle)
    // {
    //     Vector3 directionVector = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0f);
    //     return directionVector;
    // }

    // private float GetAngleFromDirectionVector(Vector3 directionVector)
    // {
    //     float angle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg;
    //     return angle;
    // }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (rotationPoint == null)
            Debug.LogError("Rotation point is not assigned in the Shooter script.");

        if (shootingPoint == null)
            Debug.LogError("Shooting point is not assigned in the Shooter script.");

        if (ammoPrefab == null)
            Debug.LogError("Ammo prefab is not assigned in the Shooter script.");
    }
#endif
}
