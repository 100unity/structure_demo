using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : Movable
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

    public override void FollowTarget(Object newTarget)
    {
        // bad because runtime errors
        Interactable newInteractableTarget = (Interactable)newTarget;
        // stop at radius
        agent.stoppingDistance = newInteractableTarget.Radius * .8f;
        agent.updateRotation = false;
        Target = newInteractableTarget.InteractionTransform;
    }

    public override void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        Target = null;
    }
}
