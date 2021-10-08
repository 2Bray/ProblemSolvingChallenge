using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInGameScript : MonoBehaviour
{
    [HideInInspector] public FoodControllerGameScript foodControl;
    [HideInInspector] public int idx;


    private void OnEnable()
    {
        StartCoroutine(countDount());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Memakan jika object food lebih kecil dari pada object player
            if (transform.localScale.x < collision.transform.localScale.x)
            {
                StopCoroutine(countDount());
                collision.transform.localScale += transform.localScale / GameControllerScript.Instance.playerGoingBig;
                
                //Memanggil method PlayerGetFood Untuk Menambahkan Score Player
                foodControl.PlayerGetFood(gameObject);
            }
            //Game Over Bila Lebih Besar
            else GameControllerScript.Instance.GameOver();
        }
    }

    //Jika Tidak Dimakan Player Selama 10sec
    //Object di reset
    private IEnumerator countDount()
    {
        yield return new WaitForSecondsRealtime(10f);
        foodControl.StartCoroutine(foodControl.setActive(gameObject));
    }
}
