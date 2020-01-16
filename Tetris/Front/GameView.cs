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
    public partial class GameView : Form
    {
        public Tetris tetris;
        public SolidBrush brush;

        public GameView()
        {
            InitializeComponent();
            this.KeyPreview = true;
            tetris = new Tetris(10, 20, new TetrisEventImp(this));
            brush = new SolidBrush(Color.Gray);
        }

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

            public TetrisEventImp(GameView game)
            {
                this.gameView = game;
            }

            public void onBlockChange()
            {
                gameView.game.Invalidate();
            }

            public void onGameOver()
            {
                MessageBox.Show("Przegrana");
            }

            public void onPointsChange(int points, int tetris)
            {
                //gameView.lines.Text = points.ToString();
            }
        }

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
