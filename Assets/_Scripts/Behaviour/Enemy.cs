using System;
using UnityEngine;

namespace _Scripts.Behaviour {
  public class Enemy : MonoBehaviour {
    [SerializeField] private MoveTo _moveTo;

    private void OnTriggerEnter(Collider other) {
      if (other.CompareTag("Player")) {
        _moveTo.SetGoal(other.gameObject);
        _moveTo.Move();
      }
    }

    private void OnTriggerExit(Collider other) {
      if (other.CompareTag("Player")) {
        _moveTo.SetGoal(null);
      }
    }
  }
}