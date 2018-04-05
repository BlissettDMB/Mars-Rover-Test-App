using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    /// <summary>
    /// Terrain Section. Represents an individual Cell on the Mars Terrain.
    /// Also holds a reference to all Rovers that are in the Cell.
    /// </summary>
    public class TerrainSection
    {
        public Point NorthCell { get; set; }
        public Point SouthCell { get; set; }
        public Point WestCell { get; set; }
        public Point EastCell { get; set; }
        public Point Cell { get; set; }
        public List<Rover> Occupiers = new List<Rover>();
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public TerrainSection(int x, int y)
        {
            Cell = new Point(x, y);
            NorthCell = new Point(Cell.X, Cell.Y + 1);
            SouthCell = new Point(Cell.X, Cell.Y - 1);
            WestCell = new Point(Cell.X -1, Cell.Y);
            EastCell = new Point(Cell.X +1, Cell.Y);
        }
    }
}
