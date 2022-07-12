using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
	public float jumperForce = 28f;

	private void OnCollisionEnter(Collision other)
	{
       PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
        player.OnJumper(jumperForce);
	}
}
