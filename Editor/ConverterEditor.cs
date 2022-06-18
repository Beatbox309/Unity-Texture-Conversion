using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TextureConversion
{
    [CustomEditor(typeof(Converter))]
    public class ConverterEditor : Editor
    {
        //  Link up each input texture slot to a preset's input

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var c = target as Converter;

            EditorGUILayout.Space();
            GUILayout.Label("Preset Textures");

            EditorGUI.indentLevel++;
            for (int i = 0; i < c.presets.Count; i++)
            {
                PackerPreset p = c.presets[i];
                for (int j = 0; j < p.inputTextures.Count; j++)
                {
                    var iTex = p.inputTextures[j];

                    string label = iTex.namedTex.name != string.Empty
                        ? $"{p.title}.{iTex.namedTex.name}"
                        : $"Texture in Packer '{p.title}' at index '{j}' is invalid!";

                    EditorGUILayout.LabelField(label);
                }
            }
            EditorGUI.indentLevel--;

            //  Wire Converter Inputs to Preset Inputs

            EditorGUILayout.Space();
            GUILayout.Label("IO");

            GUILayout.BeginHorizontal();
            GUILayout.Label("Converter Input");
            GUILayout.Label("Preset");
            GUILayout.Label("Texture Name");
            GUILayout.EndHorizontal();


            //@Refactor: Bad. Yucky. Icky.

            var inputNames = new List<string>();
            for (int i = 0; i < c.inputSlots.Count; i++)
            {
                inputNames.Add(c.inputSlots[i].name);
            }

            var outputPresetNames = new List<string>();
            foreach (var p in c.presets)
            {
                outputPresetNames.Add(p.title);
            }

            GUILayout.BeginVertical();

            for (int i = 0; i < c.presetIO.Count; i++)
            {
                GUILayout.BeginHorizontal();
                var pIO = c.presetIO[i];

                int inputNameindex = Math.Max(inputNames.IndexOf(pIO.inputID), 0);
                pIO.inputID = inputNames[EditorGUILayout.Popup(inputNameindex, inputNames.ToArray())];

                int packPresetIndex = Math.Max(c.presets.IndexOf(pIO.outputPreset), 0);
                pIO.outputPreset = c.presets[EditorGUILayout.Popup(packPresetIndex, outputPresetNames.ToArray())];

                var presetTexIDs = pIO.outputPreset.GetInputIDs();

                int presetTexIDIndex = Math.Max(presetTexIDs.IndexOf(pIO.presetTexID), 0);
                pIO.presetTexID = presetTexIDs[EditorGUILayout.Popup(presetTexIDIndex, presetTexIDs.ToArray())];

                GUILayout.EndHorizontal();
            }

            GUILayout.EndVertical();

        }
    }

    
}
