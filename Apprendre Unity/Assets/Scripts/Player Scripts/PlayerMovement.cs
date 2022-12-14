using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    [Range(0, .3f)] public float smoothMovementIntensity;

    float animationState = 0;
    public Animator animator;
    Rigidbody2D rb;
    Vector2 movements;
    Vector2 referenceVelocity;
    public ContactFilter2D mask;
    public GameObject shop;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        GetInputs();
        SetAnimationParamaters();
    }

    private void SetAnimationParamaters() {
        // animationState = Mathf.SmoothDamp(animationState, targetStateValue, ref currentAnimationState, smoothMovementIntensity);
        animator.SetFloat("state", animationState);

    }

    void GetInputs() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        animationState = x;

        movements = new Vector2(x, y).normalized * Time.fixedDeltaTime * speed * 100;

        if (Input.GetKeyDown(KeyCode.I))
        {
            shop.SetActive(!shop.activeSelf);
        }

    }

    void Move() {
        Vector2 targetVelocity = movements;

        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref referenceVelocity, smoothMovementIntensity);
    }
    void FixedUpdate()
    {
        Move();
    }
}
