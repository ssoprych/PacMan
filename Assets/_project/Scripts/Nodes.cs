using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nodes : MonoBehaviour
{
    public List<Vector3> Positions = new List<Vector3>();
    [SerializeField] private NavMeshAgent _agent;
    public int _randomInt;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _randomInt = Random.Range(0, Positions.Count);
    }

    private void Update()
    {
        _agent.SetDestination(Positions[_randomInt]);
    }
}
