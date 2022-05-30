using System;
using System.Collections.Generic;
using UnityEngine;

namespace TextureConversion
{
    [Serializable]
    public class InputTexture
    {
        public Texture2D texture;
        public Dictionary<TexChannel, OutputChannel> channels 
         = new Dictionary<TexChannel, OutputChannel>()
        {
            { TexChannel.Red,   new OutputChannel(TexChannel.Red)},
            { TexChannel.Green, new OutputChannel(TexChannel.Green)},
            { TexChannel.Blue,  new OutputChannel(TexChannel.Blue)},
            { TexChannel.Alpha, new OutputChannel(TexChannel.Alpha)},
        };
    }
}
