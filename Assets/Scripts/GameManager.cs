using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
		else
		{
			Destroy(gameObject);
		}
	}



    [Header("Refferences")]
    public Timer timer;
    public PlayerMovement player;
    public PlayerCam cam;

    [Header("Screens")]
    public GameObject settings;

    [Header("Var")]
    public bool playerDied;
    public bool playerWon;
    public bool gamePaused;


    void Start()
    {
        playerDied = false;
        playerWon = false;
        gamePaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused && !playerDied) 
		{
            gamePaused = true;
		}
    }



    public void RestartLevel()
    {
        playerDied = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

}
