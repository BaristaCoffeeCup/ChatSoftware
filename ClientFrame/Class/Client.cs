using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientFrame.Class
{
    class Client
    {
        //Client类的几个基本成员变量
        private TcpClient client;
        private NetworkStream streamToServer;
        private const int BufferSize = 8192;
        public IPAddress IP;
        
        //public string ID = String.Empty;
       

        public Client()
        {
            this.IP = GetLocalIP();     //获取本地IP地址
        } // Client初始化结束

        public int ConnectToServer()
        {
            try
            {
                
                client = new TcpClient();
                IPAddress ip = IPAddress.Parse("192.168.1.101");
                
                client.Connect(ip, 8500);   //发出连接申请
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            Console.WriteLine("Server Connected!{0}-》{1}", client.Client.LocalEndPoint, client.Client.RemoteEndPoint);
            //连接服务器后接受服务器传来的数据
            
            Thread newThread = new Thread(new ParameterizedThreadStart(MessageProcess));
            newThread.Start(client);
            
            return 1;
        } //ConnectToServer函数结束

        public void newThreadConnect()
        {
            Thread newThread = new Thread(new ParameterizedThreadStart(MessageProcess));
            newThread.Start(client);
        }


        //发送消息函数
        public void SendMessage(string str)
        {
            NetworkStream streamToServer = this.client.GetStream();
            byte[] temp = Encoding.Unicode.GetBytes(str);
            try
            {
                streamToServer.Write(temp, 0, temp.Length);
                Console.WriteLine("Send {0} Successfully！",str);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Send Fail ！");
                Console.WriteLine(ex.Message);
            }
        }   //SendMessage函数结束


        // 处理服务器传来的消息
        public static void MessageProcess(object ClientMyself)
        {
            TcpClient client = (TcpClient)ClientMyself;
            //接收服务器传来的数据
            byte[] buffer = new byte[8192];
            while (true)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    int num = stream.Read(buffer, 0, buffer.Length);
                    if (num>0)
                    {
                        //将缓存中的字符串取出
                        string str = Encoding.Unicode.GetString(buffer, 0, num);
                        Console.WriteLine("Receive {0}",str);
                        //转换成对应的消息类
                        MessageFromServer msg = JsonConvert.DeserializeObject<MessageFromServer>(str);
                        

                        //判断消息的类型       1.返回消息是注册类消息
                        if (msg.MessageType == "Register")
                        {
                            string result = msg.MessageContent;     //提取消息内容
                            if (result == "1")
                            {
                                Form1.registerForm.showRegisterResult("注册成功！");
                            }
                            else if (result == "0")
                            {
                                Form1.registerForm.showRegisterResult("账号已存在！点击返回进行登录！");
                            }
                            else if (result == "-1")
                            {
                                Form1.registerForm.showRegisterResult("注册失败！");
                            }
                            stream.Flush();
                        }//Register 分支结束

                        //2.返回消息是登录类消息
                        else if(msg.MessageType == "Login")
                        {
                            string result = msg.MessageContent;
                            if (result == "1")
                            {
                                LogForm.logForm.LoginSuccessfully();                            
                            }
                            else if (result == "0")
                            {
                                LogForm.logForm.showRegisterResult("账号不存在！请注册账号！");
                            }
                            else if (result == "-1")
                            {
                                LogForm.logForm.showRegisterResult("密码错误！");
                            }
                            stream.Flush();
                        }//login分支结束

                        //3.返回消息是刷新类信息
                        else if(msg.MessageType == "Refresh")
                        {
                            Console.WriteLine("收到刷新信息");
                            string result = msg.MessageContent;
                            List<User> userList = JsonConvert.DeserializeObject<List<User>>(result);
                            GlobalParams.UserList.Clear();
                            foreach (var item in userList)
                            {
                                if(!item.ID.Trim().Equals(GlobalParams.ID.Trim()))
                                {
                                    GlobalParams.UserList.Add(item);
                                }
                                
                            }
                            for (int i = 0; i < GlobalParams.UserList.Count; i++)
                            {
                                Console.WriteLine(GlobalParams.UserList[i].Name);
                            }

                            Thread t = new Thread(() =>
                            {
                                ChatForm.chatform.CheckUserChange();
                            });
                            t.Start();
                            Thread.Sleep(1000);
                            t.Abort();
                            stream.Flush();
                        }   //Refresh分支结束

                        else if(msg.MessageType == "Report")
                        {
                           
                            Report re = JsonConvert.DeserializeObject<Report>(msg.MessageContent);
                            TalkRecord tk = new TalkRecord();
                            //确定发送用户的姓名
                            foreach(var item in GlobalParams.UserList)
                            {
                                if (item.ID.Trim().Equals(re.SendPersonID.Trim()))
                                {
                                    Console.WriteLine("查询到对应用户！");
                                    tk.SendPerson = item.Name.ToString();
                                    tk.WithPerson = item.Name.ToString();
                                    tk.Content = re.Content.ToString();

                                    break;
                                }
                            }
                            //将聊天记录加入到记录缓存中
                            string str2 = JsonConvert.SerializeObject(tk, Formatting.Indented);
                            GlobalParams.RecordList.Add(tk);
                            Console.WriteLine(GlobalParams.SelectedName);
                            Console.WriteLine(tk.WithPerson);
                            if (GlobalParams.SelectedName.Equals(tk.WithPerson))
                            {
                                Thread t = new Thread(() =>
                                {
                                    ChatForm.chatform.NewMessage();
                                });
                                t.Start();
                                Thread.Sleep(1000);
                                t.Abort();
                            }

                        }//Report分支结束

                        else if(msg.MessageType == "Change")
                        {
                            Message msg1 = new Message();
                            msg1.MessageType = "Refresh";
                            msg1.ID = GlobalParams.ID;
                            string JsonStr = JsonConvert.SerializeObject(msg1, Formatting.Indented);
                            GlobalParams.ClientMyself.SendMessage(JsonStr);

                        }//Change分支结束

                        else if(msg.MessageType == "Test")
                        {
                            Console.WriteLine("收到测试消息");
                            Console.WriteLine(msg.MessageContent);
                        } //Test分支结束
                    }

                    

                    else
                    {
                        throw new Exception("receive no message!");
                    }

                    Array.Clear(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("接收数据失败！");
                    Console.WriteLine(ex.Message);

                }

            }
        }





        // 获取本地IP地址
        public static IPAddress GetLocalIP()
        {
            IPAddress local_ip = null;
            try
            {
                IPAddress[] IPs;
                IPs = Dns.GetHostAddresses(Dns.GetHostName());
                local_ip = IPs.First(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                return local_ip;
            }
            catch (Exception e)
            {
                Console.WriteLine("获取IP地址失败");
                return null;
            }
        }   //GetLocalIP函数结束

    }
}
