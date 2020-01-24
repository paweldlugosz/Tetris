using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Front
{
    /// <summary>
    /// Declaration of appearance of the game.
    /// </summary>
    public partial class GameView : Form
    {
        public Tetris tetris;
        public SolidBrush brush;

        /// <summary>
        /// Initialization of reading and tetris view.
        /// </summary>
        public GameView()
        {
            InitializeComponent();
            this.KeyPreview = true;
            tetris = new Tetris(10, 20, new TetrisEventImp(this));
            brush = new SolidBrush(Color.Gray);
        }

        /// <summary>
        /// Declaration of buttons inscription change.
        /// After starting the game by pressing "Start" the button changes the word "Start" to "Pause".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void startPause_Click(object sender, EventArgs e)
        {
            game.Focus();
            if (tetris.Running)
            {
                tetris.pause();
                startPause.Text = "Start";
            }
            else
            {
                tetris.start();
                startPause.Text = "Pauza";
            }
        }
        /// <summary>
        /// Defining the appearance of the board. Its dimensions, color etc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void game_Paint(object sender, PaintEventArgs e)
        {
            int rectSize = 30;
            for (int x = 0; x < tetris.Width; x++)
            {
                for (int y = 0; y < tetris.Height; y++)
                {
                    Field field = tetris.Board[x,y];
                    brush.Color = field.Color;
                    e.Graphics.FillRectangle(brush, x * rectSize, y * rectSize, rectSize, rectSize) ;
                }
            }
        }

        
        public class TetrisEventImp : TetrisEvent
        {
            GameView gameView;

            /// <summary>
            /// Constructor for the TetrisEcentImp class.
            /// </summary>
            /// <param name="game"></param>
            public TetrisEventImp(GameView game)
            {
                this.gameView = game;
            }

            public void onBlockChange()
            {
                gameView.game.Invalidate();
            }

            /// <summary>
            /// Displays a window with information after the game.
            /// </summary>
            public void onGameOver()
            {
                MessageBox.Show("Przegrana");
            }

            public void onPointsChange(int points, int tetris)
            {
                //gameView.lines.Text = points.ToString();
            }
        }
        /// <summary>
        /// Resetting buttons.Setting them up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void reset_Click(object sender, EventArgs e)
        {
            tetris.setUp();
            startPause.Text = "Start";
        }

        public void GameView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: tetris.moveLeft(); break;
                case Keys.D: tetris.moveRight(); break;
                case Keys.S: tetris.moveDown(); break;
                case Keys.W: tetris.rotate(); break;
                case Keys.Space: tetris.flor(); break;
            }

        }

    }

}
