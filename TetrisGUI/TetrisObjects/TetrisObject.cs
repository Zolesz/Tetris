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

        public TetrisObject() { }
        public TetrisObject(int x, int y)
        {
            CoordinateX = x;
            CoordinateY = y;
        }
    }
}
