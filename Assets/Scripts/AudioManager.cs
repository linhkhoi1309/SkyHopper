using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Sound Effects")]
    public AudioClip buttonClickedSound;
    public AudioClip crashSound;
    [Header("Music")]
    public AudioClip mainMenuMusic;
    [Header("Audio Sources")]
    [SerializeField] AudioSource SFXsource;
    [SerializeField] AudioSource musicSource;
    public static AudioManager instance;

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

    public void PlaySound(AudioClip sound)
    {
        SFXsource.PlayOneShot(sound);
    }

    public void PlayMusic(AudioClip music)
    {
        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
    }
}
