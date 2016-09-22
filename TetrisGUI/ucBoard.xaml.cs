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
    /// <summary>
    /// Interaction logic for ucBoard.xaml
    /// </summary>
    public partial class ucBoard : UserControl
    {
        enum eTetrisObjects { shapeI, shapeL, shapeO, shapeT };
        private Rectangle[,] _board;
        //private  _board;
        private int _gridSize;

        public ucBoard()
        {
            InitializeComponent();
        }


        public void initializeBoard(int gridSize)
        {
            _gridSize = gridSize;
            _board = new Rectangle[gridSize, gridSize];
            drawBoard();
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
            board.Children.Clear();
            for (int x = 0; x < _gridSize; x++)
            {
                for (int y = 0; y < _gridSize; y++)
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

        //Have to rethink this
        public void drawTetrisObject(ShapeT input)
        {
            if (input.X > _gridSize || input.X < 0 || input.Y < -4 || input.Y > _gridSize - 4)
            {
                throw new Exception("x or y coordinate is out of bound");
            }

            clearBoard();

            int tileRow = 0;
            //int tileCol = 0;
            bool entered = false;
            ShapeT testObject = input;

            //testObject.drawObject();

            for (int i = 0; i < TetrisObject._matrixDim; i++)
            {
                for (int j = 0; j < TetrisObject._matrixDim; j++)
                {
                    if(testObject.Matrix[i, j] == 1)
                    {
                        if (tileRow + input.Y >= 0 && tileRow + input.Y < _gridSize)
                            _board[tileRow + input.Y, j + input.X].Fill = Brushes.Black;
                        entered = true;
                    }
                }
                if (entered)
                {
                    tileRow++;
                }
            }

            UpdateBoard();
        }

        public void clearBoard()
        {
            for(int i = 0; i < _gridSize; i++)
            {
                for(int j = 0; j < _gridSize; j++)
                {
                    _board[i, j].Fill = Brushes.White;
                }
            }
        }

    }
}
