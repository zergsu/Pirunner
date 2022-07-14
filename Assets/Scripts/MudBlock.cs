using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudBlock : MonoBehaviour
{

	[SerializeField] PlayerMovement player;

	float playerCurrentSpeed = 0;
	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			playerCurrentSpeed = player.moveSpeed;
			player.moveSpeed -= 2f;
			player.onMud = true;
		}
	}

	private void OnCollisionExit(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			player.moveSpeed = playerCurrentSpeed;
			player.onMud = false;
		}
	}
}
