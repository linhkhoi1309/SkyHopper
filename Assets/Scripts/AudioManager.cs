using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip buttonClickedSound;
    public static AudioManager instance;

    AudioSource audioSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instance
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
