using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private Transform[] walls;

    private void Start()
    {
        for (int i = Random.Range(0, 10); i>= 0; i--)
        {
            Debug.Log(i + 1);

            float posX = Random.Range(walls[3].position.x + 1, walls[1].position.x - 1);
            float posY = Random.Range(walls[2].position.y + 1, walls[0].position.y - 1);
            Vector3 foodPosition = new Vector3(posX, posY, 0);
            Instantiate(food, foodPosition, Quaternion.identity);
        }
    }
}