using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public GameObject PlayerModel;
    public GameObject PlayerPos;
    public PlayerMovement Player;
    public GameManager gameManager;


    public bool playerOnPlatform = false;
    public bool connected = false;

    [SerializeField] private float movingSpeed = -10f;

    [Header("Direction")]
    [SerializeField] private bool Z = false;
    [SerializeField] private bool X = true;

    [Header("Positions")]
    [SerializeField] private float firstPos, secondPos;

    

    bool movingPos = true; //fixes the platform bugging on the same position on the x axis

	void Update()
	{
		if (X)
		{
			transform.position += new Vector3(movingSpeed * Time.deltaTime, 0, 0);

            if (movingPos)
            {
                if (transform.position.x <= secondPos)
                {
                    movingSpeed *= -1;
                    movingPos = false;
                }
            }

            if (!movingPos)
            {
                if (transform.position.x >= firstPos)
                {
                    movingSpeed *= -1;
                    movingPos = true;
                }
            }
        }
        else if(Z)
		{
            transform.position += new Vector3(0, 0, movingSpeed * Time.deltaTime);

            if (movingPos)
            {
                if (transform.position.z <= secondPos)
                {
                    movingSpeed *= -1;
                    movingPos = false;
                }
            }

            if (!movingPos)
            {
                if (transform.position.z >= firstPos)
                {
                    movingSpeed *= -1;
                    movingPos = true;
                }
            }
        }
		



        if (Input.GetKeyDown(Player.jumpKey) && Player.onMovingPlatform)
        {
            Player.onMovingPlatform = false;
            PlayerPos.transform.parent = null;
        }

        if (playerOnPlatform)
		{
            if(!Player.moving)
			{
                PlayerPos.transform.parent = transform;
                connected = true;
            }
            else if(Player.moving && connected)
			{
                ResetPlayer();
            }
        }

        if(gameManager.playerDied)
		{
            ResetPlayer();
        }
    }


    
	private void OnTriggerEnter(Collider other)
	{
        playerOnPlatform = true;
    }

	private void OnTriggerExit(Collider other)
	{
        playerOnPlatform = false;
    }


    public void ResetPlayer()
	{
        PlayerPos.transform.parent = null;
    }
}
