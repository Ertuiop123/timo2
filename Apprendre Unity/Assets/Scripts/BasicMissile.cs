using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMissile : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    private void Start() {
        rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Boundaries")) {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy")) {

        }
    }
}
