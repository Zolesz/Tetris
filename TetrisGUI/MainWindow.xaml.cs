using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TetrisGUI
{

    public partial class MainWindow : Window
    {
        private const int GRID_SIZE = 20;
        private Rectangle[,] _board = new Rectangle[GRID_SIZE, GRID_SIZE];


        public MainWindow()
        {
            InitializeComponent();
            drawBoard();

            testLabel.Content = "Test Label";
        }

        public void drawBoard()
        {
            board.Columns = GRID_SIZE;
            board.Rows = GRID_SIZE;
            board.Width = Double.NaN;
            board.Height = Double.NaN;

            //populate grid
            for (int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    Rectangle r = _board[x, y];

                    r = new Rectangle();
                    r.Stroke = Brushes.Black;
                    r.StrokeThickness = 2;
                    //r.Width = CELL_SIZE;
                    //r.Height = CELL_SIZE;
                    r.Fill = Brushes.Blue;

                    _board[x, y] = r;
                    board.Children.Add(r);
                }
            }

        }

        public void doSomething(object sender, RoutedEventArgs e)
        {
            testLabel.Content = "Changed";
            MessageBox.Show("Good boy");
        }

    }
}
