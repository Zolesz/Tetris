using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGUI.TetrisObjects
{
    class ShapeL : TetrisObjects.TetrisObject
    {
        public ShapeL(int x, int y) : base(x, y) { }

        int[,] shapeL = new int[4, 4] { {1, 0, 0, 0 },
                                        {1, 0, 0, 0 },
                                        {1, 0, 0, 0 },
                                        {1, 1, 0, 0 }};
    }
}
