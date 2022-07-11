using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPhysics : MonoBehaviour
{
    public PlayerMovement player;

    public Collider coll;

    [Header("Physics Materials")]
    public PhysicMaterial slip;
    public PhysicMaterial solid;

    void Start()
    {
        coll = GetComponent<Collider>();
    }

    void Update()
    {
        if (player.grounded)
        {
            coll.material = solid;
        }
        else coll.material = slip;
    }
}
