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

        /**private void setOrigin()
        {
            int maxX = int.MaxValue;
            int maxY = int.MaxValue;

            foreach (Point point in points)
            {
                maxX = Math.Max(maxX, point.X);
                maxY = Math.Max(maxY, point.Y);
            }

            originX = maxX / 2f;
            originY = maxY / 2f;
        }**/

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

        public void rotate()
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Point point = Points[i];
                int tempX = point.X;
                point.X = point.Y - origin.X + origin.Y;
                point.Y = origin.X - (tempX - origin.Y);
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
                if (point.X >= maxX || point.X < 0 || point.Y >= maxY) return false;
            }
            return true;
        }
    }

}

    

