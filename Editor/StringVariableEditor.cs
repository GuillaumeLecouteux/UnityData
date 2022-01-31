using UnityEditor;
using UnityEngine;

namespace JauntyBear.UnityData
{
    [CustomEditor(typeof(StringVariable))]
    public class StringVariableEditor : Editor
    {
        private StringVariable t;
        private string newValue;

        public void OnEnable()
        {
            t = (StringVariable)target;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.LabelField("Runtime Value", t.Value.ToString());

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("SetValue"))
                t.SetValue(newValue);
            newValue = EditorGUILayout.TextField(string.Empty, newValue);
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Reset"))
                t.Reset();
        }
    }
}