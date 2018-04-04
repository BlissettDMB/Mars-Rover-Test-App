using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{

    public class MessageQueue
    {
        private Stack<Message> _queueMessage;
        private Stack<Rover> _queueRover;

        public List<Rover> RoversOnMarsToList { get { return _queueRover.ToArray().ToList();  } }
        public int MaxMessages = 0;
        public string ProcessingSequence = string.Empty;
        public MessageQueue(Rover[] listRover)
        {
            _queueMessage = new Stack<Message>();
            _queueRover = new Stack<Rover>();
            foreach (Rover rover in listRover)
            {
                _queueRover.Push(rover);
            }
            
        }

        public bool AddMessage(Message message)
        {
            bool success = false;
            if (message.Data != string.Empty && message.Target != null)
            {
                ProcessingSequence += message.Data.ToString();
                _queueMessage.Push(message);
                success = true;
            }
            return success;
        }

        public void SortNasaMessagesForRovers()
        {
            //List<char[]> NASAInstructions = new List<char[]>();
            bool stillProcessing = true;
            
            int lastRoverIndex = 0;//Used to alternate rover
            int currentMessageIndex = 0;
            int roverCount = 0;
            foreach (Rover rover in _queueRover)
            {
                //Pay instructions in correct order
                //NASAInstructions.Add(rover.NasaInstructions.Reverse().ToString().ToCharArray());


                MaxMessages = Math.Max(rover.NasaInstructions.Replace(",", string.Empty).Length, MaxMessages);
            }
            
            //If we have no instructions to process... exit
            if (_queueRover.Count == 0) return;

            while (stillProcessing)
            {
                //NASAInstructions[lastRoverInstructionIndex]
                if (currentMessageIndex < _queueRover.ToArray()[lastRoverIndex].NasaInstructions.Split(',').ToList().Count() )
                {
                    var message = new Message
                    {
                        Data = _queueRover.ToArray()[lastRoverIndex].NasaInstructions.Split(',').ToList()[currentMessageIndex],
                        Target = _queueRover.ToArray()[lastRoverIndex]
                    };
                    AddMessage(message);
                }
                lastRoverIndex++;
                if (lastRoverIndex == _queueRover.Count)
                {
                    lastRoverIndex = 0;
                    currentMessageIndex++;
                }
                if (currentMessageIndex >= MaxMessages)
                {
                    stillProcessing = false;
                }
            }
        }
    }
}
