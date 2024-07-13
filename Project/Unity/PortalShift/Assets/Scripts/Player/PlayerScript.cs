using System;
using System.Collections;
using Scripts.Core;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerScript : MonoBehaviour
    {
        [SerializeField] private float _restartLevelTime;
        [SerializeField] private ParticleSystem _restartParticles;

        private LevelManager _levelManager;

        private void Start() => _levelManager = GameManager.Instance.LevelManager;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Obsticle"))
                if (!_levelManager.PlayerDestoryed)
                    RestartLevelCoroutine = StartCoroutine(RestartLevelRoutine());
        }

        public Coroutine RestartLevelCoroutine;
        private IEnumerator RestartLevelRoutine()
        {
            _levelManager.PlayerDestoryed = true;
            Instantiate(_restartParticles, transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(_restartLevelTime);
            _levelManager.RestartLevel();
            _levelManager.PlayerDestoryed = false;
        }
    }
}
