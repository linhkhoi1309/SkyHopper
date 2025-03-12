using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinSFX;
    [SerializeField] int score = 10;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position, 1f);
        }
    }
}
