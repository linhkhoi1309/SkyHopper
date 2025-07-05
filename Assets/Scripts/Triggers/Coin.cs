using UnityEngine;

[DisallowMultipleComponent]
public class Coin : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The sound effect to play when collected")]
    AudioClip coinSFX;

    [SerializeField]
    [Tooltip("The amount of score to give when collected")]
    [Min(0)]
    int score = 10;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == GlobalConfig.PLAYER_TAG) {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position, 1f);
        }
    }
}
