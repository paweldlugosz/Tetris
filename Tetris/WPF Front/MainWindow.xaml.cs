using System;
using Game;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;

namespace WPF_Front
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Tetris tetris;
        public MainWindow()
        {
            InitializeComponent();
            tetris = new Tetris(10, 20, new TetrisEventImp(this));
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A: tetris.moveLeft(); break;
                case Key.D: tetris.moveRight(); break;
                case Key.S: tetris.moveDown(); break;
                case Key.W: tetris.rotate(); break;
                case Key.M: tetris.flor(); break;
            }
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            game.Focus(); 
            Button btn = (Button)sender;

            if (tetris.Running)
            {
                tetris.pause();
                btn.Content = "Start Game";
            }
            else
            {
                tetris.start();
                btn.Content = "Pause Game";
            }

        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            tetris.setUp();
            startBtn.Content = "Start Game";
        }

        private void render()
        {
            if (tetris == null) return;

            game.Children.Clear();

            for (int x = 0; x < tetris.Width; x++)
            {
                for (int y = 0; y < tetris.Height; y++)
                {
                    Field field = tetris.Board[x, y];
                    if (field.Color == System.Drawing.Color.Transparent) continue;

                    int rectSize = 30;
                    Rectangle rect = new Rectangle();
                    rect.Fill = new SolidColorBrush(Color.FromRgb(field.Color.R, field.Color.G, field.Color.B));
                    rect.Width = rect.Height = rectSize;
                    Canvas.SetLeft(rect, rectSize * x);
                    Canvas.SetTop(rect, rectSize * y);
                    game.Children.Add(rect);
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
                mainWindow.game.Dispatcher.Invoke(new Action(() =>
                {
                    mainWindow.render();
                }));
            }

            public void onGameOver()
            {
                MessageBox.Show("Przegrana");
            }

            public void onPointsChange(int points, int tetris)
            {
                mainWindow.scoreTxt.Dispatcher.Invoke(new Action(() =>
                {
                    mainWindow.scoreTxt.Text = ((tetris * 4 + points) * 100).ToString();
                }));
            }
        }
    }
}
