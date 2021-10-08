using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float speed = 0.01f;
    private Rigidbody2D playerRb;
    private float timerToSmall = 0;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.sharedMaterial.bounciness = 0;
    }

    private void FixedUpdate()
    {
        //Pergerakan player & Camera
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        playerRb.MovePosition(Vector3.Lerp(transform.position, mousePosition, speed));


        Vector3 moveTo = transform.position;
        Transform camera = Camera.main.transform;
        moveTo.z = camera.position.z;
        camera.position = moveTo;

        //Player Mengecil
        timerToSmall += Time.deltaTime;
        if (timerToSmall > 6) goingSmall();
    }

    private void goingSmall()
    {
        timerToSmall = 0;
        float size = GameControllerScript.Instance.playerGoingSmall;
        transform.localScale -= new Vector3(size,size);
    }
}