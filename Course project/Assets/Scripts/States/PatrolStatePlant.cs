﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolStatePlant : StateMachineBehaviour
{
   private float _timer;
   private List<Transform> _wayPoints = new List<Transform>();
   private NavMeshAgent _agent;

   private Transform _player;
   private float _chaseRange = 15;

   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0;
        Transform wayPointsObject = GameObject.FindGameObjectWithTag("WayPointsPlant").transform;
        foreach(Transform trans in wayPointsObject)
        {
            _wayPoints.Add(trans);
        }

        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.SetDestination(_wayPoints[0].position);

        _player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _agent.SetDestination(_wayPoints[Random.Range(0, _wayPoints.Count)].position);
        }

        _timer += Time.deltaTime;
        if (_timer > 10)
        {
            animator.SetBool("isPatroling", false);
        }

        float distance = Vector3.Distance(animator.transform.position, _player.position);
        if(distance< _chaseRange)
        {
            animator.SetBool("isChasing", true);
        }

      }

override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }
}
