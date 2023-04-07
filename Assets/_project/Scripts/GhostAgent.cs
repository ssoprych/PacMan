using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAgent : MonoBehaviour
{
    public Transform Player;
    public NavMeshAgent agent;
    private float _distanceRun = 4f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }
    void Update()
    {
        if (GameManager.Instance.ChaseMode == true)
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);

            if (distance < _distanceRun)
            {
                Vector3 dirToPlayer = transform.position - Player.transform.position;

                Vector3 newPos = transform.position + dirToPlayer;

                agent.SetDestination(newPos);
            }
        }
        else
        {
            agent.SetDestination(Player.position);
        }
    }




}
