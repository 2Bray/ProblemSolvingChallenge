using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerScript : MonoBehaviour
{
    private float speed = 0.01f;
    private Rigidbody2D playerRb;
    private bool hit = false;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.sharedMaterial.bounciness = 0;
    }

    private void FixedUpdate()
    {
        playerRb.velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) playerRb.velocity = Vector2.up * 5;
        if (Input.GetKey(KeyCode.D)) playerRb.velocity = Vector2.right * 5;
        if (Input.GetKey(KeyCode.S)) playerRb.velocity = Vector2.down * 5;
        if (Input.GetKey(KeyCode.A)) playerRb.velocity = Vector2.left * 5;
    }
}
