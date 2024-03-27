using UnityEngine;

namespace Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameObject("Game Manager", typeof(GameManager)).GetComponent<GameManager>();
                return _instance;
            }
            private set
            {
                if (_instance != null && _instance != value)
                {
                    Destroy(value.gameObject);
                    return;
                }

                _instance = value;
            }
        }

        private void Awake() => _instance = GetComponent<GameManager>();

        private Camera _mainCam;
        public Camera MainCam => _mainCam = _mainCam == null ? Camera.main : _mainCam;
        
        private GameObject _player;
        public GameObject Player => _player = _player == null ? GameObject.FindGameObjectWithTag("Player") : _player;

        private LevelManager _levelManager;
        public LevelManager LevelManager => _levelManager == null ? GetComponent<LevelManager>() : _levelManager;
    }
}
