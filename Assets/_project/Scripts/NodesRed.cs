using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NodesRed : MonoBehaviour
{
    [SerializeField] private List<Vector3> Positions3 = new List<Vector3>();
    [SerializeField] private NavMeshAgent _agent;
    public Transform Player;
    private int _random3Int;
    private int _randomSecure3; // intiger to prevent situation that a new random number will be the same and the ghost wont move
    private float _distanceRun = 3.5f;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateUpAxis = false;
        _agent.updateRotation = false;
    }

    private void Start()
    {
        _random3Int = Random.Range(0, Positions3.Count);
        _randomSecure3 = _random3Int;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NodesRed"))
        {
            _random3Int = Random.Range(0, Positions3.Count);
            while (_random3Int == _randomSecure3)
            {
                _random3Int = Random.Range(0, Positions3.Count);
            }
            _randomSecure3 = _random3Int;
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
            else
            {
                _agent.SetDestination(Positions3[_random3Int]);
            }
        }
        else
        {
            _agent.SetDestination(Positions3[_random3Int]);
            float distance2 = Vector3.Distance(transform.position, Player.transform.position);

            if (distance2 < _distanceRun)
            {
                _agent.SetDestination(Player.position);
            }
        }

    }
}

