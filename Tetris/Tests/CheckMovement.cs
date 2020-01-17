using System;
using Front;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CheckMovement
    {
        private readonly GameView game = new GameView();

        /// <summary>
        /// Check if block move left when i press "A" button
        /// Method: moveLeft()
        /// </summary>
        [TestMethod]
        public void CheckIfBlockMovingLeft()
        {
            object sender = game.startPause.Text;

            game.startPause_Click(sender, EventArgs.Empty);
            game.tetris.moveLeft();

            var point = game.tetris.activeTetromino.Points[1];

            if (point.x == point.previousX - 1)
                Assert.IsTrue(true);
            else
                throw new Exception("Error, Something was wrong. \nActual X:" + point.x + "\nPrevious X:" + point.previousX);
        }

        /// <summary>
        /// Check if block move right when i press "D" button
        /// Method: moveRight()
        /// </summary>
        [TestMethod]
        public void CheckIfBlockMovingRight()
        {
            object sender = game.startPause.Text;

            game.startPause_Click(sender, EventArgs.Empty);
            game.tetris.moveRight();

            var point = game.tetris.activeTetromino.Points[1];

            if (point.x == point.previousX + 1)
                Assert.IsTrue(true);
            else
                throw new Exception("Error, Something was wrong. \nActual X:" + point.x + "\nPrevious X:" + point.previousX);
        }

        /// <summary>
        /// Check if block move down when i press "S" button
        /// Method: moveDown()
        /// </summary>
        [TestMethod]
        public void CheckIfBlockMovingDown()
        {
            object sender = game.startPause.Text;

            game.startPause_Click(sender, EventArgs.Empty);
            game.tetris.moveDown();

            var point = game.tetris.activeTetromino.Points[1];

            if (point.y == point.previousY + 1)
                Assert.IsTrue(true);
            else
                throw new Exception("Error, Something was wrong. \nActual X:" + point.y + "\nPrevious X:" + point.previousY);
        }

        /// <summary>
        /// Check previous position for one point
        /// Method: getPreviousPosition()
        /// </summary>
        [TestMethod]
        public void CheckPreviousPosition()
        {
            object sender = game.startPause.Text;

            game.startPause_Click(sender, EventArgs.Empty);
            System.Threading.Thread.Sleep(800);

            var pointActual = game.tetris.activeTetromino.Points[1];
            var pointPrevious = game.tetris.activeTetromino.Points[1].getPreviousPosition();

            if (pointActual.y == (pointPrevious.y + 1))
                Assert.IsTrue(true);
            else
                throw new Exception("Error, Something was wrong. \nPrevious Y: " + pointPrevious.y + ", actual Y: " + pointActual.y);
        }
    }
}
