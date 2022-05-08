using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;
    public Transform player;

    private int _locationIndex = 0;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveNext();
    }

    private void Update()
    {
        if(_agent.remainingDistance <0.2f && !_agent.pathPending)
        {
            MoveNext();
        }
    }
   private void InitializePatrolRoute()
    {
        foreach(Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

   private void MoveNext()
    {
        if (locations.Count == 0) return;
        _agent.destination = locations[_locationIndex].position;
        _locationIndex = (_locationIndex + 1) % locations.Count;
    } 

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            _agent.destination = player.position;
            Debug.Log("Enemy detected!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Resume patroling!");
        }
    }
}
