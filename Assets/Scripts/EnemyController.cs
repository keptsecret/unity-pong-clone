using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private PaddleController paddle;
    private Collider2D col;
    private Vector3 cachedLocalPosition;

    private Vector2[] castDirections = new Vector2[]
    {
        new Vector2(-0.2f, 0.8f).normalized,
        new Vector2(-0.6f, 0.4f).normalized,
        new Vector2(-1f, 0f).normalized,
        new Vector2(-0.6f, -0.4f).normalized,
        new Vector2(-0.2f, -0.8f).normalized
    };

    [Range(0, 5)]
    public float Buffer = 2f;

    void Start()
    {
        paddle = GetComponent<PaddleController>();
        col = GetComponent<Collider2D>();
        cachedLocalPosition = transform.localPosition;
    }

    void Update()
    {
        cachedLocalPosition = transform.localPosition;
        float distance = 7f;
        Vector3 origin = 0.2f * Vector3.left + cachedLocalPosition;

        foreach (Vector2 dir in castDirections)
        {
            //Debug.DrawRay(origin, dir * distance, Color.yellow);
            RaycastHit2D foundCast = Physics2D.Raycast(origin, dir, distance);

            if (foundCast.collider != null)
            {
                //Debug.Log(foundCast.collider.gameObject.name);
                if (foundCast.collider.gameObject.tag == "Ball")
                {
                    float moveYDir = foundCast.transform.localPosition.y - cachedLocalPosition.y;
                    paddle.VertInput = Mathf.Sign(moveYDir) * 1f;
                    break;
                }
            }
            else
            {
                if (Mathf.Abs(cachedLocalPosition.y) >= Buffer * 0.1f)
                {
                    paddle.VertInput = (cachedLocalPosition.y > 0) ? -1f : 1f;
                }
                else
                {
                    paddle.VertInput = 0f;
                }
            }
        }
    }
}
