using UnityEditor;
using UnityEngine;

namespace JauntyBear.UnityData
{
    [CustomEditor(typeof(Vector2Variable))]
    public class Vector2VariableEditor : Editor
    {
        private Vector2Variable t;
        private Vector2 newValue;

        public void OnEnable()
        {
            t = (Vector2Variable)target;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.LabelField("Runtime Value", t.Value.ToString());

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("SetValue"))
                t.SetValue(newValue);
            newValue = EditorGUILayout.Vector2Field(string.Empty, newValue);
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Reset"))
                t.Reset();
        }
    }
}