using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TextureConversion
{
    public class PackerWindow : EditorWindow
    {
        private PackerPreset packPreset;

        [MenuItem("Texture Conversion/Texture Packer")]
        static void Open()
        {
            GetWindow<PackerWindow>("Texture Packer");
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();
            packPreset = EditorGUILayout.ObjectField("Preset", packPreset, typeof(PackerPreset), false) as PackerPreset;

            if (packPreset)
                DrawTexPackerGUI(packPreset);
                //(Editor.CreateEditor(packPreset) as PackerPresetEditor).DrawTexPackerGUI();

            if (GUILayout.Button("Generate"))
            {
                Debug.Log(EditorUtility.SaveFilePanelInProject("Test", "FileName", "png", "Testingsg"));
            }
        }

        public void DrawTexPackerGUI(PackerPreset p)
        {
            //EditorGUILayout.InspectorTitlebar(true, this);
            //  Unity has a builtin preset feature for components in the inspector.
            //  Maybe hijack that system instead of saving as a ScriptableObject?


            GUILayout.Space(20);

            p.title = EditorGUILayout.TextField("Title", p.title);
            p.settings = EditorGUILayout.TextField("Export Settings", p.settings);

            EditorGUILayout.Space();

            for (int i = 0; i < p.inputTextures.Count; i++)
            {
                var iTex = p.inputTextures[i];

                GUILayout.BeginHorizontal();

                //  Input Texture vars
                GUILayout.BeginVertical();
                GUILayout.Label("Input Texture");
                EditorGUIUtility.labelWidth = 40;
                iTex.namedTex.name = EditorGUILayout.TextField("Name", iTex.namedTex.name);
                EditorGUIUtility.labelWidth = 0;

                EditorGUI.indentLevel++;
                iTex.namedTex.texture = EditorGUILayout.ObjectField(iTex.namedTex.texture, typeof(Texture2D), false, GUILayout.Width(90), GUILayout.Height(80)) as Texture2D;
                EditorGUI.indentLevel--;
                GUILayout.EndVertical();

                //  Channel Controls
                GUILayout.BeginVertical();
                GUILayout.Label("Output Channels", GUILayout.Width(200));

                for (int j = 0; j < iTex.channelIO.Count; j++)
                {
                    GUILayout.BeginHorizontal();

                    var channel = (TexChannel)j;
                    InputChannel oc = iTex.channelIO[channel];

                    oc.active = EditorGUILayout.ToggleLeft(channel.ToString(), oc.active, GUILayout.Width(60));
                    GUILayout.Label("->", GUILayout.Width(40));
                    oc.outputChannel = (TexChannel)EditorGUILayout.EnumPopup(oc.outputChannel, GUILayout.Width(60));

                    iTex.channelIO[channel] = oc;

                    GUILayout.EndHorizontal();
                }

                GUILayout.EndVertical();
                GUILayout.EndHorizontal();

                EditorGUILayout.Space();
            }
        }
    }
}
