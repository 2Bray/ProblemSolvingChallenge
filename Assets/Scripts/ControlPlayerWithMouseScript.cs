using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerWithMouseScript : MonoBehaviour
{
    private float speed = 0.01f;
    private Rigidbody2D playerRb;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.sharedMaterial.bounciness = 0;
    }

    private void FixedUpdate()
    {
        //Pergerakan player
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        playerRb.MovePosition(Vector3.Lerp(transform.position, mousePosition, speed));
    }
}