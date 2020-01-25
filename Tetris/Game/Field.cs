using System;
using System.Drawing;

namespace Game

    { /// <summary>
      /// This class (field) contains a game color describing field in the game and clear field.
      /// </summary>
    public class Field

    {   /// <summary>
        /// Defined 'Color'and 'Used' variable.
        /// </summary>
        public Color Color;

        /// <summary>
        /// Field usage status
        /// </summary>
        public bool Used;

        /// <summary>
        /// Initialize type of color and variable.
        /// Defined a constructor for the 'Field' class and setted value for 'Color' and 'Used' variables.
        /// </summary>
        public Field()
        {
            Color = Color.Transparent;
            Used = false;
        }

        /// <summary>
        /// Field cleaning method in the game.
        /// </summary>
        public void clear()
        {
            Color = Color.Transparent;
            Used = false;
        }

        /// <summary>
        /// Defined a value for 'Color' and 'Used' variables when the row is filled.
        /// </summary>
        /// <param name="field"></param>
        public void set(Field field)
        {
            Color = field.Color;
            Used = field.Used;
        }
    }
}
