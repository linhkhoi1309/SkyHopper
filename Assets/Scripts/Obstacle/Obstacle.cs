using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Obstacle : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !player.hasLost)
        {
            CameraShakeManager.instance.ShakeCamera(player.cinemachineImpulseSource);
            player.explosionParticleSystem.Play();
            player.playerControl.DisableControl();
            player.hasLost = true;
            AudioSource.PlayClipAtPoint(player.crashedSFX, Camera.main.transform.position, 1f);
        }
    }
}
