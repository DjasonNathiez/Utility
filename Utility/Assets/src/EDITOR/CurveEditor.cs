using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Curve))]
public class CurveEditor : Editor
{
   public override void OnInspectorGUI()
   {
      base.OnInspectorGUI();

      Curve c = (Curve) target;

      if (GUILayout.Button("Set Curve"))
      {
         c.InitCurve();
      }

      if (GUILayout.Button("Add Handles"))
      {
         c.AddHandles();
      }
   }
}
