using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("Texts")]
    public TextMeshProUGUI timerText;

    [Header("Refferences")]
    public Timer timer;


    void Update()
    {
        if(!GameManager.instance.playerDied || !GameManager.instance.playerWon)
		{
            timerText.text = "Time: " + timer.gameTime.ToString("F2");
        }
    }
}
