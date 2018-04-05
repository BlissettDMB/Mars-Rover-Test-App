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
        static void Main(string[] args)
        {
            //Refactor 1
            //var rover1 = new Rover("Rover 1", string.Join(",", "L,M,L,M,L,M,L,M,M".Split(',').Reverse<string>()));
            //var rover2 = new Rover("Rover 2", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',').Reverse<string>()));

            //var rover1 = new Rover("Rover one", string.Join(",", "L,M,L,M,L,M,L,M,M".Split(',').Reverse<string>()), new Vector(new Point(1, 2), OrientationEnum.North));
            //var rover2 = new Rover("Rover two", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',').Reverse<string>()), new Vector(new Point(3, 3), OrientationEnum.East));

            //var rover1 = new Rover("Rover 1", string.Join(",", "L,M,L,M,L,M,L,M,M".Split(',')));
            //var rover2 = new Rover("Rover 2", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',')));

            var rover1 = new Rover("Rover one", string.Join(",", "L,M,L,M,L,M,L,M,M".Split(',')), new Vector(new Point(1, 2), OrientationEnum.North));
            var rover2 = new Rover("Rover two", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',')), new Vector(new Point(3, 3), OrientationEnum.East));

            var messageQueue = new MessageQueue(new Rover[] { rover1, rover2 });
            messageQueue.SortNasaMessagesForRovers();
            RoverMovementComponent movementComponent = new RoverMovementComponent(messageQueue);
            movementComponent.ProcessMessages();

            foreach (Rover rover in messageQueue.RoversOnMarsToList)
            {
                System.Diagnostics.Debug.WriteLine(rover.ToString());
            }
            System.Diagnostics.Debug.WriteLine(messageQueue.GetRoverByID("Rover one").ToString());
            System.Diagnostics.Debug.WriteLine("Rover one:  1,3, N");
            System.Diagnostics.Debug.WriteLine(messageQueue.GetRoverByID("Rover two").ToString());
            System.Diagnostics.Debug.WriteLine("Rover two: 5,1, E");



        }
    }
}
