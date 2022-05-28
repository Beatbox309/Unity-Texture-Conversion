using System;
using System.Collections.Generic;
using UnityEngine;

namespace TextureConversion
{
    public class InputTexture
    {
        public Texture2D texture;
        public Dictionary<TexChannel, InputChannel> inputs;

        public InputTexture()
        {
            inputs = new Dictionary<TexChannel, InputChannel>()
            {
                { TexChannel.Red,   new InputChannel(TexChannel.Red)},
                { TexChannel.Green, new InputChannel(TexChannel.Green)},
                { TexChannel.Blue,  new InputChannel(TexChannel.Blue)},
                { TexChannel.Alpha, new InputChannel(TexChannel.Alpha)},
            };
        }
    }
}
