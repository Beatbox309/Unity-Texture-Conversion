using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TextureConversion
{
    public class TexturePackerWindow : EditorWindow
    {
        [MenuItem("Texture Conversion/Texture Packer")]
        static void Open()
        {
            GetWindow<TexturePackerWindow>("Texture Packer");
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Texture Packer");

            if (GUILayout.Button("Generate"))
            {
                Debug.Log(EditorUtility.SaveFilePanelInProject("Test", "FileName", "png", "Testingsg"));
            }
        }
    }
}
