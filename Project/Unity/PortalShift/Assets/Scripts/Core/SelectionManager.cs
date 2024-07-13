using System;
using Scripts.Core;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private void Update()
    {
        Vector2 ray = GameManager.Instance.MainCam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (hit.transform == null)
                return;

            IPlaceable placeable = hit.transform.GetComponent<IPlaceable>();
            
            if (placeable != null)
                placeable.DestoryObject();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (hit.transform == null)
                return;

            IPlaceable placeable = hit.transform.GetComponent<IPlaceable>();
            
            if (placeable != null)
                placeable.Interact();
        }
        
    }
}
