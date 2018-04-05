using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    /// <summary>
    /// This Object holds the Trajectory information as needed by the Rover.
    /// </summary>
    public class Vector
    {
        public Point Axis;
        public OrientationEnum CurrentOrientation;
        public int CurrentOrientationDegrees { get; set; }

        public Vector(Point axis, OrientationEnum orientation)
        {
            this.Axis = axis;
            this.CurrentOrientation = orientation;
        }
        public Vector(int x, int y, OrientationEnum orientation)
        {
            this.Axis = new Point(x, y);
            this.CurrentOrientation = orientation;
        }

        public Vector(int x, int y, int z, OrientationEnum orientation)
        {
            this.Axis = new Point(x, y, z);
            this.CurrentOrientation = orientation;
        }
    }
}
