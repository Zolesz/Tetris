using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace TetrisGUI
{
    public class Tile
    {
        private int _relativeX, _relativeY;
        private bool _locked;
        private Rectangle _rekt;

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

            private set
            {
                _relativeY = value;
            }
        }

        public bool Locked
        {
            get
            {
                return _locked;
            }

            set
            {
                _locked = value;
            }
        }

        public Rectangle Rekt
        {
            get
            {
                return _rekt;
            }
        }

        public Tile()
        {
            _rekt = new Rectangle();
        }

        public Tile(int relativeX, int relativeY)
        {
            RelativeX = relativeX;
            RelativeY = relativeY;
            _rekt = new Rectangle();
        }

    }
}
