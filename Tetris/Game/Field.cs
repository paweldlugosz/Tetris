using System;
using System.Drawing;

namespace Game
{
    public class Field
    {
        public Color Color;
        public bool Used;

        public Field()
        {
            Color = Color.Transparent;
            Used = false;
        }
    }
}
