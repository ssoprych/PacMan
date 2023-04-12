using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedGuy : MonoBehaviour
{
    public Transform Player;
    [SerializeField] private NavMeshAgent _agent;
    private float _distanceRun = 3.5f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateUpAxis = false;
        _agent.updateRotation = false;
    }

    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("PagMan").transform;
        _agent.SetDestination(Player.position);
        if (GameManager.Instance.ChaseMode == true)
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);

            if (distance < _distanceRun)
            {
                Vector3 dirToPlayer = transform.position - Player.transform.position;

                Vector3 newPos = transform.position + dirToPlayer;

                _agent.SetDestination(newPos);
            }
            else
            {
                _agent.SetDestination(Player.position);
            }
        }
        else
        {
            _agent.SetDestination(Player.position);

        }
    }



}
