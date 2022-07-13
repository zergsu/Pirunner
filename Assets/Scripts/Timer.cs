using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [Header("Varuables")]
    public float resetedTime = 0;
    public float gameTime;
    public bool justStarted;

    [Header("Refferences")]
    public PlayerMovement player;


	private void Start()
	{
        justStarted = true;
	}

	void Update()
    {
        if(justStarted)
		{
            if (player.moving)
            {
                resetedTime = Time.time;
                justStarted = false;
            }
        }
        if(!GameManager.instance.playerDied || !GameManager.instance.playerWon)
		{
            gameTime = Time.time - resetedTime;
        }
    }

    public void ResetTime()
    {
        resetedTime = Time.time;
        justStarted = true;
    }
}
