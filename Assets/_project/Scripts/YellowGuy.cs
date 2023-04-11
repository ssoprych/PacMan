using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class YellowGuy : MonoBehaviour
{
    [SerializeField] private List<Vector3> Positions4 = new List<Vector3>();
    [SerializeField] private NavMeshAgent _agent;
    public Transform Player;
    private int _random4Int;
    private int _randomSecure4; // intiger to prevent situation that a new random number will be the same and the ghost wont move
    private float _distanceRun = 3.5f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateUpAxis = false;
        _agent.updateRotation = false;
    }

    private void Start()
    {
        _random4Int = Random.Range(0, Positions4.Count);
        _randomSecure4 = _random4Int;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NodesYellow"))
        {
            _random4Int = Random.Range(0, Positions4.Count);
            while (_random4Int == _randomSecure4)
            {
                _random4Int = Random.Range(0, Positions4.Count);
            }
            _randomSecure4 = _random4Int;
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
                _agent.SetDestination(Positions4[_random4Int]);
            }
        }
        else
        {
            _agent.SetDestination(Positions4[_random4Int]);
            float distance2 = Vector3.Distance(transform.position, Player.transform.position);

            if (distance2 < _distanceRun)
            {
                _agent.SetDestination(Player.position);
            }
        }
    }
}

