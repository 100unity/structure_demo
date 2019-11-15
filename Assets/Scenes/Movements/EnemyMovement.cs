using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : Movable
{
    void Start()
    {
        // set all values in inspector later!!!
        rotationSpeed = 5f;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Target != null)
        {
            agent.SetDestination(Target.position);
            FaceTarget(Target);
        }
    }

    // maybe move to movable
    /*public void SetTarget (Transform target)
    {
        this.Target = target;
    }*/

    public override void FollowTarget(Object newTarget)
    {
        // bad because runtime errors
        Transform newTransformTarget = (Transform)newTarget;
        agent.updateRotation = false;
        Target = newTransformTarget;
    }

    public override void StopFollowingTarget()
    {
        agent.updateRotation = true;
        Target = null;
    }
}
