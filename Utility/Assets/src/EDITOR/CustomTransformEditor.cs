using UnityEditor;
using UnityEngine;

public class CustomTransformEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Transform t = (Transform) target;

        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        GUILayoutOption[] buttonStyle = new GUILayoutOption[]
        {
            GUILayout.Width(100),
            GUILayout.Height(30),
            GUILayout.ExpandWidth(true)
        };
        
        if (GUILayout.Button("Rotate X 90°", buttonStyle))
        {
            t.RotateX(90);
        }
        
        if (GUILayout.Button("Rotate Y 90°", buttonStyle))
        {
            t.RotateY(90);
        }
        
        if (GUILayout.Button("Rotate Z 90°", buttonStyle))
        {
            t.RotateZ(90);
        }
        
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Reset Rotation", buttonStyle))
        {
            t.localRotation = new Quaternion(0, 0, 0, 0);
        }

        if (GUILayout.Button("Reset Position", buttonStyle))
        {
            t.localPosition = new Vector3(0, 0, 0);
        }

        if (GUILayout.Button("Reset Scale", buttonStyle))
        {
            t.SetScale(1);
        }
        GUILayout.EndHorizontal();
        
    }
}
