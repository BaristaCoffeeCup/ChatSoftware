using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace ConsoleApp1
{
    class RemoteClient
    {

        private static byte[] buffer;
        private static byte[] sendbuffer = new byte[8192];
        private const int BufferSize = 8192;
        private static TcpListener listener;
        public static List<TcpClient> clients = new List<TcpClient>();
        public static IPAddress local_ip = null;

        public RemoteClient( )
        {

            buffer = new byte[BufferSize];
            local_ip = IPandPort.GetLocalIP();
            listener = new TcpListener(local_ip, 8500);
            listener.Start();
            Console.WriteLine("Start Listening!");

            listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClient), listener);
            Console.ReadKey();

        }   //RemoteClient

        private static void DoAcceptTcpClient(IAsyncResult State)
        {
            
            //新监听一个客户端
            TcpListener listener = (TcpListener)State.AsyncState;
            TcpClient client = listener.EndAcceptTcpClient(State);
            clients.Add(client);
            //打印连接到服务器的客户端信息
            IPEndPoint IP = (IPEndPoint)client.Client.RemoteEndPoint;
            string IPStr = IP.Address.ToString();
            string PortStr = IP.Port.ToString();
            Console.WriteLine("\nClient Connected! IP: {0} Port: {1}", IPStr, PortStr);

            //新建线程 持续接受该客户端传来的消息
            Thread newThread = new Thread(new ParameterizedThreadStart(MessageProcess));
            newThread.Start(client);

            listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClient), listener);


        } //DoAcceptTcpClient函数结束


        // 用于接收消息，判断消息类型，选择对应的处理函数
        private static void MessageProcess(object reciveclient)
        {
            
            TcpClient client = reciveclient as TcpClient;
            IPEndPoint IP = (IPEndPoint)client.Client.RemoteEndPoint;
            string port = IP.Port.ToString();
            
            
            if(client == null)
            {
                Console.WriteLine("Client{0} is disconnected!", client.Client.RemoteEndPoint);
                client.Close();
                clients.Remove(client);
                return;
            }
            while (true)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    //接受服务器传来的数据，并返回数据长度
                    int num = stream.Read(buffer, 0, buffer.Length);

                    if (num != 0)
                    {
                        string str = Encoding.Unicode.GetString(buffer, 0, num);
                        Console.WriteLine(str);
                        MessageFromClient res = JsonConvert.DeserializeObject<MessageFromClient>(str);
                       

                        //执行注册账号操作
                        if (res.MessageType == "Register")
                        {
                            register res1 = JsonConvert.DeserializeObject<register>(str);
                            int result = GlobalParams.db.InsertNewUser(res1,port);
                            switch (result)
                            {
                                case 1:
                                    Console.WriteLine("注册成功！");
                                    break;
                                case -1:
                                    Console.WriteLine("注册失败！");
                                    break;
                                case 0 :
                                    Console.WriteLine("账号已存在！");
                                    break;
                                default:
                                    break;
                            }

                            //向服务器发送对应的注册操作状态信息
                            Message msg = new Message();
                            msg.MessageType = "Register";
                            msg.MessageContent = result.ToString();
                            msg.IP = IP.Address.ToString();
                            msg.Port = IP.Port.ToString();
                            string strBack = JsonConvert.SerializeObject(msg, Formatting.Indented);     //  message对象转换成JSON字符串
                            Console.WriteLine(strBack);
                            byte[] temp = Encoding.Unicode.GetBytes(strBack);
                            stream = client.GetStream();
                            lock (stream)
                            {
                                stream.Write(temp, 0, temp.Length);
                                stream.Flush();
                                Console.WriteLine("Send register result Successful!");
                            }
                        }//register分支结束

                        else if(res.MessageType == "Login")
                        {
                            login res2 = JsonConvert.DeserializeObject<login>(str);
                            int result = GlobalParams.db.UsersLogin(res2,port);

                            switch (result)
                            {
                                case 1:
                                    Console.WriteLine("{0}登录成功！", res2.ID);
                                    break;
                                case -1:
                                    Console.WriteLine("密码错误！");
                                    break;
                                case 0:
                                    Console.WriteLine("账号不存在！");
                                    break;
                                default:
                                    break;
                            }
                            
                            //向客户端发送对应的登录操作状态信息
                            Message msg = new Message();
                            msg.MessageType = "Login";
                            msg.MessageContent = result.ToString();
                            msg.IP = IP.Address.ToString();
                            msg.Port = IP.Port.ToString();
                            string strBack = JsonConvert.SerializeObject(msg, Formatting.Indented);     //  message对象转换成JSON字符串
                            Console.WriteLine(strBack);
                            byte[] temp = Encoding.Unicode.GetBytes(strBack);
                            stream = client.GetStream();
                            lock (stream)
                            {
                                stream.Write(temp, 0, temp.Length);
                                stream.Flush();
                                Console.WriteLine("Send login result Successful!");
                            }

                            if (result == 1)
                            {
                                GlobalParams.db.StateOfUserChange(IP.Address.ToString(), port, "在线");
                                BroadcastRefresh();
                            }

                        }//login分支结束

                        else if (res.MessageType == "Refresh")
                        {
                            
                            //声明用户列表
                            List<User> UserList = new List<User>();
                            UserList = GlobalParams.db.Userrefresh();
                            Console.WriteLine("现有在线用户{0}人",UserList.Count);
                            string JsonStr = JsonConvert.SerializeObject(UserList, Formatting.Indented);
                            Console.WriteLine(JsonStr);

                            //将更新的用户名单发送给客户端
                            Message msg = new Message();
                            msg.MessageType = "Refresh";
                            msg.MessageContent = JsonStr;
                            msg.IP = IP.Address.ToString();
                            msg.Port = IP.Port.ToString();
                            string strBack = JsonConvert.SerializeObject(msg, Formatting.Indented);
                            Console.WriteLine(strBack);
                            byte[] temp = Encoding.Unicode.GetBytes(strBack);
                            stream = client.GetStream();
                            lock (stream)
                            {
                                stream.Write(temp, 0, temp.Length);
                                stream.Flush();
                                Console.WriteLine("Send refresh result Successful!");
                            }

                        }   //Refresh分支结束

                        else if(res.MessageType == "Talk")
                        {
                            Talk tk = JsonConvert.DeserializeObject<Talk>(str);
                            Console.WriteLine("转发消息：{0}", tk.talkContent);
                            Console.WriteLine("From {0} to {1}", tk.ID, tk.targetID);

                            //查询发送对象的IP地址和端口号
                            IPEndPoint iPEndPointTemp = GlobalParams.db.GetTargetIPandPort(tk.targetID);
                            int index = 0;
                            //遍历当前的客户端列表，查询对应的客户端
                            try
                            {
                                
                                foreach (var item in clients)
                                {
                                    IPEndPoint iptemp = (IPEndPoint)item.Client.RemoteEndPoint;
                                    Console.WriteLine(item.Client.RemoteEndPoint.ToString());
                                    if (iptemp.Address.Equals(iPEndPointTemp.Address) && iptemp.Port.Equals(iPEndPointTemp.Port))
                                    {
                                        Console.WriteLine("确定用户{0}在线", tk.targetID);
                                        index = clients.IndexOf(item);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("确定用户{0}不在线", tk.targetID);
                                    }
                                }
                            }catch(Exception ex)
                            {
                                Console.WriteLine("确定用户在线异常！");
                                Console.WriteLine(ex.Message);
                            }

                            //将准发消息发送给指定用户、
                            try
                            {
                                Report re = new Report();
                                re.SendPersonID = tk.ID;
                                re.Content = tk.talkContent;
                                string str1 = JsonConvert.SerializeObject(re, Formatting.Indented);

                                Message msg = new Message();
                                msg.MessageType = "Report";
                                msg.MessageContent = str1;
                                msg.IP = local_ip.ToString();
                                msg.Port = "8500";
                                string strBack = JsonConvert.SerializeObject(msg, Formatting.Indented);
                                Console.WriteLine(strBack);

                                byte[] temp = Encoding.Unicode.GetBytes(strBack);
                                
                                clients[index].GetStream().Write(temp, 0, temp.Length);
                                Console.WriteLine("Send Report Successful!");

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("转发消息异常！");
                                Console.WriteLine(ex.Message);
                            }
                            

                        }   //Talk分支结束

                    }
                    else
                    {
                        throw new Exception("receive no message!");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Client{0} is disconnected! IP: {0} Port: {1}", IP.Address.ToString(), IP.Port.ToString());
                    GlobalParams.db.StateOfUserChange(IP.Address.ToString(), port,  "离线");
                    
                    if (client != null)
                    {
                        client.Dispose();
                    }
                    client.Close();
                    clients.Remove(client);
                    BroadcastRefresh();
                    Console.WriteLine(ex.Message);
                    break;
                }
                finally
                {
                    Array.Clear(buffer, 0, buffer.Length);
                }
            }
        }   //  MessageProcess 函数结束

        //当有新的用户登录或下线时，向在线的其他用户广播消息，督促其刷新用户列表
        public static void BroadcastRefresh()
        {
            List<User> UserList = new List<User>();
            UserList = GlobalParams.db.Userrefresh();
            Console.WriteLine("现有在线用户{0}人", UserList.Count);
            string JsonStr = JsonConvert.SerializeObject(UserList, Formatting.Indented);

            //将更新的用户名单发送给客户端
            Message msg = new Message();
            msg.MessageType = "Refresh";
            msg.MessageContent = JsonStr;
            msg.IP = local_ip.ToString();
            msg.Port = "8500";
            string strBack = JsonConvert.SerializeObject(msg, Formatting.Indented);
            Console.WriteLine(strBack);
            byte[] temp = Encoding.Unicode.GetBytes(strBack);


            foreach (var item in clients)
            {
                item.GetStream().Write(temp, 0, temp.Length);
            }
        }

        
    }

    //****************************************************************************************************************//

    class MessageFromClient
    {
        public string MessageType { get; set; }
        public string ID { get; set; }
    }

    class register : MessageFromClient
    {
        
        public string IP { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string School { get; set; }
        public string Class { get; set; }
        public string Major { get; set; }
        public string Password { get; set; }
    }

    class login : MessageFromClient
    {
        public string IP { get; set; }
        public string ID { get; set; }
        public string Password { get; set; }
        
    }

    class Talk : MessageFromClient
    {
        public string targetID { set; get; }
        public string talkContent { set; get; }
    }

  
}
