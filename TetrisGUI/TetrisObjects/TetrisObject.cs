using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TetrisGUI.TetrisObjects
{
    public abstract class TetrisObject
    {
        //The bottom left corner of the tetris object
        private int _coordinateX, _coordinateY;
        private int _width;
        private int _height;

        public int CoordinateX
        {
            get
            {
                return _coordinateX;
            }

            set
            {
                _coordinateX = value;
            }
        }

        public int CoordinateY
        {
            get
            {
                return _coordinateY;
            }

            set
            {
                _coordinateY = value;
            }
        }

        //TODO think of an alternative solution
        public virtual int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }

        public virtual int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        public virtual LinkedList<Tile> Shape { get; }

        public TetrisObject() { }
        public TetrisObject(int x, int y)
        {
            CoordinateX = x;
            CoordinateY = y;
        }
    }
}
