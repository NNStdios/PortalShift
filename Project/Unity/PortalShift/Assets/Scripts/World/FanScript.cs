using System;
using Scripts.Core;
using UnityEngine;

namespace Scripts.World
{
    public class FanScript : MonoBehaviour
    {
        [SerializeField] private float _force;
        [SerializeField] private float _blowDistance;

        private GameObject _player;

        private void Start() => _player = GameManager.Instance.Player;

        private void Update() => BlowPlayer();

        private void BlowPlayer()
        {
            Vector2 distance = _player.transform.position - transform.position;
            
            if (distance.x < _blowDistance)
                _player.GetComponent<Rigidbody2D>().AddForce(Vector3.left * _force);
        }
    }
}
