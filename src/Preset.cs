using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextureConversion
{
    public class Preset
    {
        //  InputTexture channel data should be persistent.

        public string name;
        public List<InputTexture> inputs;
        public string settings; //  @Incomplete
    }
}
