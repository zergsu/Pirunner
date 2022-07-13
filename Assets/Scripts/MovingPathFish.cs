using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPathFish : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1f;

    Vector3 targetPos;

	private void Start()
	{
        targetPos.y = transform.position.y;
        targetPos.x = Random.Range(-20, 11);
        targetPos.z = Random.Range(-2, 218);
    }
	void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.001f) 
		{
            targetPos.x = Random.Range(-20, 11);
            targetPos.z = Random.Range(-2, 218);
        }
    }
}
