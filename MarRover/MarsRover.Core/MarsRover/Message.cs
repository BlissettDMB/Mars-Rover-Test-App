using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    /// <summary>
    /// Message Object. Represents a signle Message Entity
    /// </summary>
    public class Message
    {
        //public Message(char data, Rover target) {
        //    this.Data = data;
        //    this.Target = target;
        //}
        public string Data { get; set; }
        public Rover Target { get; set; }
        public int Index { get; set; }
    }
}
