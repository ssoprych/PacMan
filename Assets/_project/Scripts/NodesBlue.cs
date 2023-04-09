using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NodesBlue : MonoBehaviour
{
    [SerializeField] private List<Vector3> Positions2 = new List<Vector3>();
    [SerializeField] private NavMeshAgent _agent;
    public Transform Player;
    private int _random2Int;
    private float _distanceRun = 2f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateUpAxis = false;
        _agent.updateRotation = false;
    }

    private void Start()
    {
        _random2Int = Random.Range(0, Positions2.Count);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NodesBlue"))
        {
            _random2Int = Random.Range(0, Positions2.Count);
        }
    }

    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("PagMan").transform;
        if (GameManager.Instance.ChaseMode == true)
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);

            if (distance < _distanceRun)
            {
                Vector3 dirToPlayer = transform.position - Player.transform.position;

                Vector3 newPos = transform.position + dirToPlayer;

                _agent.SetDestination(newPos);
            }
        }
        else
        {
            _agent.SetDestination(Positions2[_random2Int]);
        }

    }
}

