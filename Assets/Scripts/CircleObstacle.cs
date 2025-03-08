using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObstacle : MonoBehaviour
{
    LineRenderer circleRenderer;
    MeshCollider meshCollider;

    [SerializeField] private float radius = 1.5f;
    [SerializeField] private int steps = 100;
    [SerializeField] private float gapSizePercent = 0.2f;
    [SerializeField] private float spinSpeed = 40f;

    private void Awake()
    {
        circleRenderer = GetComponent<LineRenderer>();
        meshCollider = GetComponent<MeshCollider>();
    }

    private void Start()
    {
        DrawCircle();
        // Mesh mesh = new Mesh();
        // circleRenderer.BakeMesh(mesh, true);
        // meshCollider.sharedMesh = mesh;
    }

    void DrawCircle()
    {
        circleRenderer.positionCount = steps;
        for (int currentStep = 0; currentStep <= steps; currentStep++)
        {
            float circumferenceProgress = (float)currentStep / steps;
            float currentRadian = circumferenceProgress * 2 * Mathf.PI * (1 - gapSizePercent);
            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x, y, 0f);
            circleRenderer.SetPosition(currentStep, currentPosition);
        }
    }

    private void Update() {
        transform.eulerAngles += new Vector3(0f, 0f, Time.deltaTime * spinSpeed);
    }
}
