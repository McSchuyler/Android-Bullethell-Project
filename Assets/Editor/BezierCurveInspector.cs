using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BezierCurve))]
public class BezierCurveInspector : Editor {

    private BezierCurve curve;
    private Transform handleTransform;
    private Quaternion handleRotation;

    private const int lineSteps = 10;
    private const float directionScale = 0.5f;

    private void OnSceneGUI()
    {
        curve = target as BezierCurve;
        handleTransform = curve.transform;
        handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;

        Vector2 p1 = ShowPoint(0);
        Vector2 p2 = ShowPoint(1);
        Vector2 p3 = ShowPoint(2);
        Vector2 p4 = ShowPoint(3);

        Handles.color = Color.grey;
        Handles.DrawLine(p1, p2);
        Handles.DrawLine(p2, p3);
        Handles.DrawLine(p3, p4);

        ShowDirections();
        Handles.DrawBezier(p1, p4, p2, p3, Color.white, null, 2f);

        Handles.color = Color.white;
        Vector2 startLine = curve.GetPoint(0f);
        Handles.color = Color.green;
        Handles.DrawLine(startLine, startLine + curve.GetDirection(0f));

        for(int i =0; i<=lineSteps; i++)
        {
            Vector2 endLine = curve.GetPoint(i / (float)lineSteps);
            //Handles.color = Color.white;
            //Handles.DrawLine(startLine, endLine);
            Handles.color = Color.green;
            Handles.DrawLine(endLine, endLine + curve.GetDirection(i / (float)lineSteps));
            startLine = endLine;
        }
    }

    private Vector2 ShowPoint(int index)
    {
        //turn local point to world space position
        Vector2 point = handleTransform.TransformPoint(curve.points[index]);

        EditorGUI.BeginChangeCheck();
        point = Handles.DoPositionHandle(point, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(curve, "Move Point");
            EditorUtility.SetDirty(curve);
            curve.points[index] = handleTransform.InverseTransformPoint(point);
        }
        return point;
    }

    private void ShowDirections()
    {
        Handles.color = Color.green;
        Vector2 point = curve.GetPoint(0f);
        Handles.DrawLine(point, point + curve.GetDirection(0f) * directionScale);
        for (int i = 1; i <= lineSteps; i++)
        {
            point = curve.GetPoint(i / (float)lineSteps);
            Handles.DrawLine(point, point + curve.GetDirection(i / (float)lineSteps) * directionScale);
        }
    }
}
