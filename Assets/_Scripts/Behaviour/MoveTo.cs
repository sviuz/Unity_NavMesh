using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Behaviour {
  public class MoveTo : MonoBehaviour {
    [SerializeField]
    private Transform _goal;

    private Animator _animator;
    private NavMeshAgent _agent;

    private void Awake() {
      _agent = GetComponent<NavMeshAgent>();
      _animator = GetComponent<Animator>();
    }

    public void SetGoal(GameObject gameObject) {
      _goal = gameObject.transform;
    }

    public void Move() {
      if (_goal == null) {
        return;
      }

      _animator.SetBool("Run", true);
      _agent.SetDestination(_goal.position);
      StartCoroutine(StartChecking());
    }

    private IEnumerator StartChecking() {
      yield return new WaitUntil(() => _agent.remainingDistance <= _agent.stoppingDistance);
      _animator.SetBool("Run", false);
    }
  }
}