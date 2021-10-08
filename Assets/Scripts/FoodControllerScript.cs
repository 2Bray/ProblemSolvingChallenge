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
            GameObject GO = Instantiate(food);
            GO.GetComponent<FoodScript>().foodControl = this;
            GO.GetComponent<FoodScript>().idx = i;
            
            //Memasukan object food kedalam array target pada object player
            Player.target[i] = GO.transform;


            //Mengacak posisi object food
            //Memunculkan kembali object food Dan mengacak posisinya juga
            randomPosition(GO.transform);

            //Jika Food Menyentuh Player, Acak kembali posisi food tersebut
            while (Vector3.Distance(GO.transform.position, Player.transform.position) < Player.transform.localScale.x)
            {
                randomPosition(GO.transform);
            }
        }
        //Aktifkan script PlayerMoveToFood saat seluruh object food sudah dibuat
        //Agar player bergerak mendapatkan food satu-persatu
        Player.enabled = true;
    }

    //Menonaktifkan object food, dan memanggil method GetFood pada player object
    public void PlayerGetFood(GameObject food)
    {
        food.SetActive(false);

        //boolean get pada GetFood kita kirim nilai true
        //Karena method ini dipanggil saat player mendapatkan food
        Player.GetFood(scoreIndikator, true);

        //Memulai perhitungan untuk memunculkan kembali object food
        StartCoroutine(setActive(food));
    }

    private IEnumerator setActive(GameObject food)
    {
        yield return new WaitForSecondsRealtime(3f);

        //Memunculkan kembali object food Dan mengacak posisinya juga
        randomPosition(food.transform);

        //Jika Food Menyentuh Player, Acak kembali posisi food tersebut
        while (Vector3.Distance(food.transform.position, Player.transform.position) < Player.transform.localScale.x)
        {
            randomPosition(food.transform);
        }

        food.SetActive(true);

        //Pemanggilan fungsi ini agar object player kembali mengejar food
        Player.GetFood(scoreIndikator, false);
    }

    private void randomPosition(Transform food)
    {
        float posX = Random.Range(walls[3].position.x + 1, walls[1].position.x - 1);
        float posY = Random.Range(walls[2].position.y + 1, walls[0].position.y - 1);
        food.transform.position = new Vector3(posX, posY, 0);
    }
}