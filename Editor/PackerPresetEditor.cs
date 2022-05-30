using System;
using UnityEditor;
using UnityEngine;

namespace TextureConversion
{
    [CustomEditor(typeof(PackerPreset))]
    public class PackerPresetEditor : Editor
    {
        public void DrawCustomGUI()
        {
            var p = target as PackerPreset;

            //EditorGUILayout.InspectorTitlebar(true, this);
            //  Unity has a builtin preset feature for components in the inspector.
            //  Maybe hijack that system instead of saving as a ScriptableObject?


            GUILayout.Space(20);

            p.title    = EditorGUILayout.TextField("Title", p.title);
            p.settings = EditorGUILayout.TextField("Export Settings", p.settings);

            EditorGUILayout.Space();

            for (int i = 0; i < p.inputTextures.Count; i++)
            {
                var iTex = p.inputTextures[i];

                GUILayout.BeginHorizontal();
                //GUILayout.Label("Input Texture");
                iTex.texture = EditorGUILayout.ObjectField(iTex.texture, typeof(Texture2D), false, GUILayout.Width(90), GUILayout.Height(80)) as Texture2D;

                GUILayout.BeginVertical();
                GUILayout.Label("Output Channels",GUILayout.Width(200));

                for (int j = 0; j < iTex.channels.Count; j++)
                {
                    GUILayout.BeginHorizontal();

                    var channel = (TexChannel)j;
                    OutputChannel oc = iTex.channels[channel];

                    oc.active = EditorGUILayout.ToggleLeft(channel.ToString(), oc.active, GUILayout.Width(60));
                    GUILayout.Label("->", GUILayout.Width(40));
                    oc.channel = (TexChannel)EditorGUILayout.EnumPopup(oc.channel, GUILayout.Width(60));

                    iTex.channels[channel] = oc;

                    GUILayout.EndHorizontal();
                }

                GUILayout.EndVertical();
                GUILayout.EndHorizontal();

                EditorGUILayout.Space();
            }
        }

    }
}
