using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Message
    {
        public  string MessageType { get; set; }
        public  string MessageContent { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }

        public Message()
        {
            MessageType = String.Empty;
            MessageContent = String.Empty;
            IP = String.Empty;
            Port = String.Empty;
        }
            
    }

    class Report
    {
        public string SendPersonID { get; set; }
        public string Content { get; set; }
        public Report()
        {
            SendPersonID = String.Empty;
            Content = String.Empty;
        }
    }
}
