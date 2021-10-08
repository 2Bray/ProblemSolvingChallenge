using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private Transform[] walls;
    [SerializeField] private Text scoreIndikator;
    [SerializeField] private PlayerMoveToFood Player;

    private void Start()
    {
        // Inisiasi state awal
        Player.enabled = false;
        scoreIndikator.text = "Score: ";

        //Mengacak jumlah food, dan memasukan jumlah tersebut kedalam target pada object player
        int rand = Random.Range(2, 10);
        Player.target = new Transform[rand + 1];

        //Membuat satu-persatu object food
        for (int i = 0; i <= rand; i++)
        {
            //Mengacak posisi object food
            float posX = Random.Range(walls[3].position.x + 1, walls[1].position.x - 1);
            float posY = Random.Range(walls[2].position.y + 1, walls[0].position.y - 1);
            Vector3 foodPosition = new Vector3(posX, posY, 0);
            
            GameObject GO = Instantiate(food, foodPosition, Quaternion.identity);
            GO.GetComponent<FoodScript>().foodControl = this;
            GO.GetComponent<FoodScript>().idx = i;
            
            //Memasukan object food kedalam array target pada object player
            Player.target[i] = GO.transform;
        }
        //Aktifkan script PlayerMoveToFood saat seluruh object food sudah dibuat
        //Agar player bergerak mendapatkan food satu-persatu
        Player.enabled = true;
    }

    //Mengirim nomor index food yang barusaja didapat kepada object player
    public void PlayerGetFood(int idx)
    {
        Player.GetFood(scoreIndikator, idx);
    }
}