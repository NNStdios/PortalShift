using UnityEngine;

public class PlaceableObjectScript : MonoBehaviour, IPlaceable
{
    [SerializeField] private GameObject _interactionUI;

    private bool _interactionUIEnabled;
    
    public void DestoryObject()
    {
        Destroy(gameObject);
    }

    public void Interact()
    {
        if (_interactionUI != null)
            if (!_interactionUIEnabled)
                SetInteractionUI(true);
            else
                SetInteractionUI(false);
    }

    private void SetInteractionUI(bool state)
    {
        _interactionUI.SetActive(state);
        _interactionUIEnabled = state;
    }
}
