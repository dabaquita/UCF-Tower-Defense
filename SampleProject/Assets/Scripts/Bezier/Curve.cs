using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour
{
    public Vector3[] points = new Vector3[]
    {
        new Vector3(1f, 0f, 0f),
        new Vector3(2f, 0f, 0f),
        new Vector3(3f, 0f, 0f),
        new Vector3(4f, 0f, 0f),
    };

    // Implements the bezier curve equation
    public Vector3 Bezier(float t)
    {
        // Ensure t s always between 0 and 1
        t = Mathf.Clamp01(t);

        float a = 1f - t;
        return Mathf.Pow(a, 3) * points[0] +
            3 * Mathf.Pow(a, 2) * t * points[1] +
            3 * a * Mathf.Pow(t, 2) * points[2] +
            Mathf.Pow(t, 3) * points[3];
    }
}
