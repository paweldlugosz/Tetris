using System;
using Game;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Forms;

namespace WPF_Front
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Tetris tetris;
        private SolidBrush brush;
        public MainWindow()
        {
            InitializeComponent();
            //this.KeyPreview = true;
            tetris = new Tetris(10, 20, new TetrisEventImp(this));
            //brush = new SolidBrush(Color.Gray);
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            //game.Focus(); 
            System.Windows.Controls.Button btn = (System.Windows.Controls.Button)sender;

            if (btn.Content.ToString() == "Start Game")
            {
                //do smth when Start Game button is pressed
                tetris.start();
                btn.Content = "Pause Game";

            }
            else
            {
                //do smth when Pause Game button is pressed
                tetris.pause();
                btn.Content = "Start Game";
            }

        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            //do smth when Reset Game button is pressed
            tetris.setUp();
            startBtn.Content = "Start Game";
        }

        private void game_Paint(object sender, PaintEventArgs e)
        {
            int rectSize = 30;
            for (int x = 0; x < tetris.Width; x++)
            {
                for (int y = 0; y < tetris.Height; y++)
                {
                    Field field = tetris.Board[x, y];
                    brush.Color = field.Color;
                    e.Graphics.FillRectangle(brush, x * rectSize, y * rectSize, rectSize, rectSize);
                }
            }
        }

        class TetrisEventImp : TetrisEvent
        {
            MainWindow mainWindow;

            public TetrisEventImp(MainWindow game)
            {
                this.mainWindow = game;
            }

            public void onBlockChange()
            {
                //mainWindow.game.Invalidate();
            }

            public void onGameOver()
            {
                System.Windows.MessageBox.Show("Przegrana");
            }

            public void onPointsChange(int points, int tetris)
            {
                //gameView.lines.Text = points.ToString();
            }
        }

        private void GameView_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
