namespace TextureConversion
{
    public enum TexChannel
    {
        Red,
        Green,
        Blue,
        Alpha
    }

    [System.Serializable]
    public struct OutputChannel
    {
        public bool active;
        public TexChannel channel;
        public Operator op;

        public OutputChannel(TexChannel channel)
        {
            this.channel = channel;
            this.active = false;
            this.op = null;
        }
    }
}
