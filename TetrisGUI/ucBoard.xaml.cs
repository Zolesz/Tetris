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
        public enum MoveType {Down, Left, Right};

        public MoveType _move;
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
                if (t.GlobalCoord.Y >= 0 && t.GlobalCoord.X >= 0)
                    _board[(int)(t.GlobalCoord.Y), (int)(t.GlobalCoord.X)].Rekt.Fill = Brushes.Black;
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
            //LinkedList<Tile> tmpGlobalCoords = CurrentTetrisObject.Shape;
            LinkedList<Tile> tmpGlobalCoords = new LinkedList<Tile>(CurrentTetrisObject.Shape.Select(x => x.Clone()));


            if (e.Key == Key.Down)
            {
                foreach (Tile t in tmpGlobalCoords)
                {
                    t.GlobalCoord = new Point(t.GlobalCoord.X, t.GlobalCoord.Y + 1);
                    if (t.GlobalCoord.Y > GRID_SIZE - 1)
                        return;
                }
                //validateDownMove(tmpGlobalCoords);
                //if (!isValidDownMove(tmpGlobalCoords))
                //    return;

                _move = MoveType.Down;

            }
            else if (e.Key == Key.Left)
            {
                foreach (Tile t in tmpGlobalCoords)
                {
                    t.GlobalCoord = new Point(t.GlobalCoord.X - 1, t.GlobalCoord.Y);
                    if (t.GlobalCoord.X < 0)
                        return;
                }
                //validateLeftMove(tmpGlobalCoords);
                //if (!isValidSideWaysMove(tmpGlobalCoords))
                //    return;

                _move = MoveType.Left;
            }
            else if (e.Key == Key.Right)
            {
                foreach (Tile t in tmpGlobalCoords)
                {
                    t.GlobalCoord = new Point(t.GlobalCoord.X + 1, t.GlobalCoord.Y);
                    if (t.GlobalCoord.X > GRID_SIZE - 1)
                        return;
                }
                //validateRightMove(tmpGlobalCoords);
                //if (!isValidSideWaysMove(tmpGlobalCoords))
                //    return;

                _move = MoveType.Right;
            }

            if (!isValidMove(tmpGlobalCoords))
                return;

            moveHandler(tmpGlobalCoords);
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
            //LinkedList<Tile> tmpGlobalCoords = CurrentTetrisObject.Shape;
            //LinkedList<Tile> tmpGlobalCoords = new LinkedList<Tile>(CurrentTetrisObject.Shape);
            LinkedList<Tile> tmpGlobalCoords = new LinkedList<Tile>(CurrentTetrisObject.Shape.Select(x => x.Clone()));

            foreach (Tile t in tmpGlobalCoords)
            {
                t.GlobalCoord = new Point(t.GlobalCoord.X, t.GlobalCoord.Y + 1);
                if (t.GlobalCoord.Y > GRID_SIZE - 1)
                    return;
            }

            _move = MoveType.Down;

            //validateDownMove(tmpGlobalCoords);
            if (!isValidMove(tmpGlobalCoords))
                return;

            moveHandler(tmpGlobalCoords);

        }

        public bool isCurrentTetrisObjectLanded()
        {
            return CurrentTetrisObject.Position.Y == GRID_SIZE - 1;
        }

        public void lockCurrentTetrisObjectTiles()
        {
            foreach (Tile t in CurrentTetrisObject.Shape)
            {
                _board[(int)(t.GlobalCoord.Y), (int)(t.GlobalCoord.X)].Locked = true;
            }
        }

        //TODO define a center of rotation in each TetrisObject?

        //public void validateLeftMove(LinkedList<Tile> newGlobalCoords)
        //{
        //    //check if the blocks on the new coords are locked and left wall
        //    //put this part to a different function? i sense some redundancy here
        //    foreach (Tile t in newGlobalCoords)
        //    {
        //        if (_board[(int)t.GlobalCoord.Y, (int)t.GlobalCoord.X].Locked)
        //        {
        //            return;
        //        }
        //    }

        //    CurrentTetrisObject.Shape = newGlobalCoords;
        //    drawTetrisObject();
        //}

        //public void validateRightMove(LinkedList<Tile> newGlobalCoords)
        //{

        //    foreach (Tile t in CurrentTetrisObject.Shape)
        //    {
        //        if (_board[(int)t.GlobalCoord.Y, (int)(t.GlobalCoord.X)].Locked)
        //        {
        //            return;
        //        }
        //    }

        //    CurrentTetrisObject.Shape = newGlobalCoords;
        //    drawTetrisObject();

        //}

        //possible lock here
        //public void validateDownMove(LinkedList<Tile> newGlobalCoords)
        //{
        //    foreach (Tile t in newGlobalCoords)
        //    {
        //        if (_board[(int)t.GlobalCoord.Y, (int)t.GlobalCoord.X].Locked || t.GlobalCoord.Y == GRID_SIZE - 1)
        //        {
        //            lockCurrentTetrisObjectTiles();
        //            CurrentTetrisObject = _tog.getRandomObject();
        //            return;
        //        }
        //    }

        //    CurrentTetrisObject.Shape = newGlobalCoords;
        //    drawTetrisObject();
        //}

        public bool isValidMove(LinkedList<Tile> newGlobalCoords)
        {
            if(_move == MoveType.Left || _move == MoveType.Right)
            {
                foreach (Tile t in CurrentTetrisObject.Shape)
                {
                    if (_board[(int)t.GlobalCoord.Y, (int)(t.GlobalCoord.X)].Locked)
                    {
                        return false;
                    }
                }
            }
            else if(_move == MoveType.Down)
            {
                foreach (Tile t in newGlobalCoords)
                {
                    if(t.GlobalCoord.Y > 0)
                    {
                        if (_board[(int)t.GlobalCoord.Y, (int)t.GlobalCoord.X].Locked)
                        {
                            lockCurrentTetrisObjectTiles();
                            CurrentTetrisObject = _tog.getRandomObject();
                            return false;
                        }
                        else if(t.GlobalCoord.Y == GRID_SIZE - 1)
                        {
                            CurrentTetrisObject.Shape = newGlobalCoords;
                            drawTetrisObject();
                            lockCurrentTetrisObjectTiles();
                            CurrentTetrisObject = _tog.getRandomObject();
                            return false;
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Not expected behavior in isValidMove method");
            }

            return true;
        }

        public void moveHandler(LinkedList<Tile> newGlobalCoords)
        {
            if (_move == MoveType.Left || _move == MoveType.Right)
            {
                CurrentTetrisObject.Shape = newGlobalCoords;
            }
            else if (_move == MoveType.Down)
            {
                CurrentTetrisObject.Shape = newGlobalCoords;
            }
            else
            {
                throw new Exception("Not expected behavior in isValidMove method");
            }

            CurrentTetrisObject.Shape = newGlobalCoords;
            drawTetrisObject();
        }

    }
}
