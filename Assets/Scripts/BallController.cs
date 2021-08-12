using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float Speed = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.5f, 1.0f).normalized * Speed;
    }

    void FixedUpdate()
    {
        if (Math.Abs(rb.velocity.x) < 0.1f)
        {
            rb.velocity = new Vector2(rb.velocity.x + 0.5f, rb.velocity.y).normalized * Speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // normal -> direction of collision to the ball
        Vector2 normal = collision.collider.Distance(GetComponent<Collider2D>()).normal;
        Vector2 newDirection;

        if (Math.Abs(normal.y) > Math.Abs(normal.x))
        {
            // ball hits top or bottom of collider
            newDirection = new Vector2(-collision.relativeVelocity.x, collision.relativeVelocity.y).normalized;
        }
        else
        {
            // ball hits sides of collider
            newDirection = new Vector2(collision.relativeVelocity.x, -collision.relativeVelocity.y).normalized;
        }

        rb.velocity = newDirection * Speed;
    }
}
