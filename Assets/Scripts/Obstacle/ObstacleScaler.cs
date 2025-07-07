using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class ObstacleScaler : MonoBehaviour
{
    [Tooltip("Target scale to scale to")]
    [SerializeField] Vector3 targetScale = new Vector3(2f, 2f, 2f);

    [Tooltip("Duration to scale from initial scale to target scale")]
    [SerializeField]
    [Min(0f)]
    float scaleDuration = 1f;

    [Tooltip("Variation in scale duration, in seconds.")]
    [Min(0f)]
    [SerializeField] float scaleDurationVariation;

    [Tooltip("Time to wait before scaling to next scale")]
    [SerializeField]
    [Min(0f)]
    float scaleDelayTime = 0.5f;

    [Tooltip("Variation in scale delay time, in seconds.")]
    [SerializeField]
    [Min(0f)]
    float scaleDelayTimeVariation;

    Vector3 initialScale;
    bool scalingToTarget = true;

    void Start()
    {
        initialScale = transform.localScale;
        StartCoroutine(ScaleRoutine());
    }

    private float GetScaleDuration()
    {
        return Mathf.Clamp(scaleDuration + Random.Range(-scaleDurationVariation, scaleDurationVariation), 0.0f, float.MaxValue);
    }

    private float GetScaleDelayTime()
    {
        return Mathf.Clamp(scaleDelayTime + Random.Range(-scaleDelayTimeVariation, scaleDelayTimeVariation), 0.0f, float.MaxValue);
    }

    IEnumerator ScaleRoutine()
    {
        while (true)
        {
            Vector3 startScale = scalingToTarget ? initialScale : targetScale;
            Vector3 endScale = scalingToTarget ? targetScale : initialScale;

            float timer = 0f;
            float currentScaleDuration = GetScaleDuration();
            while (timer < currentScaleDuration)
            {
                timer += Time.deltaTime;
                float progress = Mathf.Clamp01(timer / currentScaleDuration);
                transform.localScale = Vector3.Lerp(startScale, endScale, progress);
                yield return null;
            }
            transform.localScale = endScale;
            yield return new WaitForSeconds(GetScaleDelayTime());
            scalingToTarget = !scalingToTarget;
        }
    }
}
