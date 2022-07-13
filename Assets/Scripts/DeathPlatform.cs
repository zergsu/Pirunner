using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlatform : MonoBehaviour
{

	private void OnCollisionEnter(Collision other)
	{
        if (other.gameObject.CompareTag("Player"))
		{
            GameManager.instance.playerDied = true;
            Debug.Log("Lost");
		}
	}
}
