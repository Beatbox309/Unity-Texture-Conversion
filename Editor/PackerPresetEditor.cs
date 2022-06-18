using System;
using UnityEditor;
using UnityEngine;

namespace TextureConversion
{
    [CustomEditor(typeof(PackerPreset))]
    public class PackerPresetEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}
