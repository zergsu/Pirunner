using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishNavPath : MonoBehaviour
{
    [SerializeField] private Vector3 movePostionTransform;

    private NavMeshAgent navMeshAgent;

	private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        movePostionTransform = new Vector3(Random.Range(-20, 10), transform.position.y, Random.Range(-8, 223));
    }

    
    void Update()
    {
        navMeshAgent.destination = movePostionTransform;
        movePostionTransform.y = transform.position.y; //fixes a bug where it cant find the distance to change the distination

        if (Vector3.Distance(transform.position, movePostionTransform) < 0.001f || transform.position == movePostionTransform)
		{
            movePostionTransform = new Vector3(Random.Range(-20, 10), transform.position.y, Random.Range(-8, 223));
		}
    }
}
