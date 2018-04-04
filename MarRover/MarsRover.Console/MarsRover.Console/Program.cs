﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace MarsRover.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var rover1 = new Rover("Rover 1", string.Join(",", "L,M,L,M,L,M,L,M,M".Split(',').Reverse<string>()));
            var rover2 = new Rover("Rover 2", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',').Reverse<string>()));

            var messageQueue = new MessageQueue(new Rover[] { rover1, rover2 });
            messageQueue.SortNasaMessagesForRovers();
            System.Diagnostics.Debug.WriteLine(messageQueue.RoversOnMarsToList.Count);
            System.Diagnostics.Debug.WriteLine(messageQueue.ProcessingSequence); 
            System.Diagnostics.Debug.WriteLine(Math.Max("LMLMLMLMM".Length, "MMRMMRMRRM".Length));



        }
    }
}
