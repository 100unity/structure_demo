using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float lookRadius = 10f;
    
    private EnemyMovement movement;
    private Transform player;
    
    void Start()
    {
        player = PlayerManager.Instance.Player.transform;
    }
    
    void Update()
    {
        float distance = Vector3.Distance(movement.Target.position, transform.position);

        if (distance <= lookRadius)
        {
            movement.FollowTarget(player);
            /*
            if (distance <= agent.stoppingDistance)
            {
                //Attack
            }*/
        } /*else if (distance > x)
        {
            movement.StopFollowingTarget();
        }*/
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
