using System;
using System.Drawing;

namespace Game
{
    /// <summary>
    /// Class generating pseudo-randomness of numbers -> blocks.
    /// A class containing the definition of blocks used in the game, the definition of colors and a randomization mechanism.

    /// </summary>
    static class TetrominoFactory
    {
        private static Random random = new Random();

        /// <summary>
        /// Definition of each blocks.
        /// </summary>
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

        /// <summary> 
        /// Definition of block colors used in the application.
        /// </summary>
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

        /// <summary>
        /// Definition of creating a new block. 
        /// Returned is an array with the points of the block (the points from which the blocks are built) and its color.
        /// </summary> 
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
