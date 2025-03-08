using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer), typeof(EdgeCollider2D))]
public class CircleObstacle : MonoBehaviour
{
    LineRenderer circleRenderer;
    EdgeCollider2D edgeCollider;

    [SerializeField] private float radius = 1.5f;
    [SerializeField] private int steps = 100;
    [SerializeField] private float gapSizePercent = 0.2f;
    [SerializeField] private float spinSpeed = 40f;

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
        circleRenderer.positionCount = steps;
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

    private void Update()
    {
        transform.Rotate(0f, 0f, Time.deltaTime * spinSpeed);
    }
}
