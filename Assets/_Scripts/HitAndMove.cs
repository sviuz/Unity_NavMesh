using System;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts {
  public class HitAndMove : MonoBehaviour {
    [SerializeField]
    private GameObject _targetParticle;
    private NavMeshAgent _agent;
    private Animator _animator;
    private float distance;
    private float minDistance;
    private bool moving;
    private void Awake() {
      _agent = GetComponent<NavMeshAgent>();
      _animator = GetComponent<Animator>();
    }

    private void Update() {
      if (Input.GetMouseButtonUp(0)) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit, 100)) return;
        if (!hit.collider.CompareTag("Walkable")) return;

        Debug.Log(hit.transform.name);
        _animator.SetBool("Run", true);
        _agent.SetDestination(hit.point);
        var pos = new Vector3(hit.point.x, 0.1f, hit.point.z);
        Instantiate(_targetParticle, pos,transform.rotation * Quaternion.Euler (-90f, 0, 0f));
        distance = Vector3.Distance(transform.position, hit.point);
        minDistance = distance / 20;
        moving = true;
      }
      
      if (_agent.remainingDistance <= minDistance && _agent.remainingDistance >0  && moving) {
        Debug.Log(_agent.remainingDistance.ToString());
        Debug.Log("WaDWAD");
        _animator.SetBool("Run", false);
        moving = false;
      }
    }
  }
}