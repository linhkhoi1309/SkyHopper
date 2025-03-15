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

    public AudioClip crashedSFX;

    public ParticleSystem explosionParticleSystem;

    public ParticleSystem shieldParticleSystem;

    private void Awake() {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        playerControl = GetComponent<PlayerControl>();
    }
}
