using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShakeManager : MonoBehaviour
{
    public static CameraShakeManager instance;

    public float globalShakeForce = 1f;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    public void ShakeCamera(CinemachineImpulseSource impulseSource){
        impulseSource.GenerateImpulseWithForce(globalShakeForce);
    }
}
