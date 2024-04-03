using System.Collections;
using UnityEngine;
using NnUtils.Scripts;

namespace World
{
    public class SelectionManager : MonoBehaviour
    {
        [SerializeField] private float _maxPosDelta;

        private void Update()
        {

        }

        private bool Clicked() =>
            Input.GetKeyDown(KeyCode.Mouse0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);
        
        private void HandleClicked()
        {
            _handleClickedRoutine = StartCoroutine(HandleClickedRoutine(Misc.GetCursorPos()));
        }
        private Coroutine _handleClickedRoutine;
        private IEnumerator HandleClickedRoutine(Vector2 _startCursorPos)
        {
            yield return null;
        }
    }
}