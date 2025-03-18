using System.Collections;
using UnityEngine;

public class ObstacleFlasher : MonoBehaviour
{
    [SerializeField] private float minFlashDuration = 1f;
    [SerializeField] private float maxFlashDuration = 2f;
    private Renderer obstacleRenderer;

    void Start()
    {
        obstacleRenderer = GetComponent<Renderer>();
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        while (true)
        {
            obstacleRenderer.enabled = false;
            yield return new WaitForSeconds(GetFlashDuration());

            obstacleRenderer.enabled = true;
            yield return new WaitForSeconds(GetFlashDuration());
        }
    }

    private float GetFlashDuration()
    {
        return Random.Range(minFlashDuration, maxFlashDuration);
    }
}
