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

        public void drawTetrisObject(int x, int y)
        {
            if(x > _gridSize || x < 0 || y < 0 || y > _gridSize)
            {
                throw new Exception("x or y coordinate is out of bound");
            }

            ShapeT testObject = new ShapeT(x,y);
            //testObject.drawObject();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(testObject.Matrix[i,j] == 1)
                    {
                        //TODO
                        _board[x, y].Fill = Brushes.Black;
                    }
                }
            }
            UpdateBoard();
        }

    }
}
