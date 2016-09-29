using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        static ShapeT()
        {
            _shape.AddLast(new Tile(0, 0));
            _shape.AddLast(new Tile(1, 0));
            _shape.AddLast(new Tile(2, 0));
            _shape.AddLast(new Tile(1, 1));
        }
        public ShapeT() { }
        public ShapeT(int x, int y) : base(x, y) { }

    }
}
