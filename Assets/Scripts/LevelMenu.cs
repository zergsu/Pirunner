using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public GameObject SettingsMenu, Menu;

    void Update()
    {
        if (GameManager.instance.gamePaused)
		{
			Time.timeScale = 0;
			Menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ResumeGame()
	{
        Menu.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Settings()
	{
        Menu.SetActive(false);
        SettingsMenu.SetActive(true);
	}

    public void BackToMenu()
	{
        SettingsMenu.SetActive(false);
        Menu.SetActive(true);
    }

    public void QuitLevel()
	{
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
	}
}
