using System;
using System.Collections.Generic;
using UnityEngine;

namespace TextureConversion
{
    [Serializable]
    public struct NamedTexture
    {
        public string name;
        public Texture2D texture;
    }


    [Serializable]
    public class InputTexture
    {
        public NamedTexture namedTex;

        public Dictionary<TexChannel, InputChannel> channelIO = new Dictionary<TexChannel, InputChannel>()
        {
            { TexChannel.Red,   new InputChannel(TexChannel.Red)},
            { TexChannel.Green, new InputChannel(TexChannel.Green)},
            { TexChannel.Blue,  new InputChannel(TexChannel.Blue)},
            { TexChannel.Alpha, new InputChannel(TexChannel.Alpha)},
        };
    }
}
