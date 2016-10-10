using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace TetrisGUI
{
    public class Tile
    {
        private Point _relativeCoord;
        private Point _globalCoord;
        private bool _locked;
        private Rectangle _rekt;

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

        public Point RelativeCoord
        {
            get
            {
                return _relativeCoord;
            }

            set
            {
                _relativeCoord = value;
            }
        }

        public Point GlobalCoord
        {
            get
            {
                return _globalCoord;
            }

            set
            {
                _globalCoord = value;
            }
        }

        public Tile()
        {
            _rekt = new Rectangle();
        }

        public Tile(Point relativeCoord, Point globalCoord)
        {
            _relativeCoord = relativeCoord;
            _globalCoord = globalCoord;
            _rekt = new Rectangle();
        }

        internal Tile Clone()
        {
            return new Tile(RelativeCoord, GlobalCoord);
        }
    }
}
