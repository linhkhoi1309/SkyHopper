using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ObstacleSpinner : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 40f;
    [SerializeField] private bool isCircular = true;
    [SerializeField] private float maxAngle = 90f;
    [SerializeField] private float minAngle = -90f;

    private void Update()
    {
        transform.Rotate(0f, 0f, Time.deltaTime * spinSpeed);

        if (!isCircular)
        {
            float zRotation = transform.rotation.eulerAngles.z;
            zRotation = (zRotation > 180) ? zRotation - 360 : zRotation; // Convert to range -180 to 180
            if (zRotation >= maxAngle || zRotation <= minAngle)
            {
                spinSpeed = -spinSpeed;
            }
        }
    }
}
