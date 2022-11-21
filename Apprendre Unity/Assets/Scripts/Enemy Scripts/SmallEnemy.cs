using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour, IEnemy
{
    public Vector2 maxPosition;
    [Tooltip("should work better if negative")]
    public float yMinimum;
    public float colliderRadius;
    public float moveRate;
    public float moveSpeed;
    public float health;
    float currentHealth;
    float moveTimer;
    Vector2 targetPos;
    public GameObject reserverPrefab;
    CircleCollider2D reserverCol;

    void Start() {
        targetPos = transform.position;
        moveTimer = moveRate;
        currentHealth = health;
    }

    public void Damage(float amount) {
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
    }

    public void Die() {
        Destroy(reserverCol.gameObject);
        Destroy(gameObject);
    }

    public void Move() {
        moveTimer = moveRate;
        targetPos = GetValidRandomPos();
        if (targetPos == Vector2.zero) targetPos = transform.position;
    }

    private Vector2 GetValidRandomPos() {
        for (int i = 0; i < 5; i++) {
            Vector2 randomPos = new(Random.Range(-maxPosition.x, maxPosition.x), Random.Range(yMinimum, maxPosition.y));
            if (Physics2D.OverlapCircle(randomPos, colliderRadius) == null) {
                reserverCol = Instantiate(reserverPrefab, randomPos, Quaternion.identity).GetComponent<CircleCollider2D>();
                reserverCol.radius = colliderRadius;
                return randomPos;
            }
        }

        return Vector2.zero;
    }

    private void Update() {
        moveTimer -= Time.deltaTime;
        if (moveTimer <= 0) Move();
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);
    }
}
