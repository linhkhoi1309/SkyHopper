using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[DisallowMultipleComponent]
public class HomingMissile : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 200f;
    public float activationDelay = 0.5f;
    public float lifeTime = 5f;
    public float detectionRange = 5f; 
    private Rigidbody2D rb;
    private Transform target;
    private bool isActive = false;
    private bool playerDetected = false;
    private float activationTimer = 0f;
    AudioSource audioSource;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        rb.gravityScale = 0;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (isActive || target == null) return;
        
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        
        if (distanceToPlayer <= detectionRange && !playerDetected)
        {
            playerDetected = true;
            activationTimer = 0f;
        }
        
        if (playerDetected)
        {
            activationTimer += Time.deltaTime;
            if (activationTimer >= activationDelay)
            {
                ActivateMissile();
            }
        }
    }

    void ActivateMissile()
    {
        isActive = true;
        audioSource.Play();
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        if (!isActive || target == null) return;
        Vector2 direction = ((Vector2)target.position - rb.position).normalized;
        float angleDifference = Vector2.SignedAngle(transform.up, direction); // Positive = counter-clockwise, Negative = clockwise
        rb.angularVelocity = angleDifference * rotateSpeed * Mathf.Deg2Rad; // rotates positive angular velocity counter-clockwise, negative is clockwise.
        rb.linearVelocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = isActive ? Color.red : (playerDetected ? Color.yellow : Color.green);
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        #if UNITY_EDITOR
        UnityEditor.Handles.Label(transform.position + Vector3.up * (detectionRange + 0.5f), 
            $"Detection: {detectionRange:F1}m");
        #endif
    }
}
