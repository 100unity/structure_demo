using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movable : MonoBehaviour
{
    [SerializeField] protected float rotationSpeed;

    public Transform Target { get; set; }
    protected NavMeshAgent agent;

    protected void FaceTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    protected void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public virtual void FollowTarget(Object newTarget)
    {

    }

    public virtual void StopFollowingTarget()
    {

    }
}
