using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    private float speed = 0.0001f;
    private Rigidbody2D playerRb;
    private bool hit = false;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hit) playerRb.velocity = Vector2.right * 10;
    }

    private void OnCollisionEnter2D(Collision2D collision) => hit = true;
    
}
