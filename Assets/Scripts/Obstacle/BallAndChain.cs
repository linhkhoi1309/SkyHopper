using UnityEngine;

[DisallowMultipleComponent]
public class BallAndChain : MonoBehaviour
{
    [Tooltip("The pivot point")]
    public Transform anchor;

    [Tooltip("The swinging ball rigidbody")]
    public Rigidbody2D ballRigidbody;

    [Tooltip("Force applied to the ball")]
    public float swingForce = 50f;

    private void Start() {
        ballRigidbody.AddForce(Vector2.right * swingForce, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        Vector2 anchorToBall = ballRigidbody.position - (Vector2)anchor.position;

        // Angle between the chain and the downward direction
        float angle = Vector2.SignedAngle(Vector2.down, anchorToBall) * Mathf.Deg2Rad;

        // Tangent direction (perpendicular to chain)
        Vector2 tangent = new Vector2(-anchorToBall.y, anchorToBall.x).normalized;

        // Apply oscillating force: sin(angle) is 0 at center, max at ends
        float oscillation = Mathf.Sin(angle);

        ballRigidbody.AddForce(tangent * oscillation * swingForce, ForceMode2D.Force);
    }
}
