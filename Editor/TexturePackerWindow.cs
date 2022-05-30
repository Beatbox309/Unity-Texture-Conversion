using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TextureConversion
{
    public class TexturePackerWindow : EditorWindow
    {
        private PackerPreset packPreset;

        [MenuItem("Texture Conversion/Texture Packer")]
        static void Open()
        {
            GetWindow<TexturePackerWindow>("Texture Packer");
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();
            packPreset = EditorGUILayout.ObjectField("Preset", packPreset, typeof(PackerPreset)) as PackerPreset;

            if (packPreset)
                (Editor.CreateEditor(packPreset) as PackerPresetEditor).DrawCustomGUI();

            if (GUILayout.Button("Generate"))
            {
                Debug.Log(EditorUtility.SaveFilePanelInProject("Test", "FileName", "png", "Testingsg"));
            }
        }
    }
}
