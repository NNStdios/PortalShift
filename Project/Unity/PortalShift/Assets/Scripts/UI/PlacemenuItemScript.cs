using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlacemenuItemScript : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;

        private Vector3 _cursorPos;
        
        private GameObject _prefab;
        private GameObject _currentItem;

        private bool _placingItem;
        private bool _rotating;

        public void AssignInfo(string name, GameObject prefab)
        {
            _name.text = name;
            _prefab = prefab;
        }

        private void Start() => GetComponentInChildren<Button>().onClick.AddListener(SpawnItem);

        private void Update()
        {
            _cursorPos = Input.mousePosition;
            _cursorPos = GameManager.Instance.MainCam.ScreenToWorldPoint(_cursorPos);

            if (_placingItem)
            {
                if (_currentItem == null)
                    return;
                
                Vector3 rotationMousePos = _cursorPos;
                Vector3 direction = _cursorPos - _currentItem.transform.position;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                
                if (!_rotating)
                    _currentItem.transform.position = new Vector3(_cursorPos.x, _cursorPos.y, transform.position.z);

                if (_rotating)
                    _currentItem.transform.rotation = rotation;
                
                if (Input.GetKeyDown(KeyCode.Mouse0))
                    _placingItem = false;
                

                if (Input.GetKey(KeyCode.R))
                    _rotating = true;
                else
                    _rotating = false;
            }
        }

        public void DestoryObject(RaycastHit2D hit) => Destroy(hit.collider.gameObject);

        private void SpawnItem()
        {
            _currentItem =
                Instantiate(_prefab, _cursorPos, Quaternion.identity);
            _placingItem = true;
        }
    }
}
