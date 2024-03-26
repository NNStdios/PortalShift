using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Core
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        private GameObject _player;
        private bool _isPlaying;

        private void Awake() => _playButton.onClick.AddListener(PlayLevel);

        private void Start() => _player = GameManager.Instance.Player;

        public void PlayLevel()
        {
            if (!_isPlaying)
            {
                _player.GetComponent<Rigidbody2D>().simulated = true;
                _playButton.image.color = Color.red;
                _isPlaying = true;
            }

            else
            {
                Rigidbody2D rb = _player.GetComponent<Rigidbody2D>();
                rb.simulated = false;
                rb.velocity = Vector3.zero;
                _player.transform.position = Vector3.zero;
                _playButton.image.color = Color.green;
                _isPlaying = false;
            }
        }
    }
}