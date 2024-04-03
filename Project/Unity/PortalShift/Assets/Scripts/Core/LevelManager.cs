using System.Collections.Generic;
using Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private List<GameObject> _levels;

        [SerializeField] private Button _restartButton;
        [SerializeField] private GameObject _placementUI;
        
        //TEMP
        [SerializeField] private GameObject _finishMenu;

        private GameObject _player;
        private bool _isPlaying;
        private int _currentLevelIndex;

        private void Awake() => BindButtons();

        private void Start() => _player = GameManager.Instance.Player;

        private void BindButtons()
        {
            _playButton.onClick.AddListener(PlayLevel);
            _restartButton.onClick.AddListener(RestartLevel);
        }
        
        public void PlayLevel()
        {
            if (!_isPlaying)
            {
                _player.GetComponent<Rigidbody2D>().simulated = true;
                _playButton.image.color = Color.red;
                _placementUI.SetActive(false);
                _isPlaying = true;
            }

            else
            {
                var rb = _player.GetComponent<Rigidbody2D>();
                rb.simulated = false;
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0;
                _player.transform.position = Vector3.zero;
                _player.transform.rotation = Quaternion.Euler(Vector3.zero);
                _playButton.image.color = Color.green;
                _placementUI.SetActive(true);
                _isPlaying = false;
            }
        }

        public void HandleLevelFinish()
        {
            _finishMenu.SetActive(true);
        }

        public void NextLevel()
        {
            _currentLevelIndex++;

            foreach (var level in _levels)
                level.SetActive(false);

            _levels[_currentLevelIndex].SetActive(true);
            PlayLevel();
        }

        public void RestartLevel()
        {
            PlayLevel();
            _finishMenu.SetActive(false);
        }
    }
}
