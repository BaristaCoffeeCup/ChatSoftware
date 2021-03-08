using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientFrame
{
    class Login : Message
    {
        public string IP { get; set; }
        public new string ID { get; set; }
        public string Password { get; set; }
        

        public Login()
        {
            MessageType = "Login";
            ID = String.Empty;
            Password = String.Empty;
        }
    }
}
