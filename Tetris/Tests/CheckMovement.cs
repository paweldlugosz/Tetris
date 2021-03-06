﻿using System;
using Game;
using Front;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{  /// <summary>
   /// Summary description for CheckMovement
   /// </summary>
    [TestClass]
    public class CheckMovement
    {
        private readonly GameView game = new GameView();
        private readonly Field field = new Field();
        /// <summary>
        /// Check if block move left when i press "A" button
        /// Method: moveLeft()
        /// </summary>
        [TestMethod]
        public void CheckIfBlockMovingLeft()
        {

            game.startPause_Click(null, EventArgs.Empty);
            game.tetris.moveLeft();

            var point = game.tetris.activeTetromino.Points[1];

            Assert.AreEqual(point.x, point.previousX - 1);
        }

        /// <summary>
        /// Check if block move right when i press "D" button
        /// Method: moveRight()
        /// </summary>
        [TestMethod]
        public void CheckIfBlockMovingRight()
        {
           
            game.startPause_Click(null, EventArgs.Empty);
            game.tetris.moveRight();

            var point = game.tetris.activeTetromino.Points[1];

            Assert.AreEqual(point.x, point.previousX + 1);
        }

        /// <summary>
        /// Check if block move down when i press "S" button
        /// Method: moveDown()
        /// </summary>
        [TestMethod]
        public void CheckIfBlockMovingDown()
        {
          
            game.startPause_Click(null, EventArgs.Empty);
            game.tetris.moveDown();

            var point = game.tetris.activeTetromino.Points[1];

            Assert.AreEqual(point.y, point.previousY + 1);
        }

        /// <summary>
        /// Check previous position for one point
        /// Method: getPreviousPosition()
        /// </summary>
        [TestMethod]
        public void CheckPreviousPosition()
        {
            game.startPause_Click(null, EventArgs.Empty);
            System.Threading.Thread.Sleep(800);

            var pointActual = game.tetris.activeTetromino.Points[1];
            var pointPrevious = game.tetris.activeTetromino.Points[1].getPreviousPosition();

            Assert.AreEqual(pointActual.y, pointPrevious.y + 1);
        }

        /// <summary>
        /// Check points when block will be rotated
        /// Method: rotate();
        /// </summary>
        [TestMethod]
        public void CheckBlockRotate()
        { 
            game.startPause_Click(null, EventArgs.Empty);

            var lenght = game.tetris.activeTetromino.Points.Length;
            var pivot = game.tetris.activeTetromino.Points[1];
            Game.Point[] point = game.tetris.activeTetromino.Points;

            for (int i = 0; i < lenght; i++)
            {
                int x = point[i].x - pivot.x;
                int y = point[i].y - pivot.y;

                game.tetris.rotate();

                Assert.AreEqual(point[i].x, pivot.x - y);
                Assert.AreEqual(point[i].y, pivot.y + x);
            }
        }
        /// <summary>
        /// Check if block moved to the floor when i press "M" button
        /// </summary>
        [TestMethod]
        public void CheckIfBlockGoingFloor()
        {
            game.startPause_Click(null, EventArgs.Empty);

            var lenght = game.tetris.activeTetromino.Points.Length;
            Point[] point1 = game.tetris.activeTetromino.Points;

            game.tetris.flor();

            for (int i = 0; i < lenght; i++)
            {
                int boardHeight = game.tetris.Height;
                int offset = boardHeight - point1[i].y;
                Assert.AreEqual(offset + point1[i].y, 20);
            }
        }
    }
}
