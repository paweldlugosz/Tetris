using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    /// <summary>
    /// Define class Point; 
    /// The "Point" class definition provides methods for setting values ​​for types X and Y
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Previous X value
        /// </summary>
        public int previousX;

        /// <summary>
        /// Previous Y value
        /// </summary>
        public int previousY;

        /// <summary>
        /// Current x value
        /// </summary>
        public int x;

        /// <summary>
        /// Current x value
        /// </summary>
        public int y;

        /// <summary>
        /// Method responsible for setting the X variables.
        /// </summary>
        public int X
        {
            get => x;
            set
            {
                previousX = x;
                x = value;
            }
        }

        /// <summary>
        /// Method responsible for setting the Y variables.
        /// </summary>
        public int Y
        {
            get => y;
            set
            {
                previousY = y;
                y = value;
            }
        }

        /// <summary>
        /// Constructor of the "Point" class responsible for assigning new values ​​to X and Y and reset previous X and Y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            previousX = 0;
            previousY = 0;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Assigning previous values ​​to X and Y.
        /// </summary>
        public void undo()
        {
            x = previousX;
            y = previousY;
        }

        /// <returns>Method which returns the previous position in the document.</returns>
        public Point getPreviousPosition()
        {
            return new Point(previousX, previousY);
        }

        /// <summary>
        /// The method clones the 'Point' class (returns the 'Point' class with X and Y parameters).
        /// </summary>
        /// <returns>Returns another copy of data. Returns new Point.</returns>
        public Point Clone()
        {
            return new Point(x, y);
        }
    }
}
