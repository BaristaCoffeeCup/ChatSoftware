using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClientFrame
{
    public partial class LogForm : Form
    {

        public static LogForm logForm;

        public LogForm()
        {
            InitializeComponent();
            logForm = this;
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            if (GlobalParams.ifConnect == false)
            {
                //登录界面加载时，初始化客户端对象，尝试连接服务器
                GlobalParams.ConnectState = GlobalParams.ClientMyself.ConnectToServer();
                if (GlobalParams.ConnectState == -1)
                {
                    MessageBox.Show("服务器未响应，连接失败！");
                    Application.ExitThread();
                }
                GlobalParams.ifConnect = true;
            }

        }

        private void LogForm_Shown(object sender, EventArgs e)
        {

        }

        //界面切换函数，切换至注册界面
        private void logToRegister_Click(object sender, EventArgs e)
        {
            Form anotherForm = new Form1();
            this.Hide();
            anotherForm.ShowDialog();
            Application.ExitThread();
        }

        //程序退出
        private void LogExit_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        //登录界面的登录按钮
        private void LogLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Login log = new Login();

                log.ID = LogID.Text.Trim();
                GlobalParams.ID = log.ID;
                log.Password = LogPassword.Text.Trim();
                log.IP = GlobalParams.ClientMyself.IP.ToString();

                //判断是否学号或密码未输入
                if(LogID.Text == String.Empty || LogPassword.Text == String.Empty)
                {
                    if (LogID.Text == String.Empty)
                    {
                        MessageBox.Show("请填写您的学工号！");
                    }
                    else if (LogPassword.Text == String.Empty)
                    {
                        MessageBox.Show("请填写您的密码！");
                    }
                    throw new Exception("登录输入异常！");
                }
                //将注册类信息转换成JSON格式
                string JsonStr = JsonConvert.SerializeObject(log, Formatting.Indented);
                Console.WriteLine(JsonStr);
                //将登录数据发送到服务器
                GlobalParams.ClientMyself.SendMessage(JsonStr);

            }
            catch(Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }

            
        }   //Login_click函数结束

        public void LoginSuccessfully()
        {
            //GlobalParams.ClientMyself.newThread.DisableComObjectEagerCleanup();
            ChatForm anotherform = new ChatForm();
            this.Invoke(new Action(() => Hide()));
            anotherform.ShowDialog();
            Application.ExitThread();
        }

        public void showRegisterResult(string str)
        {
            MessageBox.Show(str);
        }

        private void LogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
