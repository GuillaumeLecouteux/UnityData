using UnityEditor;
using UnityEngine;

namespace JauntyBear.UnityData
{
    [CustomEditor(typeof(FloatVariable))]
    public class FloatVariableEditor : Editor
    {
        private FloatVariable t;
        private float newValue;

        public void OnEnable()
        {
            t = (FloatVariable)target;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.LabelField("Runtime Value", t.Value.ToString());

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("SetValue"))
                t.SetValue(newValue);
            newValue = EditorGUILayout.FloatField(string.Empty, newValue);
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Reset"))
                t.Reset();
        }
    }
}