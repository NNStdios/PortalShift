using System.Collections.Generic;
using Core;
using UnityEngine;

namespace World
{
    public class FanScript : MonoBehaviour
    {
        [SerializeField] private float _force;

        [SerializeField] private GameObject _popupMenu;

        private List<Rigidbody2D> _moveableObjects = new();
        private GameObject _player;
        private bool _popupMenuActive;

        private void Start() => _player = GameManager.Instance.Player;

        private void Update() => BlowPlayers();

        private void BlowPlayers()
        {
            foreach (var moveableObject in _moveableObjects)
                moveableObject.AddForce(-transform.right * _force);
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

        //TEMP TESTING IS IDEA FITS OR NOT
        public void ActivatePopupMenu()
        {
            if (_popupMenuActive)
            {
                _popupMenu.SetActive(true);
                _popupMenuActive = true;
            }
            else
            {
                _popupMenu.SetActive(false);
                _popupMenuActive = false;
            }
        }
    }
}
