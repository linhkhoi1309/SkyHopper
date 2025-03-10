using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ObstacleSpinner : MonoBehaviour
{
   [SerializeField] private float spinSpeed = 40f;
    
    private void Update()
    {
        transform.Rotate(0f, 0f, Time.deltaTime * spinSpeed);
    }
}
