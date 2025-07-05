using UnityEngine;

[DisallowMultipleComponent]
public class Obstacle : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == GlobalConfig.PLAYER_TAG && !player.hasLost) player.Lost();
    }
}
