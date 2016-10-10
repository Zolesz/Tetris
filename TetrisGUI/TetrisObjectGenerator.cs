using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            //int rndX = rnd.Next(ucBoard.GRID_SIZE - 3);
            //TODO startY's value should be a variable
            //int startY = -2;
            //Point p = new Point(rndX, startY);

            switch (rndNum)
            {
                case 0:
                    return new ShapeI();
                case 1:
                    return new ShapeL();
                case 2:
                    return new ShapeO();
                case 3:
                    return new ShapeT();
                default:
                    throw new Exception("Something went wrong during TetrisObject generation");
            }
        }
    }
}
