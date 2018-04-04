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
    public class MessageQueue_UnitTest
    {
        [TestMethod]
        public void MessageQueue_When2Rovers_Returns2()
        {
            var rover1 = new Rover("Rover 1", string.Join(",", "L,M,L,M,L,M,L,M,M".Split(',').Reverse<string>()));
            var rover2 = new Rover("Rover 2", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',').Reverse<string>()));

            var messageQueue = new MessageQueue(new Rover[] { rover1, rover2 });

            messageQueue.SortNasaMessagesForRovers();

            Assert.AreEqual(messageQueue.RoversOnMarsToList.Count, 2);
              
        }

        [TestMethod]
        public void MessageQueue_WhenMaxMessageLength10_Returns10()
        {
            var rover1 = new Rover("Rover 1", string.Join(",", "L,M,L,M,L,M,L,M,M".Split(',').Reverse<string>()));
            var rover2 = new Rover("Rover 2", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',').Reverse<string>()));

            var messageQueue = new MessageQueue(new Rover[] { rover1, rover2 });
            messageQueue.SortNasaMessagesForRovers();
            Assert.AreEqual(messageQueue.MaxMessages, Math.Max("LMLMLMLMM".Length, "MMRMMRMRRM".Length));

        }


        [TestMethod]
        public void MessageQueue_WhenMessageR1IsLMLMLMLMMAndR2IsMMRMMRMRRM_ReturnsLMMMLRMMLMMRLMMRMRM()
        {
            var rover1 = new Rover("Rover 1", string.Join(",", "L,M,L,M,L,M,L,M,M".Split(',').Reverse<string>()));
            var rover2 = new Rover("Rover 2", string.Join(",", "M,M,R,M,M,R,M,R,R,M".Split(',').Reverse<string>()));

            var messageQueue = new MessageQueue(new Rover[] { rover1, rover2 });

            messageQueue.SortNasaMessagesForRovers();

            
            Assert.AreEqual(messageQueue.ProcessingSequence, "MMRMRLMMRLMMMLRMMLM");
        }
    }
}
