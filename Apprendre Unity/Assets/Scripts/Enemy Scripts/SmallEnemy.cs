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
    public float moveRange;
    float currentHealth;
    float moveTimer;
    Vector2 targetPos;
    public GameObject reserverPrefab;
    CircleCollider2D reserverCol;

    void Start() {
        targetPos = transform.position;
        moveTimer = moveRate + Random.Range(-moveRate / 2, moveRate / 2);
        currentHealth = health;
    }

    public void Damage(float amount) {
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
    }

    public void Die() {
        if (reserverCol != null) Destroy(reserverCol.gameObject);
        Destroy(gameObject);
    }

    public void Move() {
        moveTimer = moveRate;
        targetPos = GetValidRandomPos();
    }

    private Vector2 GetValidRandomPos() {
        if (reserverCol != null) Destroy(reserverCol.gameObject);

        for (int i = 0; i < 5; i++) {
            Vector2 randomPos = new(Random.Range(-maxPosition.x, maxPosition.x), Random.Range(yMinimum, maxPosition.y));
            if ((randomPos - new Vector2(transform.position.x, transform.position.y)).SqrMagnitude() > moveRange)
                randomPos = (randomPos - new Vector2(transform.position.x, transform.position.y)).normalized * moveRange;

            // - error - it can hit itself and something else while only returning this which ignores the other collider
            Collider2D checkZone = Physics2D.OverlapCircle(randomPos, colliderRadius);

            if (checkZone == null || checkZone == this) {
                reserverCol = Instantiate(reserverPrefab, randomPos, Quaternion.identity).GetComponent<CircleCollider2D>();
                reserverCol.radius = colliderRadius;
                return randomPos;
            }
        }

        return transform.position;
    }

    private void Update() {
        moveTimer -= Time.deltaTime;
        if (moveTimer <= 0) Move();
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);
    }
}
