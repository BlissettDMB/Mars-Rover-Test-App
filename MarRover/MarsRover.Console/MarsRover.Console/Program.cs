using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace MarsRover.Console
{
    class Program
    {
        /// <summary>
        /// Application Start Point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var rover1 = new Rover("Rover one", string.Join(",", "L,M,L,M,L,M,L,M,M".Split(',')), new Vector(new Point(1, 2), OrientationEnum.North));
            var rover2 = new Rover("Rover two", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',')), new Vector(new Point(3, 3), OrientationEnum.East));

            var messageQueue = new MessageQueue(new Rover[] { rover1, rover2 });
            messageQueue.SortNasaMessagesForRovers();
            RoverMovementComponent movementComponent = new RoverMovementComponent(messageQueue);
            movementComponent.ProcessMessages();

            foreach (Rover rover in messageQueue.RoversOnMarsToList)
            {
                System.Console.WriteLine(rover.ToString());
            }

            System.Console.ReadLine();
        }
    }
}
