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
        private Point _position;
        private int _width;
        private int _height;

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

        public Point Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }

        public TetrisObject() { }
        public TetrisObject(Point p)
        {
            _position = p;
        }
    }
}
