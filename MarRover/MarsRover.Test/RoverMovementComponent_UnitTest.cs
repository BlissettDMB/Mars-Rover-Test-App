using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace MarsRover.Test
{
    [TestClass]
    public class RoverMovementComponent_UnitTest
    {
        [TestMethod]
        public void RoverMovementComponent_WhenCompleteTextMatch_ReturnsTrue()
        {

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

            Assert.AreEqual(messageQueue.GetRoverByID("Rover one").ToString(), "Rover one:  1,3, N");
            Assert.AreEqual(messageQueue.GetRoverByID("Rover two").ToString(), "Rover two:  5,1, E");
        }


        [TestMethod]
        public void RoverMovementComponent_WhenMoreThan2Rovers_ReturnsTrue()
        {

            var rover1 = new Rover("Rover one", string.Join(",", "L,M,L,M,L,M,L,M,M".Split(',')), new Vector(new Point(1, 2), OrientationEnum.North));
            var rover2 = new Rover("Rover two", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',')), new Vector(new Point(3, 3), OrientationEnum.East));
            var rover3 = new Rover("Rover three", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',')), new Vector(new Point(3, 3), OrientationEnum.East));
            var rover4 = new Rover("Rover four", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',')), new Vector(new Point(3, 3), OrientationEnum.East));
            var rover5 = new Rover("Rover five", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',')), new Vector(new Point(3, 3), OrientationEnum.East));
            var rover6 = new Rover("Rover six", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',')), new Vector(new Point(3, 3), OrientationEnum.East));
            var rover7 = new Rover("Rover seven", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',')), new Vector(new Point(3, 3), OrientationEnum.East));
            var rover8 = new Rover("Rover eight", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',')), new Vector(new Point(3, 3), OrientationEnum.East));
            var rover9 = new Rover("Rover nine", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',')), new Vector(new Point(3, 3), OrientationEnum.East));
            var rover10 = new Rover("Rover ten", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',')), new Vector(new Point(3, 3), OrientationEnum.East));
            var rover11 = new Rover("Rover eleven", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',')), new Vector(new Point(3, 3), OrientationEnum.East));

            var messageQueue = new MessageQueue(new Rover[] { rover1, rover2, rover3, rover4, rover5, rover6, rover7, rover8, rover9, rover10, rover11 });

            messageQueue.SortNasaMessagesForRovers();


            RoverMovementComponent movementComponent = new RoverMovementComponent(messageQueue);
            movementComponent.ProcessMessages();

            foreach (Rover rover in messageQueue.RoversOnMarsToList)
            {
                System.Diagnostics.Debug.WriteLine(rover.ToString());
            }

            Assert.AreEqual(messageQueue.GetRoverByID("Rover one").ToString(), "Rover one:  1,3, N");
            Assert.AreEqual(messageQueue.GetRoverByID("Rover two").ToString(), "Rover two:  5,1, E");
            Assert.AreEqual(messageQueue.GetRoverByID("Rover three").ToString(), "Rover three:  5,1, E");
            Assert.AreEqual(messageQueue.GetRoverByID("Rover four").ToString(), "Rover four:  5,1, E");
            Assert.AreEqual(messageQueue.GetRoverByID("Rover five").ToString(), "Rover five:  5,1, E");
            Assert.AreEqual(messageQueue.GetRoverByID("Rover six").ToString(), "Rover six:  5,1, E");
            Assert.AreEqual(messageQueue.GetRoverByID("Rover seven").ToString(), "Rover seven:  5,1, E");
            Assert.AreEqual(messageQueue.GetRoverByID("Rover eight").ToString(), "Rover eight:  5,1, E");
            Assert.AreEqual(messageQueue.GetRoverByID("Rover nine").ToString(), "Rover nine:  5,1, E");
            Assert.AreEqual(messageQueue.GetRoverByID("Rover ten").ToString(), "Rover ten:  5,1, E");
            Assert.AreEqual(messageQueue.GetRoverByID("Rover eleven").ToString(), "Rover eleven:  5,1, E");
        }
    }
}
