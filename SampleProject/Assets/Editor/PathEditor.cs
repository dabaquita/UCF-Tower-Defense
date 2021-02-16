using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{
    Path path;

    private void OnSceneGUI()
    {
        path = target as Path;
        if (path == null)
        {
            Debug.Log("PathEditor::path == null");
            return;
        }

        createPositionHandle();

        displayCurve();
    }

    public override void OnInspectorGUI()
    {
        path = target as Path;

        if (GUILayout.Button("Add Segment"))
        {
            Undo.RecordObject(path, "Add Segment");
            EditorUtility.SetDirty(path);
            path.addSegment();
        }

        if (path.getSegmentCount() > 1)
        {
            if (GUILayout.Button("Remove Segment"))
            {
                Undo.RecordObject(path, "Remove Segment");
                EditorUtility.SetDirty(path);
                path.removeSegment();
            }
        }
    }

    public void createPositionHandle()
    {
        Quaternion handleRotation = Quaternion.identity;
        Vector3 point;

        for (int i = 0; i < path.getPointCount(); i++)
        {
            point = path.transform.TransformPoint(path.getPoint(i));

            EditorGUI.BeginChangeCheck();
            point = Handles.PositionHandle(point, handleRotation);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(path, "Moved point");
                path.setPoint(i, path.transform.InverseTransformPoint(point));
            }
        }
    }

    public void displayCurve()
    {
        Vector3 p0, p1, p2, p3;

        // Draw cubic Bezier curve - every 2 curves will share 1 middle point
        for (int i = 0; i < path.getPointCount() - 1; i += 3)
        {
            p0 = path.transform.TransformPoint(path.getPoint(i));
            p1 = path.transform.TransformPoint(path.getPoint(i + 1));
            p2 = path.transform.TransformPoint(path.getPoint(i + 2));
            p3 = path.transform.TransformPoint(path.getPoint(i + 3));

            Handles.DrawBezier(p0, p3, p1, p2, Color.black, null, 4f);
        }
    }
}
