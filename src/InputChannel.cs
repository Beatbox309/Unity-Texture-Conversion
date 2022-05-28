namespace TextureConversion
{
    public enum TexChannel
    {
        Red,
        Green,
        Blue,
        Alpha
    }

    public struct InputChannel
    {
        public bool active;
        public TexChannel channel;
        public Operator op;

        public InputChannel(TexChannel channel)
        {
            this.channel = channel;
            this.active = false;
            this.op = null;
        }
    }
}
