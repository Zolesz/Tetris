using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TetrisGUI.TetrisObjects;

namespace TetrisGUI.TetrisObjects
{
    class ShapeL : TetrisObject
    {
        //Tiles are in rowwise order from the bottom left corner
        public static LinkedList<Tile> _shape = new LinkedList<Tile>();
        private int _height = 4;
        private int _width = 2;

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
                return ShapeL._shape;
            }
            set
            {
                ShapeL._shape = value;
            }
        }

        static ShapeL()
        {
            _shape.AddLast(new Tile(new Point(0, 0), new Point(0, 0)));
            _shape.AddLast(new Tile(new Point(1, 0), new Point(1, 0)));
            _shape.AddLast(new Tile(new Point(0, 1), new Point(0, -1)));
            _shape.AddLast(new Tile(new Point(0, 2), new Point(0, -2)));
            _shape.AddLast(new Tile(new Point(0, 3), new Point(0, -3)));
        }
        public ShapeL() { }
        //public ShapeL(Point p) : base(p) { }

    }
}
