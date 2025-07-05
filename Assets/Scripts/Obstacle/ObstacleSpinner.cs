using System;
using UnityEngine;

[DisallowMultipleComponent]
public class ObstacleSpinner : MonoBehaviour
{
    [Tooltip("Speed of the spinning effect in degrees per second")]
    [SerializeField] float spinSpeed = 40f;

    [Tooltip("If true, the spinner will rotate continuously in a circular motion. If false, it will oscillate between max and min angles.")]
    [SerializeField] bool isCircular = true;

    [Tooltip("Starting angle for oscillation in degrees. Only used if isCircular is false.")]
    [Range(0f, 360f)]
    [SerializeField] float startAngle;

    [Tooltip("Target  angle for oscillation in degrees. Only used if isCircular is false.")]
    [Range(0f, 360f)]
    [SerializeField] float endAngle;

    [Tooltip("If true, the spinner will oscillate back and forth between start and end angles. If false, it will only rotate in one direction and restart from the starting angle.")]
    [SerializeField] bool pingPong = true;
    bool movingToEnd = true;

    private void Start()
    {
        if (!isCircular) transform.rotation = Quaternion.Euler(0f, 0f, startAngle);
    }

    private void Update()
    {
        float rotationAmount = Time.deltaTime * Mathf.Abs(spinSpeed);
        transform.Rotate(0f, 0f, rotationAmount * Mathf.Sign(spinSpeed));
        if (!isCircular)
        {
            float currentAngle = transform.eulerAngles.z;
            if (pingPong)
            {
                if (movingToEnd && Mathf.Abs(currentAngle - endAngle) <= rotationAmount)
                {
                    spinSpeed = -spinSpeed;
                    movingToEnd = false; 
                }
                else if (!movingToEnd && Mathf.Abs(currentAngle - startAngle) <= rotationAmount)
                {
                    spinSpeed = -spinSpeed; 
                    movingToEnd = true; 
                }
            }
            else
            {
                if(Mathf.Abs(currentAngle - endAngle) <= rotationAmount)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, startAngle);
                }
            }
        }
    }
}
