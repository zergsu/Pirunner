using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Refferences")]
    public Timer timer;
    public PlayerMovement player;

    [Header("Screens")]
    public GameObject loseScreen;
    public GameObject menu;

    public bool playerDied;

    void Start()
    {
        playerDied = false;
    }

    void Update()
    {
        if(playerDied)
		{
            //Lose();
		}
    }



    public void RestartGame()
	{
        timer.ResetTime();
	}

    private void Lose()
	{
        loseScreen.SetActive(true);
	}

}
