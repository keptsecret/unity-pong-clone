using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Well, it works now
 * Have to define 5 points to be able to form a solid quad around camera viewport
 */

public class CheckEdge : MonoBehaviour
{
    void Awake()
    {
        AddCollider();
    }

    private void AddCollider()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Camera.main not found, failed to create edge colliders");
            return;
        }

        var cam = Camera.main;
        if (!cam.orthographic)
        {
            Debug.LogError("Camera.main not orthographic, failed to create edge colliders");
            return;
        }

        var bottomLeft = (Vector2) cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        var topLeft = (Vector2) cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        var bottomRight = (Vector2) cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));
        var topRight =
            (Vector2) cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));

        var edge = GetComponent<EdgeCollider2D>() == null
            ? gameObject.AddComponent<EdgeCollider2D>()
            : GetComponent<EdgeCollider2D>();

        var edgePoints = new[] {bottomLeft, topLeft, topRight, bottomRight, bottomLeft};
        edge.points = edgePoints;
    }
}
