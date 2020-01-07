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
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
           
            if (btn.Content.ToString() == "Start Game")
            {
                //do smth when Start Game button is pressed
                btn.Content = "Pause Game";
            }
            else
            {
                //do smth when Pause Game button is pressed
                btn.Content = "Start Game";
            }

        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            //do smth when Reset Game button is pressed
            startBtn.Content = "Start Game";
        }
    }
}
