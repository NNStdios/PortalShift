using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class JumpPadScript : MonoBehaviour
{
    public float jumpForce = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<Rigidbody2D>(out var rb)) 
            return;

        rb.velocity = Vector2.zero;

        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

    }

}
 