using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PaddleController paddle;

    void Start()
    {
        paddle = GetComponent<PaddleController>();
    }

    void Update()
    {
        paddle.VertInput = Input.anyKey ? Input.GetAxisRaw("Vertical") : 0.0f;
    }
}
