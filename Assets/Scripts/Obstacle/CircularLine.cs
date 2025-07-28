using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer), typeof(EdgeCollider2D))]
[DisallowMultipleComponent]
public class CircleObstacle : MonoBehaviour
{
    [Tooltip("Radius of the circle in world units")]
    [SerializeField, Min(0f)] float radius = 1.5f;

    [Tooltip("Number of steps to create the circle. More steps means a smoother circle but higher performance cost.")]
    [SerializeField, Min(0)] int steps = 100;

    [Tooltip("Percentage of the circle that is a gap. 0 means no gap, 1 means full gap (no circle).")]
    [Range(0f, 1f)]
    [SerializeField] float gapSizePercent = 0.2f;

    LineRenderer circleRenderer;
    EdgeCollider2D edgeCollider;
    List<Vector2> colliderPoints = new List<Vector2>();

    private void Awake()
    {
        circleRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    private void Start()
    {
        DrawCircle();
    }

    void DrawCircle()
    {
        colliderPoints.Clear();
        circleRenderer.positionCount = steps + 1;
        for (int currentStep = 0; currentStep <= steps; currentStep++)
        {
            float circumferenceProgress = (float)currentStep / steps;
            float currentRadian = circumferenceProgress * 2 * Mathf.PI * (1 - gapSizePercent);
            float x = Mathf.Cos(currentRadian) * radius;
            float y = Mathf.Sin(currentRadian) * radius;

            Vector3 currentPosition = new Vector3(x, y, 0f);
            circleRenderer.SetPosition(currentStep, currentPosition);
            colliderPoints.Add(new Vector2(x, y));
        }
        edgeCollider.SetPoints(colliderPoints);
    }
}
