using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGUI.TetrisObjects
{
    public class ShapeT : TetrisObject
    {
        public ShapeT() { }
        public ShapeT(int x, int y) : base(x, y) { }

        int[,] _matrix = new int[4, 4] { {0, 0, 0, 0 },
                                        {0, 0, 0, 0 },
                                        {0, 1, 0, 0 },
                                        {1, 1, 1, 0 }};



        public int[,] Matrix
        {
            get { return _matrix; }
            private set { _matrix = value; }
        }

        public int X
        {
            get { return _coordinateX; }
            set { _coordinateX = value; }
        }

        public int Y
        {
            get { return _coordinateY; }
            set { _coordinateY = value; }
        }

        public void drawObject()
        {
            
        }
    }
}
