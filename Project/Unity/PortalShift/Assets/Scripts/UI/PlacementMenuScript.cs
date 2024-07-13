using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class PlacementMenuScript : MonoBehaviour
    {
        [System.Serializable]
        public struct PlaceableItem
        {
            public string Name;
            public GameObject Prefab;
        }

        [SerializeField] private List<PlaceableItem> _placeableItems;
        [SerializeField] private PlacemenuItemScript _placemenuItemPrefab;
        [SerializeField] private Transform _placeMenuUI;

        private void Start()
        {
            foreach (var item in _placeableItems)
            {
                var menuItem =
                    Instantiate(_placemenuItemPrefab, _placeMenuUI);
                menuItem.AssignInfo(item.Name, item.Prefab);
            }
        }
    }
}
