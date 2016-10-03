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

        private Tile[,] _board;
        private TetrisObject _currentTetrisObject;
        private TetrisObjectGenerator _tog = new TetrisObjectGenerator();

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
            _board = new Tile[GRID_SIZE, GRID_SIZE];
            drawBoard();
        }

        public void drawBoard()
        {
            board.Columns = GRID_SIZE;
            board.Rows = GRID_SIZE;
            board.Width = Double.NaN;
            board.Height = Double.NaN;

            for (int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    Tile t = _board[x, y];

                    t = new Tile();
                    t.Rekt.Stroke = Brushes.Black;
                    t.Rekt.StrokeThickness = 2;

                    _board[x, y] = t;
                    board.Children.Add(t.Rekt);
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
                    board.Children.Add(_board[x, y].Rekt);
                }
            }
        }


        public void drawTetrisObject()
        {
            clearBoard();

            foreach (Tile t in CurrentTetrisObject.Shape)
            {
                if (CurrentTetrisObject.Position.Y - t.RelativeCoord.Y >= 0 && CurrentTetrisObject.Position.X + t.RelativeCoord.X >= 0)
                    _board[(int)(CurrentTetrisObject.Position.Y - t.RelativeCoord.Y), (int)(CurrentTetrisObject.Position.X + t.RelativeCoord.X)].Rekt.Fill = Brushes.Black;
            }

            UpdateBoard();
        }

        public void clearBoard()
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    if (!_board[i, j].Locked)
                        _board[i, j].Rekt.Fill = Brushes.White;
                }
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            int tempCoordX = (int)CurrentTetrisObject.Position.X;
            int tempCoordY = (int)CurrentTetrisObject.Position.Y;

            if (e.Key == Key.Down)
            {
                tempCoordY++;
                validateDownMove(tempCoordX, tempCoordY);
            }
            //else if (e.Key == Key.Up)
            //{
            //    tempCoordY--;
            //}
            else if (e.Key == Key.Left)
            {
                tempCoordX--;
                validateLeftMove(tempCoordX, tempCoordY);
            }
            else if (e.Key == Key.Right)
            {
                tempCoordX++;
                validateRightMove(tempCoordX, tempCoordY);
            }
            else
            {
                return;
            }

            //if (validateMove(tempCoordX, tempCoordY))
            //{
            //    CurrentTetrisObject.CoordinateX = tempCoordX;
            //    CurrentTetrisObject.CoordinateY = tempCoordY;
            //    drawTetrisObject();

            //    if (isCurrentTetrisObjectLanded())
            //    {
            //        lockCurrentTetrisObjectTiles();
            //        CurrentTetrisObject = _tog.getRandomObject();
            //    }
            //}

            //isInsideBorders(tempCoordX, tempCoordY);
        }

        //split this inside the validate functions?
        public bool isInsideBorders(int coordX, int coordY)
        {
            if (coordY > GRID_SIZE - 1 || coordY < -CurrentTetrisObject.Height + 1 ||
               coordX < 0 || coordX > GRID_SIZE - CurrentTetrisObject.Width)
            {
                return false;
            }

            return true;
        }

        public void startGame()
        {
            System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
            gameTimer.Tick += dispatcherTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 1);
            gameTimer.Start();
        }

        //TODO rethink this because of code duplication, and possible thread safety problems
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            int tempCoordY = (int)CurrentTetrisObject.Position.Y;
            int tempCoordX = (int)CurrentTetrisObject.Position.X;

            tempCoordY++;

            //if (validateMove(tempCoordX, tempCoordY))
            //{
            //    CurrentTetrisObject.CoordinateX = tempCoordX;
            //    CurrentTetrisObject.CoordinateY = tempCoordY;
            //    drawTetrisObject();

            //    if (isCurrentTetrisObjectLanded())
            //    {
            //        lockCurrentTetrisObjectTiles();
            //        CurrentTetrisObject = _tog.getRandomObject();
            //    }
            //}

            validateDownMove(tempCoordX, tempCoordY);

        }

        public bool isCurrentTetrisObjectLanded()
        {
            return CurrentTetrisObject.Position.Y == GRID_SIZE - 1;
        }

        public void lockCurrentTetrisObjectTiles()
        {
            foreach (Tile t in CurrentTetrisObject.Shape)
            {
                _board[(int)(CurrentTetrisObject.Position.Y - t.RelativeCoord.Y), (int)(CurrentTetrisObject.Position.X + t.RelativeCoord.X)].Locked = true;
            }
        }

        //check borders too
        //TODO define a center of rotation in each TetrisObject?
        //TODO define global Coords in Tile?

        public void validateLeftMove(int coordX, int coordY)
        {
            //just simply iterate through the block and check if the new position of the tiles is locked or not
            foreach(Tile t in CurrentTetrisObject.Shape)
            {
                //if(CurrentTetrisObject.)
            }
        }

        public void validateRightMove(int coordX, int coordY)
        {

        }

        //possible lock here
        public void validateDownMove(int coordX, int coordY)
        {

        }

    }
}
