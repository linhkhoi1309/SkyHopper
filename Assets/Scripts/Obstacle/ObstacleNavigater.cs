using UnityEngine;

[DisallowMultipleComponent]
public class ObstacleNavigater : MonoBehaviour
{
    Vector2 startPosition;
    Vector2 targetPosition;

    [Tooltip("Offset from the start position to the target position")]
    public Vector2 targetOffset;

    [Tooltip("Speed of the obstacle")]
    [Min(0f)]
    public float speed = 10f;

    [Tooltip("Delay before the obstacle starts moving")]
    [Min(0f)]
    public float delay = 0f;

    [Tooltip("If true, the obstacle will move back and forth between the start and target positions")]
    public bool pingPong = false;

    private Vector2 currentTarget;
    private float waitTimer = 0f;
    private bool waiting = false;

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + targetOffset;
        currentTarget = targetPosition;
    }

    private void Update()
    {
        if (waiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                waiting = false;
                // Switch direction if pingPong enabled
                if (pingPong)
                {
                    currentTarget = currentTarget == targetPosition ? startPosition : targetPosition;
                }
            }
            return;
        }

        // Move toward current target
        Vector2 currentPosition = transform.position;
        Vector2 direction = (currentTarget - currentPosition).normalized;
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(currentPosition, currentTarget, step);

        // Reached target?
        if (Vector2.Distance(currentPosition, currentTarget) < 0.01f)
        {
            if (pingPong)
            {
                waiting = true;
                waitTimer = delay;
            }
            else
            {
                // Stop moving if not pingPong
                enabled = false;
            }
        }
    }
}
