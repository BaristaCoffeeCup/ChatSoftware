using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientFrame
{
    class Talk : Message
    {
        public string targetID { set; get; }
        public string talkContent { set; get; }

        public Talk()
        {
            MessageType = "Talk";
            targetID = String.Empty;
            talkContent = String.Empty;
        }

    }
}
