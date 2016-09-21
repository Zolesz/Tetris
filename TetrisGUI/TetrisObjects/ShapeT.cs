using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGUI.TetrisObjects
{
    class ShapeT : TetrisObjects.TetrisObject
    {
        public ShapeT(int x, int y) : base(x, y) { }

        int[,] matrix = new int[4, 4] { {0, 0, 0, 0 },
                                        {0, 0, 0, 0 },
                                        {0, 1, 0, 0 },
                                        {1, 1, 1, 0 }};

        public int[,] Matrix
        {
            get
            {
                return matrix;
            }
        }

        public int[] GetCoords()
        {
            return new int[2] { base._coordinateX, base._coordinateY };
        }

        public void drawObject()
        {
            
        }
    }
}
