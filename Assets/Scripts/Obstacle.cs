using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CameraShakeManager.instance.ShakeCamera(player.cinemachineImpulseSource);
            player.particleSystem.Play();
            player.playerControl.DisableControl();
            player.hasLost = true;
        }
    }
}
