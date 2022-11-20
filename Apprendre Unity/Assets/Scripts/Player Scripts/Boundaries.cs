using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    Camera cam;
    EdgeCollider2D edge;
    float width;
    float height;

    private void Awake() {
        cam = Camera.main;
        edge = GetComponent<EdgeCollider2D>();
        FindBoundaries();
        SetBounds();
    }

    void FindBoundaries() {
        width = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f);
        height = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f);
    }

    void SetBounds() {
        Vector2 pointa = new(width / 2, height / 2);
        Vector2 pointb = new(width / 2, -height / 2);
        Vector2 pointc = new(-width / 2, -height / 2);
        Vector2 pointd = new(-width / 2, height / 2);

        Vector2[] arrayOfPoints = new Vector2[] { pointa, pointb, pointc, pointd, pointa };
        edge.points = arrayOfPoints;
    }
}
