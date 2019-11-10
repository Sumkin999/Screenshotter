using DefaultNamespace;
using UnityEditor;
using UnityEngine;


    [CustomEditor(typeof(ScrrenshotCK))]
    public class ScreenshotEditorCK : UnityEditor.Editor
    {

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Take Screenshot"))
            {
                ((ScrrenshotCK) serializedObject.targetObject).CAPTURE();
            }
        }
    }
