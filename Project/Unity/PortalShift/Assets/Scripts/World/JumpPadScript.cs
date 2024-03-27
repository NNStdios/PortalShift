using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadScript : MonoBehaviour
{
    [SerializeField] private Vector2 _force;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<Rigidbody2D>(out var rb)) 
            return;

        rb.velocity = Vector2.zero;
        rb.AddForce(_force, ForceMode2D.Impulse);
    }
}
