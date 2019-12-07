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

        public void clear()
        {
            Color = Color.Transparent;
            Used = false;
        }

        public void set(Field field)
        {
            Color = field.Color;
            Used = field.Used;
        }
    }
}
