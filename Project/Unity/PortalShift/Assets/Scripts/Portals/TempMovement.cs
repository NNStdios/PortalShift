using System;
using UnityEngine;

namespace Portals
{
    public class TempMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        private void Update()
        {
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");
            _rb.velocity = new Vector2(x, y) * 10;
        }
    }
}
