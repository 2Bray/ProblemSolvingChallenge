using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public FoodControllerScript foodControl;
    public int idx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Memanggil method PlayerGetFood dan mengirim index object ini
        //Saat object ini bersentuhan dengan object player
        if (collision.tag == "Player") foodControl.PlayerGetFood(gameObject);
    }
}