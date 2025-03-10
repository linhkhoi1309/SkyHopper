using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerControl))]
public class Player : MonoBehaviour
{
    [HideInInspector] public CinemachineImpulseSource cinemachineImpulseSource;
    [HideInInspector] public ParticleSystem particleSystem;

    [HideInInspector] public PlayerControl playerControl;

    [HideInInspector] public bool hasLost = false;

    [SerializeField] public bool isTestMode = false;

    public AudioClip crashedSFX;

    private void Awake() {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        particleSystem = GetComponent<ParticleSystem>();
        playerControl = GetComponent<PlayerControl>();
    }

    
}
