using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {
        public string NasaInstructions { get; set; }
        public string ID { get; set; }
        public Rover(string ID, string NasaInstructions)
        {
            this.NasaInstructions = NasaInstructions;
            this.ID = ID;
        }
    }
}
