using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGUI.TetrisObjects;

namespace TetrisGUI.TetrisObjects
{
    class ShapeO : TetrisObject
    {
        //Tiles are in rowwise order from the bottom left corner
        private static LinkedList<Tile> _shape = new LinkedList<Tile>();
        private int _height = 2;
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
                return ShapeO._shape;
            }
        }

        static ShapeO()
        {
            _shape.AddLast(new Tile(0, 0));
            _shape.AddLast(new Tile(1, 0));
            _shape.AddLast(new Tile(0, 1));
            _shape.AddLast(new Tile(1, 1));
        }
        public ShapeO() { }
        public ShapeO(int x, int y) : base(x, y) { }

    }
}
