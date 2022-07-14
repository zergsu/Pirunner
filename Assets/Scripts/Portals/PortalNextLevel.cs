using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNextLevel : MonoBehaviour
{
    [SerializeField] GameObject twirlEffect;
    [SerializeField] GameObject particleEffect;
    [SerializeField] Timer timer;

    [SerializeField] AudioClip victorySound;

    private bool notPlayedSound;

    private void Start()
    {
        twirlEffect.SetActive(false);
        notPlayedSound = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            twirlEffect.SetActive(true);
            particleEffect.SetActive(true);

            GameManager.instance.playerWon = true;
            if(notPlayedSound)
			{
                SoundManager.instance.PlaySound(victorySound);
                notPlayedSound = false;
                SoundManager.instance.musicSource.Stop();
			}
            SaveData.CheckScore(timer.gameTime);
            SaveData.UnlockNextLevel();
        }
    }
}
