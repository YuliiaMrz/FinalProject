using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShip : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public int Dammage = 5;
    public bool playerInSightRange;
    public float sightRange;
    public LayerMask whatIsGround, whatIsPlayer;
    public bool canAttack;

    private void Start()
    {
        canAttack = true;
    }
    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange && canAttack)
        {
            ChasePlayer(); 
        }
        else
        {
            agent.SetDestination(this.transform.position);
        }
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canAttack = false;
            collision.gameObject.GetComponent<ShipController>().HealthCheck(10);
            Invoke(nameof(ResetCanAttack), 3);
        }

    }
    private void ResetCanAttack()
    {
        canAttack = true;
    }
}
