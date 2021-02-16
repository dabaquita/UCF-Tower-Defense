using UnityEngine;
using System.Collections.Generic;

public class Path : MonoBehaviour
{
    [SerializeField]
    private List<Vector3> points = new List<Vector3>()
    {
        new Vector3(1f, 0f, 0f),
        new Vector3(2f, 0f, 0f),
        new Vector3(3f, 0f, 0f),
        new Vector3(4f, 0f, 0f),
    };

    private const int initPointsCount = 4;

    public void Reset()
    {
        points.Clear();
        for (int i = 0; i < initPointsCount; i++)
        {
            points.Add(new Vector3(i + 1, 0, 0));
        }
    }

    public int getPointCount()
    {
        return points.Count;
    }

    public Vector3 getPoint(int i)
    {
        return points[i];
    }

    public void setPoint(int i, Vector3 point)
    {
        points[i] = point;
    }

    public int getSegmentCount()
    {
        return points.Count / 3;
    }

    public void addSegment()
    {
        Vector3 startingPoint = points[points.Count - 1];
        float offset = 2f;

        points.Add(new Vector3(startingPoint.x, startingPoint.y + offset, 0));
        points.Add(new Vector3(startingPoint.x + offset, startingPoint.y + offset, 0));
        points.Add(new Vector3(startingPoint.x, startingPoint.y, 0));
    }

    public void removeSegment()
    {
        // Remove last 3 points
        int pointCount = points.Count;
        if (getSegmentCount() > 1)
        {
            points.RemoveAt(pointCount - 1);
            points.RemoveAt(pointCount - 2);
            points.RemoveAt(pointCount - 3);
        }
    }
}
