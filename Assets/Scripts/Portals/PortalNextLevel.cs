using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNextLevel : MonoBehaviour
{
    [SerializeField] GameObject twirlEffect;
    [SerializeField] GameObject particleEffect;
    [SerializeField] Timer timer;

    private void Start()
    {
        twirlEffect.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            twirlEffect.SetActive(true);
            particleEffect.SetActive(true);

            GameManager.instance.playerWon = true;
            
            Debug.Log(GameManager.instance.timer.gameTime);
            SaveData.CheckScore(GameManager.instance.timer.gameTime);
            SaveData.UnlockNextLevel();
        }
    }
}
