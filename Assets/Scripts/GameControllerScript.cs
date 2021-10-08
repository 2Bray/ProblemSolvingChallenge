using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    private static GameControllerScript _instance = null;

    public static GameControllerScript Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameControllerScript>();
            }

            return _instance;
        }
    }

    [SerializeField] Text scoreIndikator;
    [SerializeField] private GameObject gameOverUI;

    private int score;

    //Ukuran maksimal object Food
    public float maxSizeFood { get; private set; }

    //Waktu object food untuk di aktifkan kembali setelah dimakan player
    public float timeRespawn { get; private set; }

    //Besar Player Mengecil
    public float playerGoingSmall { get; private set; }

    //Besar nilai bagi player untuk membesar saat memakan object food
    public int playerGoingBig {get; private set; }



    private void Start()
    {
        //Inisiasi level awal
        Time.timeScale = 1f;
        score = 0;
        maxSizeFood = 2f;
        timeRespawn = 10f;
        playerGoingSmall = 0.2f;
        playerGoingBig = 10;
    }

    //Jika Player Memakan Food
    public void GetFood()
    {
        score++;
        scoreIndikator.text = "Score: " + score;

        // Tingkat Kesulitan Meningkat
        if (score > 40)
        {
            playerGoingSmall = 1f;
            maxSizeFood = 6f;
            timeRespawn = 16f;
            playerGoingBig = 40;
        }
        else if (score > 20)
        {
            playerGoingSmall = 0.2f;
            maxSizeFood = 4f;
            Camera.main.sensorSize += new Vector2(3, 3);
        }
    }

    public void clickRetry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void clickExit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
}
