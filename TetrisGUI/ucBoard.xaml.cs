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
        private Rectangle[,] _board;
        private int _gridSize;

        public ucBoard()
        {
            InitializeComponent();
            drawBoard();
        }


        public void initializeBoard(int gridSize)
        {
            _gridSize = gridSize;
            _board = new Rectangle[gridSize, gridSize];
            drawBoard();
        }


        public Rectangle[,] Board
        {
            get { return _board; }
            set { _board = value; } //Dont know if this is neccessary
        }

        public void drawBoard()
        {
            board.Columns = _gridSize;
            board.Rows = _gridSize;
            board.Width = Double.NaN;
            board.Height = Double.NaN;

            //populate grid
            for (int x = 0; x < _gridSize; x++)
            {
                for (int y = 0; y < _gridSize; y++)
                {
                    Rectangle r = _board[x, y];

                    r = new Rectangle();
                    r.Stroke = Brushes.Black;
                    r.StrokeThickness = 2;
                    //r.Width = CELL_SIZE;
                    //r.Height = CELL_SIZE;

                    _board[x, y] = r;
                    board.Children.Add(r);
                }
            }
        }

        public void UpdateBoard()
        {
            board.Children.RemoveRange(0, _gridSize * _gridSize);
            for (int x = 0; x < _gridSize; x++)
            {
                for (int y = 0; y < _gridSize; y++)
                {
                    Rectangle r = _board[x, y];
                    board.Children.Add(r);
                }
            }
        }

        public void ChangeTile(int row, int column)
        {
            _board[10, 10].Fill = Brushes.AliceBlue;
            UpdateBoard();
        }

    }
}
