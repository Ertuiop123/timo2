using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public Animator animation;
    private float animationVariable;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A)))
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey(KeyCode.D)))
            {
                direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W)))
            {
                direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey(KeyCode.S)))
            {
                direction = 4;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                animation.SetBool("Dash", false);
            }
            else
            {
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    animation.SetBool("Dash", true);
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                    animation.SetBool("Dash", true);
                }
                else if (direction == 3)
                {
                    rb.velocity = Vector2.up * dashSpeed;
                    animation.SetBool("Dash", true);
                }
                else if (direction == 4)
                {
                    rb.velocity = Vector2.down * dashSpeed;
                    animation.SetBool("Dash", true);
                }
            }
        }
    }
}