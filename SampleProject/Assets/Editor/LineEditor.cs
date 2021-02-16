using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Line))]

public class LineEditor : Editor
{
    private void OnSceneGUI()
    {
        Line line = target as Line;

        if (line == null)
        {
            Debug.Log("PathEditor::path == null");
            return;
        }

        Transform pathTransform = line.transform;
        Vector3 p0 = pathTransform.TransformPoint(line.P0);
        Vector3 p1 = pathTransform.TransformPoint(line.P1);

        Handles.color = Color.red;
        Handles.DrawLine(p0, p1);

        // Create position handle to be used on the scene view
        Quaternion handleRotation = Quaternion.identity;
        p0 = Handles.PositionHandle(p0, handleRotation);
        p1 = Handles.PositionHandle(p1, handleRotation);

        // Check if positions changed, and if so update
        EditorGUI.BeginChangeCheck();
        p0 = Handles.PositionHandle(p0, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            // Mark object as changed
            Undo.RecordObject(line, "Moved Point");

            line.P0 = pathTransform.InverseTransformPoint(p0);
        }

        EditorGUI.BeginChangeCheck();
        p1 = Handles.PositionHandle(p1, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            // Mark object as changed
            Undo.RecordObject(line, "Moved Point");

            line.P1 = pathTransform.InverseTransformPoint(p1);
        }
    }
}
