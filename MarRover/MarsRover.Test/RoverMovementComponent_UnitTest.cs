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
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void RoverMovementComponent_WhenCompleteTextMatch_ReturnsTrue()
        {
            var rover1 = new Rover("Rover one", string.Join(",", "L,M,L,M,L,M,L,M,M".Split(',').Reverse<string>()), new Vector(new Point(1, 2), OrientationEnum.North));
            var rover2 = new Rover("Rover two", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',').Reverse<string>()), new Vector(new Point(3, 3), OrientationEnum.East));

            var messageQueue = new MessageQueue(new Rover[] { rover1, rover2 });

            messageQueue.SortNasaMessagesForRovers();


            RoverMovementComponent movementComponent = new RoverMovementComponent(messageQueue);
            movementComponent.ProcessMessages();

            foreach (Rover rover in messageQueue.RoversOnMarsToList)
            {
                System.Diagnostics.Debug.WriteLine(rover.ToString());
            }

            Assert.AreEqual(messageQueue.GetRoverByID("Rover 1").ToString(), "Rover one:  1,3, N");
            Assert.AreEqual(messageQueue.GetRoverByID("Rover 2").ToString(), "Rover two:  5,1, E");
        }
    }
}
