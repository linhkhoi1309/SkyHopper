using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    [SerializeField] Vector2 jumpSpeed = new Vector2(0f, 10f);
    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnJump()
    {
        GetComponent<AudioSource>().Play();
        rgbd2d.velocity = jumpSpeed;
    }
}
