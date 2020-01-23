using Front;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CheckButtons
    {
        private readonly GameView game = new GameView();        
        /// <summary>
        /// Check if text on button is "Start" when the game is not running
        /// </summary>
       
        public void CheckTextOnButtonWhenGameIsNotStarted()
        {
            string textOnButton = game.startPause.Text;
            if (textOnButton == "Start")
                Assert.IsTrue(true);
            else
                throw new Exception("The text is not equal 'Start'");
        }

        /// <summary>
        /// Check if text on button is "Pauza" when the game is running
        /// </summary>
        [TestMethod]
        public void CheckTextOnButtonWhenGameIsStarted()
        {
            object sender = game.startPause.Text;

            game.startPause_Click(sender, EventArgs.Empty);
            string textOnButton = game.startPause.Text;
            if (textOnButton == "Pauza")
                Assert.IsTrue(true);
            else
                throw new Exception("The text is not equal 'Pauza'");
        }

        /// <summary>
        /// Check if text on button is "Reset" when the game is running.
        /// </summary>
        [TestMethod]
        public void CheckTextOnResetButton()
        {
            object sender = game.startPause.Text;

            game.startPause_Click(sender, EventArgs.Empty);
            string textOnButton = game.reset.Text;
            if (textOnButton == "Reset")
                Assert.IsTrue(true);
            else
                throw new Exception("The text is not equal 'Reset'");
        }
    }
}