using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Refferences")]
    public Timer timer;
    public PlayerMovement player;
    public PlayerCam cam;

    [Header("Screens")]
    public GameObject loseScreen;
    public GameObject settings;

    public bool playerDied;

    public Vector3 playerSpawn;

    void Start()
    {
        playerDied = false;
        playerSpawn = player.transform.position;
    }

    void Update()
    {
        if(playerDied)
		{
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.G))
            Settings();
    }



    public void RestartGame()
	{
        timer.ResetTime();
        player.transform.position = playerSpawn;
        playerDied = false;
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
