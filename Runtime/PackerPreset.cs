using System;
using System.Collections.Generic;
using UnityEngine;

namespace TextureConversion
{
    [CreateAssetMenu(fileName = "New PackerPreset", menuName = "TextureConversion/Packer Preset")] //@Temp
    public class PackerPreset : ScriptableObject
    {
        //  InputTexture channel data should be persistent.

        public string title;
        public List<InputTexture> inputTextures = new List<InputTexture>();
        public string settings; //  @Incomplete

        public InputTexture GetInput(string id)
        {
            return inputTextures.Find(t => t.namedTex.name == id);
        }

        public List<string> GetInputIDs()
        {
            var ids = new List<string>();

            foreach (var iTex in inputTextures)
            {
                ids.Add(iTex.namedTex.name);
            }

            return ids;
        }
    }
}
