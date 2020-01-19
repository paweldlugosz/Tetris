using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Game
{
    public class Tetromino
    {
        public Point[] Points { get; private set; } // all squares in tetromino
        public Color color; // color for all squares in this tetromino

        public Tetromino(Point[] points, Color color)
        {
            this.Points = points;
            this.color = color;
        }

        public void offset(int x, int y)
        {
            // each square shifted by x y
            for (int i = 0; i < Points.Length; i++)
            {
                Point point = Points[i];
                point.X += x;
                point.Y += y;
            }
        }

        public void undo()
        {
            // restore the previous location of each square
            foreach (Point point in Points) point.undo();
        }

        public void Rotate()
        {
            Point pivot = Points[1]; // choosing the place of rotation
            
            // rotation
            foreach (Point point in Points)
            {
                int x = point.X - pivot.X;
                int y = point.Y - pivot.Y;

                point.X = pivot.X - y;
                point.Y = pivot.Y + x;
            }
        }

        public Point[] getPreviousPosition()
        {
            Point[] previousPosition = new Point[Points.Length];
            for (int i = 0; i < Points.Length; i++)
            {
                // collecting all previous square locations
                previousPosition[i] = Points[i].getPreviousPosition();
            }
            return previousPosition;
        }

        public bool collision(int maxX, int maxY)
        {
            foreach (Point point in Points)
            {
                // collision detection with board edge (without top)
                if (point.X > maxX - 1 || point.X < 0 || point.Y > maxY - 1) return true;
            }
            return false;
        }
    }

}

    

