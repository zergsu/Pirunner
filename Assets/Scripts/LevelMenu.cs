using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public GameObject SettingsMenu, Menu;
    public bool canOpen = true;

	void Update()
    {
        if (!Menu.activeSelf && !SettingsMenu.activeSelf && GameManager.instance.gamePaused && canOpen) 
        {
            PauseGame();
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
        GameManager.instance.RestartLevel();
    }

    public void QuitLevel()
	{
        GameManager.instance.gamePaused = false;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
	}

    public void QuitGame()
    {
        Application.Quit();
    }
}
