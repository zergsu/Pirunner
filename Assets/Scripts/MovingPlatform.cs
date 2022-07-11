using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public GameObject PlayerModel;
    public GameObject PlayerPos;
    public PlayerMovement Player;

    public bool playerOnPlatform = false;
    public bool connected = false;

    [Header("Positions")]

    [SerializeField]
    private float firstPos, secondPos;
    [SerializeField]
    private float movingSpeed = -10f;

    bool movingPos = true; //fixes the platform bugging on the same position on the x axis

	void Update()
    {

        transform.position += new Vector3(movingSpeed * Time.deltaTime, 0, 0);

        if(movingPos)
		{
            if (transform.position.x <= secondPos)
            {
                movingSpeed *= -1;
                movingPos = false;
            }
        }

        if(!movingPos)
		{
            if (transform.position.x >= firstPos)
            {
                movingSpeed *= -1;
                movingPos = true;
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
                PlayerPos.transform.parent = null;
            }
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
}
