using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{

    /// <summary>
    /// Point Object. 
    /// </summary>
    public class Point
    {
        public int X;
        public int Y;
        public int Z;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Point(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}
