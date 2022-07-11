using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlatform : MonoBehaviour
{

    public GameManager gameManager;
    
	private void OnCollisionEnter(Collision other)
	{
        if (other.gameObject.CompareTag("Player"))
		{
            gameManager.playerDied = true;
            Debug.Log("Lost");
		}
	}
}
