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
    /// Interaction logic for the MainWindow.xaml class
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Game object
        /// </summary>
        public Tetris tetris;
        public MainWindow()
        {
            InitializeComponent();
            tetris = new Tetris(10, 20, new TetrisEventImp(this));
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        /// <summary>
        /// Moving or rotating the brick using the A, D, S, W, M buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Declaration of button changes - after starting the game by pressing "Start Game"
        /// button changes the word "Start" to "Pause".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Button reset/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            tetris.setUp();
            startBtn.Content = "Start Game";
        }

        /// <summary>
        /// Rendering.
        /// </summary>
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

                    int rectSize = 29;
                    Rectangle rect = new Rectangle();
                    rect.Fill = new SolidColorBrush(Color.FromRgb(field.Color.R, field.Color.G, field.Color.B));
                    rect.Width = rect.Height = rectSize;
                    Canvas.SetLeft(rect, (rectSize * x) + (1 * x));
                    Canvas.SetTop(rect, (rectSize * y) + (1 * y));
                    game.Children.Add(rect);
                }
            }
        }

      
        class TetrisEventImp : TetrisEvent
        {
            MainWindow mainWindow;

            /// <summary>
            ///  Constructor for the TetrisEcentImp class.
            /// </summary>
            /// <param name="game"></param>
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

            /// <summary>
            /// Displays a window with information after the game.
            /// </summary>
            public void onGameOver()
            {
                MessageBox.Show("Przegrana");
            }

            /// <summary>
            /// Current display of the sum of points scored.
            /// </summary>
            /// <param name="points"></param>
            /// <param name="tetris"></param>
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
