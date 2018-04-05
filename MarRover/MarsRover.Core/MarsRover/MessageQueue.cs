using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{

    public class MessageQueue
    {
        private List<Message> _listMessage;
        private List<Rover> _listRover;

        public List<Rover> RoversOnMarsToList { get { return _listRover.ToArray().ToList();  } }
        public int MaxMessages = 0;
        public string ProcessingSequence = string.Empty;
        public int TotalNASACommands { get { return ProcessingSequence.Length; } }
        public MessageQueue(Rover[] listRover)
        {
            _listMessage = new List<Message>();
            _listRover = new List<Rover>();
            foreach (Rover rover in listRover)
            {
                _listRover.Add(rover);
                rover.Index = _listRover.Count();
            }

            _listRover = _listRover
                      .OrderBy(r => r.GetType().GetProperty("Index").GetValue(r, null))
                      .ToList();

        }

        public Rover GetRoverByID(string ID)
        {
            return RoversOnMarsToList.Find(x => x.ID == ID);
        }

        public Message GetMessage(int index)
        {
            var message = new Message();
            if (index <= _listMessage.Count)
            {
                message = _listMessage[index];
            }
            return message;
        }

        public bool AddMessage(Message message)
        {
            bool success = false;
            if (message.Data != string.Empty && message.Target != null)
            {
                ProcessingSequence += message.Data.ToString();
                _listMessage.Add(message);
                message.Index = _listMessage.Count();
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
            foreach (Rover rover in _listRover)
            {
                MaxMessages = Math.Max(rover.NasaInstructions.Replace(",", string.Empty).Length, MaxMessages);
            }
            
            //If we have no instructions to process... exit
            if (_listRover.Count == 0) return;

            while (stillProcessing)
            {
                if (currentMessageIndex < _listRover.ToArray()[lastRoverIndex].NasaInstructions.Split(',').Count() )
                {
                    var message = new Message
                    {
                        Data = _listRover.ToArray()[lastRoverIndex].NasaInstructions.Split(',').ToList()[currentMessageIndex],
                        Target = _listRover.ToArray()[lastRoverIndex]
                    };
                    AddMessage(message);
                }
                lastRoverIndex++;
                if (lastRoverIndex == _listRover.Count)
                {
                    lastRoverIndex = 0;
                    currentMessageIndex++;
                }
                if (currentMessageIndex >= MaxMessages)
                {
                    stillProcessing = false;
                }
            }
            _listMessage = _listMessage
              .OrderBy(r => r.GetType().GetProperty("Index").GetValue(r, null))
              .ToList();
        }
    }
}
