using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGUI
{
    public class Tile
    {
        private int _relativeX, _relativeY;

        public int RelativeX
        {
            get
            {
                return _relativeX;
            }

            set
            {
                _relativeX = value;
            }
        }

        public int RelativeY
        {
            get
            {
                return _relativeY;
            }

            set
            {
                _relativeY = value;
            }
        }

        public Tile(int relativeX, int relativeY)
        {
            RelativeX = relativeX;
            RelativeY = relativeY;
        }

    }
}
