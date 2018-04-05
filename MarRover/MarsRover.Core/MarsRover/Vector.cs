using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Vector
    {
        public Point Axis;
        public Orientation CurrentOrientation;

        public Vector(Point axis, Orientation orientation)
        {
            this.Axis = axis;
            this.CurrentOrientation = orientation;
        }
        public Vector(int x, int y, Orientation orientation)
        {
            this.Axis = new Point(x, y);
            this.CurrentOrientation = orientation;
        }

        public Vector(int x, int y, int z, Orientation orientation)
        {
            this.Axis = new Point(x, y, z);
            this.CurrentOrientation = orientation;
        }
    }
}
