using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Curve))]

public class CurveEditor : Editor
{
    private int steps = 20;

    private void OnSceneGUI()
    {
        Curve curve = target as Curve;
        if (curve == null)
        {
            Debug.Log("CurveEditor::curve == null");
            return;
        }

        createPositionHandle(curve);

        drawCurve(curve);
    }

    private void createPositionHandle(Curve curve)
    {
        Quaternion handleRotation = Quaternion.identity;
        Vector3 point;

        for (int i = 0; i < curve.points.Length; i++)
        {
            point = curve.transform.TransformPoint(curve.points[i]);

            EditorGUI.BeginChangeCheck();
            point = Handles.PositionHandle(point, handleRotation);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(curve, "Moved point");
                curve.points[i] = curve.transform.InverseTransformPoint(point);
            }
        }
    }

    private void drawCurve(Curve curve)
    {
        Handles.color = Color.red;

        Vector3 p0 = curve.points[0];

        Vector3 p1;
        for (int i = 0; i < steps; i++)
        {
            float t = (float)i / steps;
            p1 = curve.Bezier(t);
            Handles.DrawLine(p0, p1);
            p0 = p1;
        }
    }
}
