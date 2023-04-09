using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nodes : MonoBehaviour
{
    public List<Vector3> Positions = new List<Vector3>();
    [SerializeField] private NavMeshAgent _agent;
    public Transform Player;
    public int _randomInt;
    private float _distanceRun = 2f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateUpAxis = false;
        _agent.updateRotation = false;
    }

    private void Start()
    {
        _randomInt = Random.Range(0, Positions.Count);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NodesGreen"))
        {
            _randomInt = Random.Range(0, Positions.Count);
            Debug.Log("LOOOL");
        }
    }

    private void Update()
    {
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
            _agent.SetDestination(Positions[_randomInt]);
        }
        
    }
}
