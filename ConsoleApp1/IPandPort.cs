using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Collections;

namespace ConsoleApp1
{
    class IPandPort
    {

        //获取本机IP地址
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
        }

        //获取系统已经占用的端口
        public static List<int> PortIsUsed()
        {
            //获取网络连接和通信统计数据信息
            IPGlobalProperties iPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            //获取所有TCP监听程序
            IPEndPoint[] ipsTCP = iPGlobalProperties.GetActiveTcpListeners();
            //获取所有UDP监听程序
            IPEndPoint[] ipsUDP = iPGlobalProperties.GetActiveUdpListeners();
            //获取IPV4传输控制协议TCP连接协议
            TcpConnectionInformation[] tcpConnections = iPGlobalProperties.GetActiveTcpConnections();

            List<int> allPort = new List<int>();
            foreach (IPEndPoint ep in ipsTCP) allPort.Add(ep.Port);
            foreach (IPEndPoint ep in ipsUDP) allPort.Add(ep.Port);
            foreach (TcpConnectionInformation conn in tcpConnections)
            {
                allPort.Add(conn.LocalEndPoint.Port);
            }


            return allPort;
        }

        //检查指定端口是否被占用
        public static bool PortIsAvailable(int port)
        {
            bool check = true;
            List<int> portUsed = PortIsUsed();
            foreach (int p in portUsed)
            {
                if (p == port)
                {
                    check = false;
                    break;
                }
            }

            return check;
        }

        //获取第一个可以使用的端口号
        public static int GetFirstAvailablePort()
        {
            const int MAX_PORT = 65535;
            const int BEGIN_PORT = 5000;
            for (int i = BEGIN_PORT; i < MAX_PORT; i++)
            {
                if (PortIsAvailable(i))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
