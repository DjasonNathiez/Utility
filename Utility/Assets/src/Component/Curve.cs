using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Curve : MonoBehaviour
{
    public int pointCount;
    public int handlePointCount;
    public Vector3 firstPointAnchor;
    public Vector3 lastPointAnchor;
    public List<Vector3> handlePoints;
    public List<Vector3> points;

    private void Awake()
    {
        InitCurve();
    }

    public void InitCurve()
    {
        points = new List<Vector3>();
        
        float distX = lastPointAnchor.x - firstPointAnchor.x;
        float distY = lastPointAnchor.y - firstPointAnchor.y;
        float distZ = lastPointAnchor.z - firstPointAnchor.z;
        Vector3 distance = new Vector3(distX, distY, distZ);
        Vector3 distanceBetweenPoint = distance / pointCount;
        
        for (int i = 0; i < pointCount + 1; i++)
        {
            Vector3 newPoint = firstPointAnchor + distanceBetweenPoint * i;
            points.Add(newPoint);
        }
        
        //Set the pivot points
        DrawCurve();
    }

    public void AddHandles()
    {
        handlePoints = new List<Vector3>();

        for (int i = 1; i < points.Count; i++)
        {
            if (i.IsMultipleOf(pointCount / handlePointCount))
            {
                handlePoints.Add(points[i]);
            }
        }
    }

#if UNITY_EDITOR
    
    private void OnValidate()
    {
        if(pointCount < 1)
        {
            pointCount = 1;
        }
        
        DrawCurve();
    }

    private void OnDrawGizmos()
    {
        DrawCurve();
    }

    private void DrawCurve()
    {
        //Debug.DrawLine(firstPointAnchor, lastPointAnchor);

        for (int i = 0; i < points.Count; i++)
        {
            if(i < points.Count -1) Debug.DrawLine(points[i], points[i+1]);
            Debug.DrawLine(points[i], points[i] + Vector3.up);
        }
    }
    
#endif
    
}
