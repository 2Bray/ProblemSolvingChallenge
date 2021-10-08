using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodControllerGameScript : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private Transform[] walls;
    [SerializeField] private Transform Player;
    [SerializeField] private Text scoreIndikator;
    
    private GameControllerScript GCS;
    private AudioSource sound;

    private void Start()
    {
        //Init
        GCS = GameControllerScript.Instance;
        sound = GetComponent<AudioSource>();
        scoreIndikator.text = "Score: ";


        //Membuat satu-persatu object food
        for (int i = 0; i < 10; i++)
        {
            GameObject GO = Instantiate(food);
            GO.GetComponent<FoodInGameScript>().foodControl = this;
            GO.GetComponent<FoodInGameScript>().idx = i;

            FoodFactory(GO.transform);
        }
    }

    private void FoodFactory(Transform food)
    {
        //Mengacak posisi object food
        float posX = Random.Range(walls[3].position.x + 1, walls[1].position.x - 1);
        float posY = Random.Range(walls[2].position.y + 1, walls[0].position.y - 1);
        food.position = new Vector3(posX, posY, 0);

        //Mengacak Besar Object Food
        float scale = Random.Range(0.5f,GCS.maxSizeFood);
        food.localScale = new Vector2(scale, scale);
    }

    //Menonaktifkan object food, dan memanggil method GetFood pada player object
    public void PlayerGetFood(GameObject food)
    {
        sound.Play();

        food.SetActive(false);
        GCS.GetFood();

        //Memulai perhitungan untuk memunculkan kembali object food
        StartCoroutine(setActive(food));
    }

    public IEnumerator setActive(GameObject food)
    {
        food.SetActive(false);
        yield return new WaitForSecondsRealtime(GCS.timeRespawn);

        //Memunculkan kembali object food Dan mengacaknya lagi;
        FoodFactory(food.transform);
        while (Vector3.Distance(food.transform.position, Player.position) < Player.localScale.x + 3)
            FoodFactory(food.transform);
        food.SetActive(true);
    }
}