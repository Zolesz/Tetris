using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGUI.TetrisObjects
{
    class ShapeO : TetrisObjects.TetrisObject
    {
        public ShapeO(int x, int y) : base(x, y) { }

        int[,] shapeO = new int[4, 4] { {0, 0, 0, 0 },
                                        {0, 0, 0, 0 },
                                        {0, 1, 1, 0 },
                                        {0, 1, 1, 0 }};
    }
}
