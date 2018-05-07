using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LinePath))]
public class LineInspector : Editor {

    private void OnSceneGUI()
    {
        LinePath linePath = target as LinePath;
        Transform handleTransform = linePath.transform;

        //Transform local point to world space
        Vector2 p1 = handleTransform.TransformPoint(linePath.p1);
        Vector2 p2 = handleTransform.TransformPoint(linePath.p2);

        Quaternion handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;
        Handles.color = Color.white;
        Handles.DrawLine(p1,p2);

        //Enable handles
        //Pass back world space coord to local point if changes happened to the point
        EditorGUI.BeginChangeCheck();
        p1 = Handles.DoPositionHandle(p1, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(linePath, "Move Point");
            EditorUtility.SetDirty(linePath);
            linePath.p1 = handleTransform.InverseTransformPoint(p1);
        }

        EditorGUI.BeginChangeCheck();
        p2 = Handles.DoPositionHandle(p2, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(linePath, "Move Point");
            EditorUtility.SetDirty(linePath);
            linePath.p2 = handleTransform.InverseTransformPoint(p2);
        }
    }
}
