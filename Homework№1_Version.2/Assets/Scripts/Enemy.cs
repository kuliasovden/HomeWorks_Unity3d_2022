using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;
    public Transform player;

    private int locationIndex = 0;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveNext();
    }

    private void Update()
    {
        if(agent.remainingDistance <0.2f && !agent.pathPending)
        {
            MoveNext();
        }
    }
    void InitializePatrolRoute()
    {
        foreach(Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveNext()
    {
        if (locations.Count == 0) return;
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    } 

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            agent.destination = player.position;
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
