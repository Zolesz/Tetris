using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGUI.TetrisObjects;

namespace TetrisGUI
{
    class TetrisObjectGenerator
    {
        private Random rnd;

        public TetrisObjectGenerator()
        {
            rnd = new Random();
        }

        public TetrisObject getRandomObject()
        {
            int rndNum = rnd.Next(4);
            int rndX = rnd.Next(ucBoard.GRID_SIZE - 3);
            //TODO startY's value should be a variable
            int startY = -2;

            switch (rndNum)
            {
                case 0:
                    return new ShapeI(rndX, startY);
                case 1:
                    return new ShapeL(rndX, startY);
                case 2:
                    return new ShapeO(rndX, startY);
                case 3:
                    return new ShapeT(rndX, startY);
                default:
                    throw new Exception("Something went wrong during TetrisObject generation");
            }
        }
    }
}
