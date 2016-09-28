using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
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
using TetrisGUI.TetrisObjects;

namespace TetrisGUI
{
    public partial class ucBoard : UserControl
    {
        public const int GRID_SIZE = 20;

        private Rectangle[,] _board;
        private TetrisObject _currentTetrisObject;

        public TetrisObject CurrentTetrisObject
        {
            get
            {
                return _currentTetrisObject;
            }

            set
            {
                _currentTetrisObject = value;
            }
        }

        public ucBoard()
        {
            InitializeComponent();
        }


        public void initializeBoard()
        {
            _board = new Rectangle[GRID_SIZE, GRID_SIZE];
            drawBoard();
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

                    _board[x, y] = r;
                    board.Children.Add(r);
                }
            }
        }

        public void UpdateBoard()
        {
            board.Children.Clear();
            for (int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    board.Children.Add(_board[x, y]);
                }
            }
        }

        public void ChangeTile(int row, int column)
        {
            _board[row, column].Fill = Brushes.Brown;
            UpdateBoard();
        }

        public void drawTetrisObject()
        {
            clearBoard();

            //drawing
            foreach (Tile t in ShapeT._shape)
            {
                if(CurrentTetrisObject.CoordinateY - t.RelativeY >= 0 && CurrentTetrisObject.CoordinateX + t.RelativeX >= 0)
                    _board[CurrentTetrisObject.CoordinateY - t.RelativeY, CurrentTetrisObject.CoordinateX + t.RelativeX].Fill = Brushes.Black;
            }

            UpdateBoard();
        }

        public void clearBoard()
        {
            for(int i = 0; i < GRID_SIZE; i++)
            {
                for(int j = 0; j < GRID_SIZE; j++)
                {
                    _board[i, j].Fill = Brushes.White;
                }
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Down && CurrentTetrisObject.CoordinateY < GRID_SIZE - 1)
            {
                CurrentTetrisObject.CoordinateY++;
            }
            else if (e.Key == Key.Up && CurrentTetrisObject.CoordinateY > -ShapeT._height + 1)
            {
                CurrentTetrisObject.CoordinateY--;
            }
            else if (e.Key == Key.Left && CurrentTetrisObject.CoordinateX > 0)
            {
                CurrentTetrisObject.CoordinateX--;
            }
            else if (e.Key == Key.Right && CurrentTetrisObject.CoordinateX < GRID_SIZE - ShapeT._width)
            {
                CurrentTetrisObject.CoordinateX++;
            }

            drawTetrisObject();
        }

    }
}
