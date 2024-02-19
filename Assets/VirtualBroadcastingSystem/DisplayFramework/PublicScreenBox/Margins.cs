namespace VirtualBroadcastingSystem.DisplayFramework.PublicScreenBox
{
    public class Margins
    {
        public Margins(float top, float left, float bottom, float right)
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
        }

        public float Top { get; private set; }
        public float Left { get; private set; }
        public float Bottom { get; private set; }
        public float Right { get; private set; }
    }
}