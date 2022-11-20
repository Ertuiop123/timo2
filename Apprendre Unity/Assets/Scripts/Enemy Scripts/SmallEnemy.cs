using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour, IEnemy
{
    public Vector2 maxPosition;
    public float colliderRadius;
    public float moveRate;
    float moveTimer;
    Vector2 targetPos;
    public Rigidbody2D rb;
    public float moveSpeed;

    void Start() {
        moveTimer = moveRate;
    }

    public void Damage() {

    }

    public void Move() {
        moveTimer = moveRate;
        targetPos = GetValidRandomPos();
        if (targetPos == Vector2.zero) return;
    }

    private Vector2 GetValidRandomPos() {
        for (int i = 0; i < 5; i++) {
            Vector2 randomPos = new(Random.Range(-maxPosition.x, maxPosition.x), Random.Range(-maxPosition.y, maxPosition.y));
            if (Physics2D.OverlapCircle(randomPos, colliderRadius) == null) return randomPos;
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
