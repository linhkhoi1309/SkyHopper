using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class ObstacleFlasher : MonoBehaviour
{
    [Tooltip("Minimum duration for the flash effect in seconds")]
    [SerializeField] private float minFlashDuration = 1f;
    
    [Tooltip("Maximum duration for the flash effect in seconds")]
    [SerializeField] private float maxFlashDuration = 2f;

    void Start()
    {
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        while (true)
        {
            gameObject.SetActive(false);
            yield return new WaitForSeconds(GetFlashDuration());
            gameObject.SetActive(true);
            yield return new WaitForSeconds(GetFlashDuration());
        }
    }

    private float GetFlashDuration()
    {
        return Random.Range(minFlashDuration, maxFlashDuration);
    }
}
