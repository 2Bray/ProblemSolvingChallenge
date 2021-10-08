using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    private float speed = 0.0001f;
    Rigidbody2D playerRb;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerRb.velocity = Vector2.right;
    }
}
