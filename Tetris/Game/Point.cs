using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Point
    {
        private int previousX, previousY;
        public int X
        {
            get => X;
            set
            {
                previousX = X;
                previousY = Y;
                X = value;
            }
        }

        public int Y
        {
            get => Y;
            set
            {
                previousX = X;
                previousY = Y;
                Y = value;
            }
        }

        public Point(int x, int y)
        {
            previousX = 0;
            previousY = 0;
            X = x;
            Y = y;
        }

        public void undo()
        {
            X = previousX;
            Y = previousY;
        }

        public Point getPreviousPosition()
        {
            return new Point(previousX, previousY);
        }
    }
}
