using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Game
{
    /// <summary>
    /// A class that provides colorful blocks
    /// </summary>
    public class Tetromino
    {   /// <summary>
        /// Define assignment color for all squares in this tetromino. 
        /// </summary>
        public Point[] Points { get; private set; } 

        /// <summary>
        /// Color
        /// </summary>
        public Color color;

        /// <summary>
        /// Builder assigning point list and color
        /// </summary>
        /// <param name="points">List of points</param>
        /// <param name="color">Color</param>
        public Tetromino(Point[] points, Color color)
        {
            this.Points = points;
            this.color = color;
        }

        /// <summary>
        /// Method shifter each square by parameter X i Y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void offset(int x, int y)
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Point point = Points[i];
                point.X += x;
                point.Y += y;
            }
        }

        /// <summary>
        /// Get back previous localization of each square.
        /// </summary>
        public void undo()
        {
            foreach (Point point in Points) point.undo();
        }


        /// <summary>
        /// Main method responsible for rotating blocks.
        /// Pivot point setting.
        /// </summary>
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

        /// <summary>
        /// Retrieve previous points from one current point.
        /// </summary>
        /// <returns>Return previous position each of square</returns>
        public Point[] getPreviousPosition()
        {
            Point[] previousPosition = new Point[Points.Length];
            for (int i = 0; i < Points.Length; i++)
            {
           
                previousPosition[i] = Points[i].getPreviousPosition();
            }
            return previousPosition;
        }

        /// <summary>
        /// Collision detection with board edge (without top edge).
        /// </summary>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
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

    

