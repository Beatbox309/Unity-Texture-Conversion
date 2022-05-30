using System;
using System.Collections.Generic;
using UnityEngine;

namespace TextureConversion
{
    [CreateAssetMenu(fileName = "New PackerPreset", menuName = "Packer Preset")] //@Temp
    public class PackerPreset : ScriptableObject
    {
        //  InputTexture channel data should be persistent.

        public string title;
        public List<InputTexture> inputTextures = new List<InputTexture>();
        public string settings; //  @Incomplete
    }
}
