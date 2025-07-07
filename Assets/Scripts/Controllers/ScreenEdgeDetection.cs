using UnityEngine;

[DisallowMultipleComponent]
public class ScreenEdgeDetection : MonoBehaviour
{
    [SerializeField] GameObject target;
    Player player;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(target.transform.position - new Vector3(0f, target.transform.localScale.y / 2, 0f));
            if (pos.y < 0.0)
            {
                if (target.tag == "Player")
                {
                    if (!player.hasLost) player.Lost();
                    else Destroy(target, 0.2f);
                }
            }
        }
    }
}
