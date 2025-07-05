using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class ObstacleScaler : MonoBehaviour
{
    [Tooltip("Target scale to scale to")]
    [SerializeField] Vector3 targetScale = new Vector3(2f, 2f, 2f);

    [Tooltip("Duration to scale from initial scale to target scale")]
    [SerializeField] float scaleDuration = 1f;

    [Tooltip("Time to wait before scaling to next scale")]
    [SerializeField] float delayTime = 0.5f;
    Vector3 initialScale;
    bool scalingToTarget = true;

    void Start()
    {
        initialScale = transform.localScale;
        StartCoroutine(ScaleRoutine());
    }

    IEnumerator ScaleRoutine()
    {
        while (true)
        {
            Vector3 startScale = scalingToTarget ? initialScale : targetScale;
            Vector3 endScale = scalingToTarget ? targetScale : initialScale;

            float timer = 0f;
            while (timer < scaleDuration)
            {
                timer += Time.deltaTime;
                float progress = Mathf.Clamp01(timer / scaleDuration);
                transform.localScale = Vector3.Lerp(startScale, endScale, progress);
                yield return null;
            }
            transform.localScale = endScale;
            yield return new WaitForSeconds(delayTime);
            scalingToTarget = !scalingToTarget;
        }
    }
}
