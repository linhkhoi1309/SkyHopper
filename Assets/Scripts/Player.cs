using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public CinemachineImpulseSource cinemachineImpulseSource;
    void Start()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }
}
