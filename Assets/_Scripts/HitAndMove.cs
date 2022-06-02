using System;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts {
  public class HitAndMove : MonoBehaviour {
    [SerializeField]
    private GameObject _targetParticle;

    [SerializeField] private Camera _camera;

    [SerializeField] private LayerMask _layerMask;
    
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
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit, 100)) return;
        if (!hit.collider.CompareTag("Walkable")) return;

        Debug.Log("Hit");
        _animator.SetBool("Run", true);
        _agent.SetDestination(hit.point);
        var pos = new Vector3(hit.point.x, 0.1f, hit.point.z);
        // Instantiate(_targetParticle, pos,transform.rotation * Quaternion.Euler (-90f, 0, 0f));
        distance = Vector3.Distance(transform.position, hit.point);
        minDistance = distance / 20;
        moving = true;
      }

      if (!_agent.hasPath) return;
      
      if (_agent.remainingDistance <= minDistance && _agent.remainingDistance >0  && moving) {
        _animator.SetBool("Run", false);
        moving = false;
      }
    }
  }
}