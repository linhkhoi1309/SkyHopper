using UnityEngine;
using System.Collections;

public class ObstacleScaler : MonoBehaviour
{
    [SerializeField] private Vector3 targetScale = new Vector3(2f, 2f, 2f);
    [SerializeField] private float scaleDuration = 1f;
    [SerializeField] private float delayTime = 0.5f;

    private Vector3 initialScale;
    private bool scalingUp = true;

    void Start()
    {
        initialScale = transform.localScale;
        StartCoroutine(ScaleRoutine());
    }

    IEnumerator ScaleRoutine()
    {
        while (true)
        {
            Vector3 startScale = scalingUp ? initialScale : targetScale;
            Vector3 endScale = scalingUp ? targetScale : initialScale;

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

            scalingUp = !scalingUp; 
        }
    }
}
