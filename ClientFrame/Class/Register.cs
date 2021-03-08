using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientFrame
{
    class Register : Message
    {

        public string IP { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string School { get; set; }
        public string Class { get; set; }
        public string Major { get; set; }
        public string Password { get; set; }


        //注册类对象构造函数
        public Register()
        {
            MessageType = "Register";
            ID = String.Empty;
            Name = String.Empty;
            Gender = String.Empty;
            School = String.Empty;
            Class = String.Empty;
            Major = String.Empty;
            Password = String.Empty;
            IP = String.Empty;
            
        }

    }
}
