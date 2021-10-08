using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerWithMouseScript : MonoBehaviour
{
    private float speed = 1f;
    private Rigidbody2D playerRb;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.sharedMaterial.bounciness = 0;
    }

    private void FixedUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        playerRb.AddForce( mousePosition * speed * Time.deltaTime, ForceMode2D.Impulse);
    }
}