using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{

    [SerializeField] GameObject loseScreen;
    [SerializeField] Timer timer;

    [SerializeField] PlayerMovement player;

    public GameObject SettingsMenu, Menu;
    public bool canOpen;

    public Vector3 playerSpawn;

    private void Start()
	{
		if(SceneManager.GetActiveScene().buildIndex == 0)
		{
            canOpen = true;
		}
        else
		{
            canOpen = false;
		}
        playerSpawn = player.transform.position;
        
}

	void Update()
    {
        if (!Menu.activeSelf && !SettingsMenu.activeSelf && GameManager.instance.gamePaused && canOpen) 
        {
            Debug.Log(true);
            PauseGame();
        }
        if(GameManager.instance.playerDied)
		{
            Lose();
		}
    }


    public void PauseGame()
	{
        Time.timeScale = 0;
        Menu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
	{
        GameManager.instance.gamePaused = false;
        Time.timeScale = 1;
        Menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Settings()
	{
        SettingsMenu.SetActive(true);
        Menu.SetActive(false); 
	}

    public void BackToMenu()
	{
        SettingsMenu.SetActive(false);
        Menu.SetActive(true);
    }

    public void RestartLevel()
    {
        player.transform.position = playerSpawn;
        player.maxSpeed = player.moveSpeed; // resets the player bhop speed
        timer.ResetTime();
        loseScreen.SetActive(false);
        GameManager.instance.RestartLevel();
    }

    public void QuitLevel()
	{
        loseScreen.SetActive(false);
        GameManager.instance.playerDied = false;
        GameManager.instance.gamePaused = false;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
	}

    public void QuitGame()
    {
        Application.Quit();
    }


    private void Lose()
    {
        Time.timeScale = 0;
        loseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
