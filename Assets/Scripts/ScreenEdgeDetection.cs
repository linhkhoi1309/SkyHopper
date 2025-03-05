using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEdgeDetection : MonoBehaviour
{
    [SerializeField] GameObject target;
    bool hasShaken = false;

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(target.transform.position - new Vector3(0f, target.transform.localScale.x / 2, 0f));
        if (pos.y < 0.0)
        {
            if (target.tag == "Player" && !hasShaken)
            {
                CameraShakeManager.instance.ShakeCamera(target.GetComponent<Player>().cinemachineImpulseSource);
                hasShaken = true;
            }
        }
    }
}
