using System;
using Scripts.Core;
using UnityEngine;

namespace Scripts.World
{
    public class LevelFinishScript : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Player"))
                GameManager.Instance.LevelManager.HandleLevelFinish();
        }
    }
}
