using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Vector2 jumpSpeed = new Vector2(0f, 10f);
    Rigidbody2D playerRgbd2d;
    public bool isControlEnabled = true;
    AudioSource playerAudioSource;
    void Start()
    {
        playerRgbd2d = GetComponent<Rigidbody2D>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    public void OnJump()
    {
        if (isControlEnabled)
        {
            playerAudioSource.Play();
            playerRgbd2d.linearVelocity = jumpSpeed;
        }
    }
    public void EnableControl(bool isEnabled)
    {
        isControlEnabled = isEnabled;
    }
}
