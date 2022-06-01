using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts {
  public class MoveTo : MonoBehaviour {
    [SerializeField]
    private Transform _goal;

    private Animator _animator;
    private NavMeshAgent _agent;

    private void Awake() {
      _agent = GetComponent<NavMeshAgent>();
      _animator = GetComponent<Animator>();
      _agent.SetDestination(_goal.position);
      _animator.SetBool("Run", true);
      _agent.SetDestination(_goal.position);
    }

    /*private IEnumerator Running() {
      while (true) {
        
      }
    }*/

    private void Update() {
      if (_agent.remainingDistance >= _agent.stoppingDistance) {
        _animator.SetBool("Run", true);
        _agent.destination = _goal.position;
      } else {
        _animator.SetBool("Run", false);
      }
    }
  }
}