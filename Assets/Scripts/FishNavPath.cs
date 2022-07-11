using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishNavPath : MonoBehaviour
{
    [SerializeField] private Vector3 movePostionTransform;


    [SerializeField] float minX = 20, maxX = 10;
    [SerializeField] float minZ = -8, maxZ = 223;

    private NavMeshAgent navMeshAgent;

	private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        ResetDestination();
    }

    
    void Update()
    {
        navMeshAgent.destination = movePostionTransform;
        movePostionTransform.y = transform.position.y; //fixes a bug where it cant find the distance to change the distination

        if (Vector3.Distance(transform.position, movePostionTransform) < 0.001f || transform.position == movePostionTransform)
		{
            ResetDestination();
        }
    }

    private void ResetDestination()
	{
        movePostionTransform = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
    }

    IEnumerator CheckPosition() // if the fish is stuck reset position and destination
	{
        Vector3 currentPos = transform.position;
        yield return new WaitForSeconds(0.1f);
        if (currentPos == transform.position)
		{
            transform.position += Vector3.up;

            ResetDestination();
        }
	}
}
