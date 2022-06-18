using System;
using System.Collections.Generic;
using UnityEngine;

namespace TextureConversion
{
    [CreateAssetMenu(fileName = "New Converter", menuName = "TextureConversion/Converter")]
    public class Converter : ScriptableObject
    {
        public List<NamedTexture> inputSlots = new List<NamedTexture>();
        public List<PackerPreset> presets = new List<PackerPreset>();
        public List<PresetIO> presetIO = new List<PresetIO>();


        [Serializable]
        public class PresetIO
        {
            public string inputID;
            public PackerPreset outputPreset;
            public string presetTexID;
        }
    }
}
