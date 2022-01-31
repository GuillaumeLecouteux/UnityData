using UnityEditor;
using UnityEngine;

namespace JauntyBear.UnityData
{
    [CustomEditor(typeof(IntVariable))]
    public class IntVariableEditor : Editor
    {
        private IntVariable t;
        private int newValue;

        public void OnEnable()
        {
            t = (IntVariable)target;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.LabelField("Runtime Value", t.Value.ToString());

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("SetValue"))
                t.SetValue(newValue);
            newValue = EditorGUILayout.IntField(string.Empty, newValue);
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Reset"))
                t.Reset();
        }
    }
}