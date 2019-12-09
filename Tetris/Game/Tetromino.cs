using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Game
{
    public class Tetromino
    {
        public Point[] Points { get; private set; }
        private Point origin;
        public Color color;

        public Tetromino(Point[] points, Color color)
        {
            this.Points = points;
            this.origin = points[1];
            this.color = color;
        }

        public void offset(int x, int y)
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Point point = Points[i];
                point.X += x;
                point.Y += y;
            }
        }

        public void undo()
        {
            foreach (Point point in Points) point.undo();
        }

        public void Rotate()
        {
            Point pivot = Points[1];

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
                previousPosition[i] = Points[i].getPreviousPosition();
            }
            return previousPosition;
        }

        public bool collision(int maxX, int maxY)
        {
            foreach (Point point in Points)
            {
                if (point.X > maxX - 1 || point.X < 0 || point.Y > maxY - 1) return true;
            }
            return false;
        }
    }

}

    

