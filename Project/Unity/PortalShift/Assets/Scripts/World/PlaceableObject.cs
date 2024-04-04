using Core;
using UnityEngine;

namespace World
{
    public class PlaceableObject : MonoBehaviour, ISelectable
    {
        public void PointerEnter()
        {
            Debug.Log("Enter");
        }

        public void PointerExit()
        {
            Debug.Log("Exit");
        }

        public void PointerDown()
        {
            Debug.Log("Down");
        }

        public void Pointer()
        {
            Debug.Log("Pointer");
        }
        
        public void PointerUp()
        {
            Debug.Log("Up");
            GameManager.Instance.SelectionManager.SelectedObject = gameObject;
        }

        public void Select()
        {
            Debug.Log("Select");
        }

        public void Deselect()
        {
            Debug.Log("Deselect");
        }
    }
}