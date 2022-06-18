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
    public struct InputChannel
    {
        public bool active;
        public TexChannel outputChannel;
        public Operator op;

        public InputChannel(TexChannel outputChannel)
        {
            this.outputChannel = outputChannel;
            this.active = false;
            this.op = null;
        }
    }
}
