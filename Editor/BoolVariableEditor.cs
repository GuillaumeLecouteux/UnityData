using UnityEditor;
using UnityEngine;

namespace JauntyBear.UnityData
{
    [CustomEditor(typeof(BoolVariable))]
    public class BoolVariableEditor : Editor
    {
        private BoolVariable t;
        private bool newValue;

        public void OnEnable()
        {
            t = (BoolVariable)target;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.LabelField("Runtime Value", t.Value.ToString());

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("SetValue"))
                t.SetValue(newValue);
            newValue = EditorGUILayout.Toggle(string.Empty, newValue);
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Reset"))
                t.Reset();
        }
    }
}