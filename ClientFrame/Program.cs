using ClientFrame.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientFrame
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogForm());



        }


    }

    //全局变量
    public static class GlobalParams
    {
        public static int loadState = 1;
        internal static Client ClientMyself { get; set; } = new Client();
        internal static List<User> UserList { get; set; } = new List<User>();
        internal static List<TalkRecord> RecordList { get; set; } = new List<TalkRecord>();

        public static int ConnectState;
        public static bool ifConnect = false;

        public static string ID = String.Empty;
        public static string SelectedName = String.Empty;
        public static int UserNumber { get; set; } = 0;

    }

    // 接收消息类
    class MessageFromServer
    {
        public string MessageType { get; set; }
        public string MessageContent { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }

        public MessageFromServer()
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

    class TalkRecord
    {
        public string SendPerson { get; set; }
        public string WithPerson { get; set; }
        public string Content { get; set; }

        public TalkRecord()
        {
            SendPerson = String.Empty;
            WithPerson = String.Empty;
            Content = String.Empty;
        }
    }




}
