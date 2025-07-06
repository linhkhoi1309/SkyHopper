using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(SpriteRenderer))]
public class FinishingLine : MonoBehaviour
{
    public float blinkDuration = 0.5f;
    public bool isBlinking = true;

    SpriteRenderer spriteRenderer;
    Player player;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindFirstObjectByType<Player>();
    }
    private void Start()
    {
        if (spriteRenderer != null)
            StartCoroutine(BlinkingRoutine());
    }

    private IEnumerator BlinkingRoutine()
    {
        while (isBlinking)
        {
            yield return StartCoroutine(FadeAlpha(1f, 0.1f, blinkDuration));
            yield return StartCoroutine(FadeAlpha(0.1f, 1f, blinkDuration));
        }
    }

    private IEnumerator FadeAlpha(float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;
        Color color = spriteRenderer.color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            spriteRenderer.color = color;
            yield return null;
        }

        color.a = endAlpha;
        spriteRenderer.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConfig.PLAYER_TAG) && !player.hasCompleted)
        {
            AudioManager.instance.PlaySound(AudioManager.instance.completeSound);
            player.hasCompleted = true;
            int currentLevelId = GameManager.instance.currentLevelId;
            DatabaseManager.Instance.UpdateLevelCompletion(currentLevelId, true);
            if (currentLevelId + 1 <= GameManager.instance.levels.Count)
                DatabaseManager.Instance.UpdateLevelUnlockStatus(currentLevelId + 1, true);
            GameManager.instance.GameOver();
        }
    }
}
