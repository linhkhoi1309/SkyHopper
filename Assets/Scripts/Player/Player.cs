using Cinemachine;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerControl),typeof(CinemachineImpulseSource))]
public class Player : MonoBehaviour
{
    [HideInInspector] public CinemachineImpulseSource cinemachineImpulseSource;

    [HideInInspector] public PlayerControl playerControl;

    [HideInInspector] public bool hasLost = false;

    [HideInInspector] public bool hasCompleted = false;

    public ParticleSystem explosionParticleSystem;

    public ParticleSystem shieldParticleSystem;

    private void Awake() {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        playerControl = GetComponent<PlayerControl>();
    }

    public void Lost(){
        hasLost = true;
        CameraShakeManager.instance.ShakeCamera(cinemachineImpulseSource);
        explosionParticleSystem.Play();
        playerControl.EnableControl(false);        
        AudioManager.instance.PlaySound(AudioManager.instance.crashSound);        
        #if UNITY_IPHONE || UNITY_ANDROID
        Handheld.Vibrate();
        #endif
        DatabaseManager.Instance.UpdateLevelCompletion(GameManager.instance.currentLevelId, false);
        GameManager.instance.GameOver();
    }

    public void Pause(){
        playerControl.EnableControl(false);
    }

    public void Continue(){
        playerControl.EnableControl(true);
    }
}
