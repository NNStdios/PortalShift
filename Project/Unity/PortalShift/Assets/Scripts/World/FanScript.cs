using System;
using System.Collections.Generic;
using Scripts.Core;
using UnityEngine;

namespace Scripts.World
{
    public class FanScript : MonoBehaviour
    {
        [SerializeField] private float _force;

        private List<Rigidbody2D> _moveableObjects = new();
        private GameObject _player;

        private void Start() => _player = GameManager.Instance.Player;

        private void Update() => BlowPlayers();

        private void BlowPlayers()
        {
            foreach (var moveableObject in _moveableObjects)
            {
                moveableObject.AddForce(-transform.right * _force);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Rigidbody2D>(out var rb))
                _moveableObjects.Add(rb);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<Rigidbody2D>(out var rb))
                _moveableObjects.Remove(rb);
        }
    }
}
