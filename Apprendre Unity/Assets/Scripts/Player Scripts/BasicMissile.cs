using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicMissile : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float damage;
    public float lifeTime = 3f;

    private void Start() {
        rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);

        StartCoroutine(WaitThenDie());
    }

    IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Boundaries")) {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy")) {
            IEnemy enemy = collision.gameObject.GetComponent<IEnemy>();
            if (enemy != null) enemy.Damage(damage);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Boundaries")) {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy")) {
            IEnemy enemy = collision.gameObject.GetComponent<IEnemy>();
            if (enemy != null) enemy.Damage(damage);
            Destroy(gameObject);
        }
    }


}
