﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    /// <summary>
    /// MessageQueue Object. This object will keep all messages from Nasa, Sort them, and ensure that they are played back in sequential order for any number of Rovers.
    /// </summary>
    public class MessageQueue
    {
        private List<Message> _listMessage;
        private List<Rover> _listRover;

        public List<Rover> RoversOnMarsToList { get { return _listRover.ToArray().ToList();  } }
        public int MaxMessages = 0;
        public string ProcessingSequence = string.Empty;
        public int TotalNASACommands { get { return ProcessingSequence.Length; } }
        /// <summary>
        /// MessageQueue Constructor
        /// </summary>
        /// <param name="listRover"></param>
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

        /// <summary>
        /// Returns a Rover Object By an ID Filter (e.g. "Rover one")
        /// </summary>
        /// <param name="ID">(e.g. "Rover one")</param>
        /// <returns></returns>
        public Rover GetRoverByID(string ID)
        {
            return RoversOnMarsToList.Find(x => x.ID == ID);
        }

        /// <summary>
        /// Returns a Message Based on Index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Message GetMessage(int index)
        {
            var message = new Message();
            if (index <= _listMessage.Count)
            {
                message = _listMessage[index];
            }
            return message;
        }
        /// <summary>
        /// Add a NASA Message to List for Processing
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Alternates between all rovers in a sequencial manner.
        /// The following instructions will be sent to each rover:
        /// Rover one: LMLMLMLMM
        /// Rover two: MMRMMRMRRM
        /// Each rovers movement will be executed sequentially, which means that the second rover won't start to move until the first one has finished moving.
        /// </summary>
        public void SortNasaMessagesForRovers()
        {
            bool stillProcessing = true;
            int lastRoverIndex = 0;//Used to alternate rover
            int currentMessageIndex = 0;
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
