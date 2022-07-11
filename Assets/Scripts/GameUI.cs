using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("Texts")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI playerSpeedText;

    [Header("Refferences")]
    public PlayerMovement player;
    public Timer timer;

   
    private Vector3 speedVec;
    private float speed;


    void Update()
    {
        VelocityCalculate();

        if (player.moving)
            playerSpeedText.text = "Speed: " + speed.ToString("F2");
        else
            playerSpeedText.text = "Speed: " + 0.ToString("F2");

        timerText.text = "Time: " + timer.gameTime.ToString("F2");
    }



    private void VelocityCalculate()
	{
        speedVec = player.rb.velocity;
        speedVec.y = 0;
        speed = speedVec.magnitude;
    }

}
