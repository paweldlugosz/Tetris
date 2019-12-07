using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Point
    {
        private int previousX, previousY;
        private int x, y;
        public int X
        {
            get => x;
            set
            {
                previousX = x;
                x = value;
            }
        }

        public int Y
        {
            get => y;
            set
            {
                previousY = y;
                y = value;
            }
        }

        public Point(int x, int y)
        {
            previousX = 0;
            previousY = 0;
            this.x = x;
            this.y = y;
        }

        public void undo()
        {
            x = previousX;
            y = previousY;
        }

        public Point getPreviousPosition()
        {
            return new Point(previousX, previousY);
        }

        public Point Clone()
        {
            return new Point(x, y);
        }
    }
}
