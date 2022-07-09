using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public GameObject Player;

    [SerializeField]
    float firstPos, secondPos;
    [SerializeField]
    float movingSpeed = -10f;

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
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject == Player)
		{
            Player.transform.parent = transform;
		}    
	}

	private void OnTriggerExit(Collider other)
	{
        Player.transform.parent = null;
	}
}
