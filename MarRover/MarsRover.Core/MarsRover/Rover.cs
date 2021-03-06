﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    /// <summary>
    /// Rover Object. Used By the NASA Program
    /// </summary>
    public class Rover
    {
        public string NasaInstructions { get; set; }
        public string ID { get; set; }
        public Vector Heading { get; set; } 
        public int Index { get; set; }
        public TerrainSection CurrentTerrainSection { get; set; }

        public Rover(string ID, string NasaInstructions)
        {
            this.NasaInstructions = NasaInstructions;
            this.ID = ID;
        }
        public Rover(string ID, string NasaInstructions, Vector heading)
        {
            this.NasaInstructions = NasaInstructions;
            this.ID = ID;
            this.Heading = heading;
        }
        public Rover(string ID, string NasaInstructions, Vector heading, int Index)
        {
            this.NasaInstructions = NasaInstructions;
            this.ID = ID;
            this.Heading = heading;
            this.Index = Index;
        }

        public override string ToString()
        {
            string Orientation = Enumerations.GetEnumDescription((OrientationEnum)Heading.CurrentOrientation);
            return String.Format("{0}:  {1},{2}, {3}", ID, Heading.Axis.X, Heading.Axis.Y, Orientation);
        }
    }
}
