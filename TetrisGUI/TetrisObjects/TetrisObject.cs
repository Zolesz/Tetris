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
        //Should i use property here?
        protected int _coordinateX, _coordinateY;
        public static int _matrixDim = 4;

        public TetrisObject() { }
        public TetrisObject(int x, int y)
        {
            _coordinateX = x;
            _coordinateY = y;
        }
    }
}
