using System.Collections;
using Core;
using UnityEngine;
using NnUtils.Scripts;

namespace World
{
    public class SelectionManager : MonoBehaviour
    {
        [SerializeField] private float _maxPosDelta;

        private void Update()
        {
            if (Clicked()) HandleClicked();
        }

        private bool Clicked() =>
            !Misc.IsPointerOverUI &&
            Input.GetKeyDown(KeyCode.Mouse0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);

        private bool Released() =>
            Input.GetKeyUp(KeyCode.Mouse0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended);
        
        private void HandleClicked() =>
            Misc.RestartCoroutine(this, ref _handleClickedRoutine,
                HandleClickedRoutine(GameManager.Instance.MainCam.ScreenToWorldPoint(Misc.GetPointerPos())));
        private Coroutine _handleClickedRoutine;
        private IEnumerator HandleClickedRoutine(Vector2 startPointerPos)
        {
            while (true)
            {
                if (Released()) break;
                Vector2 pos = GameManager.Instance.MainCam.ScreenToWorldPoint( Misc.GetPointerPos());
                var delta = Vector2.Distance(startPointerPos, pos);
                if (delta > _maxPosDelta) Debug.Log("Over delta");
                yield return null;
            }
            _handleClickedRoutine = null;
        }
    }
}