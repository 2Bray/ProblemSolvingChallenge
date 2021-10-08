using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveToFood : MonoBehaviour
{
    [HideInInspector] public Transform[] target;
    
    private Rigidbody2D rb;
    private int score = 0;
    private float speed = 0.05f;
    private int currentTarget;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Mengejar target jika seluruh target belum didapatkan
        if (currentTarget >= 0)
        {
            rb.MovePosition(Vector3.Lerp(transform.position, target[currentTarget].position, speed));
        }
    }

    public void GetFood(Text indikator, int idx)
    {
        //Menambahkan Score jika player mendapatkan food
        score++;
        indikator.text = "Score: " + score;

        //Mengeset target yang barusaja didapat menjadi non aktif
        target[idx].gameObject.SetActive(false);

        int i = 0;
        foreach(Transform item in target)
        {
            //Mendapatkan food yang masih aktif dan menjadikannya current target
            if (item.gameObject.activeSelf)
            {
                //jika food aktif didapat, keluar dari looping
                currentTarget = i;
                break;
            }
            //jika food tidak aktif, lanjut ke index berikut.
            i++;
        }
        //jika semua sudah didapat, buat object player tidak mengejar apapun
        if (i == target.Length) currentTarget = -1;
    }
}
