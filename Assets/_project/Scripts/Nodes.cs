using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nodes : MonoBehaviour
{
    [SerializeField] private List<Vector3> Positions = new List<Vector3>();
    [SerializeField] private NavMeshAgent _agent;
    public Transform Player;
    private int _randomSecure; // intiger to prevent situation that a new random number will be the same and the ghost wont move
    private int _randomInt;
    private float _distanceRun = 3.5f;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateUpAxis = false;
        _agent.updateRotation = false;
    }

    private void Start()
    {
        _randomInt = Random.Range(0, Positions.Count);
        _randomSecure = _randomInt;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NodesGreen"))
        {
            _randomInt = Random.Range(0, Positions.Count);
            while (_randomInt == _randomSecure)
            {
                _randomInt = Random.Range(0, Positions.Count);
            }
            _randomSecure = _randomInt;
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
                _agent.SetDestination(Positions[_randomInt]);
            }
        }
        else
        {
            _agent.SetDestination(Positions[_randomInt]);
            float distance2 = Vector3.Distance(transform.position, Player.transform.position);

            if (distance2 < _distanceRun)
            {
                _agent.SetDestination(Player.position);
            }
        }
        
    }
}
