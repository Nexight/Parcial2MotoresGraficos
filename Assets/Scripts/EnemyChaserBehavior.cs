using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaserBehavior : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointrRange;

    //Attacking 
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //Estados
    public float rangoVision, RangoAtaque;
    public bool playerALaVista, playerEnRangoAtaque;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //chequear que el player esta en rango de vision o ataque
        playerALaVista = Physics.CheckSphere(transform.position, rangoVision, whatIsPlayer);
        playerEnRangoAtaque = Physics.CheckSphere(transform.position, RangoAtaque, whatIsPlayer);

        if (!playerALaVista && !playerEnRangoAtaque) Patroling();
        if (playerALaVista && !playerEnRangoAtaque) ChasePlayer();
        if (playerEnRangoAtaque && playerALaVista) AttackPlayer();

    }

    private void Patroling()
    {

    }
    private void ChasePlayer()
    {

    }
    private void AttackPlayer ()
    {

    }



}
