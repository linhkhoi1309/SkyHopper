using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerControl))]
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
        CameraShakeManager.instance.ShakeCamera(cinemachineImpulseSource);
        hasLost = true;
        explosionParticleSystem.Play();
        playerControl.DisableControl();
        AudioManager.instance.PlaySound(AudioManager.instance.crashSound);
        Handheld.Vibrate();
    }
}
