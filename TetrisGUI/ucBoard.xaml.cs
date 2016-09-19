using System;
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

namespace TetrisGUI
{
    /// <summary>
    /// Interaction logic for ucBoard.xaml
    /// </summary>
    public partial class ucBoard : UserControl
    {
        public const int GRID_SIZE = 20;
        private Rectangle[,] _board = new Rectangle[GRID_SIZE, GRID_SIZE];

        public ucBoard()
        {
            InitializeComponent();
            drawBoard();
        }

        public Rectangle[,] Grid
        {
            get { return _board; }
            set { _board = value; }
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
                    //r.Fill = Brushes.Blue;

                    _board[x, y] = r;
                    board.Children.Add(r);
                }
            }
        }

    }
}
