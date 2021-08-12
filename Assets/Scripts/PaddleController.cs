using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PaddleController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [Range(-1f, 1f)]
    public float VertInput;

    [Min(0)]
    public float Speed = 10.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, Speed * VertInput);
    }
}
