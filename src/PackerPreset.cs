using System;
using System.Collections.Generic;

namespace TextureConversion
{
    public class PackerPreset
    {
        //  InputTexture channel data should be persistent.

        public string name;
        public List<InputTexture> inputs;
        public string settings; //  @Incomplete
    }
}
