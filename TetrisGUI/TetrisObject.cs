using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCore
{
    public class TetrisObject
    {
        //TODO
        public class ShapeI
        {
            public int _coordinateX, _coordinateY;

            int[,] shapeI = new int[4, 4] { {1, 0, 0, 0 },
                                            {1, 0, 0, 0 },
                                            {1, 0, 0, 0 },
                                            {1, 0, 0, 0 }};
        }

        int[,] shapeL = new int[4, 4] { {1, 0, 0, 0 },
                                        {1, 0, 0, 0 },
                                        {1, 0, 0, 0 },
                                        {1, 1, 0, 0 }};

        int[,] shapeO = new int[4, 4] { {0, 0, 0, 0 },
                                        {0, 0, 0, 0 },
                                        {0, 1, 1, 0 },
                                        {0, 1, 1, 0 }};

        int[,] shapeT = new int[4, 4] { {0, 0, 0, 0 },
                                        {0, 0, 0, 0 },
                                        {0, 1, 0, 0 },
                                        {1, 1, 1, 0 }};
    }
}
