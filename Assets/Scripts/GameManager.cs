using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Header("Refferences")]
    public Timer timer;
    public PlayerMovement player;
    public PlayerCam cam;

    [Header("Screens")]
    public GameObject loseScreen;
    public GameObject settings;

    public bool playerDied;
    public bool playerWon;

    public Vector3 playerSpawn;

    void Start()
    {
        playerDied = false;
        playerWon = false;
        playerSpawn = player.transform.position;
    }

    void Update()
    {
        if(playerDied)
		{
            Lose();
        }
        if(playerWon)
		{

        if (Input.GetKeyDown(KeyCode.G))
            Settings();
		}
    }



    public void RestartLevel()
	{
        timer.ResetTime();
        player.transform.position = playerSpawn;
        player.maxSpeed = player.moveSpeed; // resets the player bhop speed
        playerDied = false;
    }

    public void BackToMenu()
	{
        SceneManager.LoadScene(0);
	}

    private void Lose()
	{
        loseScreen.SetActive(true);
	}

    void Settings()
    {
        settings.SetActive(!settings.activeInHierarchy);
    }
}
