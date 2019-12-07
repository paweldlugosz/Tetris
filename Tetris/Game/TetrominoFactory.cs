using System;
using System.Drawing;

namespace Game
{
    static class TetrominoFactory
    {
        private static Random random = new Random();
        private static Point[][] tetrominos = new Point[][] 
        {
            new Point [] {
                new Point(0,0),
                new Point(0,1),
                new Point(0,2),
                new Point(0,3)
            },
            new Point [] {
                new Point(0,0),
                new Point(0,1),
                new Point(1,0),
                new Point(1,1)
            },
            new Point [] {
                new Point(0,0),
                new Point(0,1),
                new Point(1,1),
                new Point(1,2)
            },
            new Point [] {
                new Point(0,0),
                new Point(0,1),
                new Point(1,1),
                new Point(1,2)
            },
            new Point [] {
                new Point(0,1),
                new Point(0,2),
                new Point(1,0),
                new Point(1,1)
            },
            new Point [] {
                new Point(0,0),
                new Point(0,1),
                new Point(0,2),
                new Point(1,0)
            },
            new Point [] {
                new Point(0,0),
                new Point(0,1),
                new Point(0,2),
                new Point(1,2)
            }
        };

        private static Color[] colors = new Color[]
        {
            Color.FromArgb(219, 86, 86),
            Color.FromArgb(219, 199, 86),
            Color.FromArgb(123, 219, 86),
            Color.FromArgb(86, 219, 161),
            Color.FromArgb(86, 161, 219),
            Color.FromArgb(123, 86, 219),
            Color.FromArgb(219, 86, 199)

        };

        public static Tetromino getNewRandomTetromino()
        {
            int index = random.Next(0, tetrominos.Length);
            int color = random.Next(0, tetrominos.Length);
            Point[] tetrominoArray = tetrominos[index];
            Point[] newTetromionoArray = new Point[tetrominoArray.Length];
            for (int i = 0; i < newTetromionoArray.Length; i++)
            {
                newTetromionoArray[i] = tetrominoArray[i].Clone();
            }
            return new Tetromino(newTetromionoArray, colors[color]);
        }
    }
}
