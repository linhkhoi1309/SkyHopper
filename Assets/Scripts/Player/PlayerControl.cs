using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    [SerializeField] Vector2 jumpSpeed = new Vector2(0f, 10f);

    public bool isControlAllowed = true;
    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    public void OnJump()
    {
        if (isControlAllowed)
        {
            GetComponent<AudioSource>().Play();
            rgbd2d.velocity = jumpSpeed;
        }
    }

    public void DisableControl(){
        isControlAllowed = false;
    }
    public void EnableControl(){
        isControlAllowed = true;
    }
}
