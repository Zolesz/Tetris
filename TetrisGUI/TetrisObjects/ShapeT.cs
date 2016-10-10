using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TetrisGUI.TetrisObjects
{
    public class ShapeT : TetrisObject
    {
        //Tiles are in rowwise order from the bottom left corner
        private static LinkedList<Tile> _shape = new LinkedList<Tile>();
        private int _height = 2;
        private int _width = 3;

        public override int Height
        {
            get
            {
                return _height;
            }
        }

        public override int Width
        {
            get
            {
                return _width;
            }
        }

        public override LinkedList<Tile> Shape
        {
            get
            {
                return ShapeT._shape;
            }
            set
            {
                ShapeT._shape = value;
            }
        }

        static ShapeT()
        {
            _shape.AddLast(new Tile(new Point(0, 0), new Point(0, 0)));
            _shape.AddLast(new Tile(new Point(1, 0), new Point(1, 0)));
            _shape.AddLast(new Tile(new Point(2, 0), new Point(2, 0)));
            _shape.AddLast(new Tile(new Point(1, 1), new Point(1, -1)));
        }

        //default position is 0, 0
        public ShapeT() {

        }
        //public ShapeT(Point globalCoord) : base(globalCoord) {

        //    foreach(Tile t in Shape)
        //    {

        //    }
        //}

    }
}
