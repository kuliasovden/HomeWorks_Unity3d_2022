using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestObject : MonoBehaviour
{
   [SerializeField] private Transform _patrolRoute;
   [SerializeField] private List<Transform> _locations;   

    private int _locationIndex = 0;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();
        MoveNext();
    }

    private void Update()
    {
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveNext();
        }
    }
    private void InitializePatrolRoute()
    {
        foreach (Transform child in _patrolRoute)
        {
            _locations.Add(child);
        }
    }

    private void MoveNext()
    {
        if (_locations.Count == 0) return;
        _agent.destination = _locations[_locationIndex].position;
        _locationIndex = (_locationIndex + 1) % _locations.Count;
    }
}
