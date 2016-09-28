using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGUI.TetrisObjects
{
    //include width and height maybe?
    public class ShapeT : TetrisObject
    {
        public static int _height = 2;
        public static int _width = 3;

        //Tiles are in rowwise order from the bottom left corner
        public static LinkedList<Tile> _shape = new LinkedList<Tile>();

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
