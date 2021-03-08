using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientFrame
{
    public partial class ChatForm : Form
    {
        public static ChatForm chatform;
        private delegate void myInvoke(); //代理
        public ChatForm()
        {
            InitializeComponent();
            chatform = this;
            ChatName.Text = String.Empty;
            ChatIDLabel.Text = "Hello," + GlobalParams.ID.ToString();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            //这他妈是我这个项目最“牛逼”的地方【狗头】
            GlobalParams.ClientMyself.newThreadConnect();

            Message msg = new Message();
            msg.MessageType = "Refresh";
            msg.ID = GlobalParams.ID;
            string JsonStr = JsonConvert.SerializeObject(msg, Formatting.Indented);
            //将刷新信息发送给服务器
            GlobalParams.ClientMyself.SendMessage(JsonStr);

            Thread.Sleep(100);
            this.RefreshUserList();

        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("你确定要退出吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                this.FormClosing -= new FormClosingEventHandler(this.ChatForm_FormClosing); //这里是  -=
                Application.Exit();  //退出进程
                Process.GetCurrentProcess().Kill();
            }

            else
            {
                e.Cancel = true;  //取消。返回窗体
            }
        }//窗口关闭函数结束

        private void ChatUserList_MeasureItem(object sender, MeasureItemEventArgs e)
        {

        }

        //重绘用户列表
        private void ChatUserList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if(ChatUserList.Items.Count > 0)
            {
                this.ChatUserList.ItemHeight = 65;     //高度

                int index = e.Index;//获取当前要进行绘制的行的序号，从0开始。
                Graphics g = e.Graphics;//获取Graphics对象。
                Rectangle bound = e.Bounds;//获取当前要绘制的行的一个矩形范围。
                string text = ChatUserList.Items[index].ToString();//获取当前要绘制的行的显示文本。

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    g.DrawRectangle(Pens.Black, bound.Left, bound.Top, bound.Width - 1, bound.Height - 1);
                    Rectangle rect = new Rectangle(bound.Left, bound.Top, bound.Width, bound.Height);
                    //绘制选中时要显示的灰色背景。
                    g.FillRectangle(Brushes.Gainsboro, rect);

                    Font f = new Font("微软雅黑", 20, FontStyle.Bold);
                    Brush myBrush = Brushes.Black;          //初始化字体颜色=黑色
                    StringFormat strFmt = new System.Drawing.StringFormat();
                    strFmt.Alignment = StringAlignment.Center; //文本垂直居中
                    strFmt.LineAlignment = StringAlignment.Center; //文本水平居中
                    e.Graphics.DrawString(ChatUserList.Items[e.Index].ToString(), f, myBrush, e.Bounds, strFmt);
                }
                else
                {
                    g.DrawRectangle(Pens.Blue, bound.Left, bound.Top, bound.Width - 1, bound.Height - 1);
                    Rectangle rect = new Rectangle(bound.Left, bound.Top, bound.Width, bound.Height);
                    //未选中的是白色背景。
                    g.FillRectangle(Brushes.White, rect);

                    Font f = new Font("微软雅黑", 16, FontStyle.Regular);
                    Brush myBrush = Brushes.Black;          //初始化字体颜色=黑色
                    StringFormat strFmt = new System.Drawing.StringFormat();
                    strFmt.Alignment = StringAlignment.Center; //文本垂直居中
                    strFmt.LineAlignment = StringAlignment.Center; //文本水平居中
                    e.Graphics.DrawString(ChatUserList.Items[e.Index].ToString(), f, myBrush, e.Bounds, strFmt);
                }
            }
           

        }   //ChatUserList_DrawItem函数结束

        //重绘聊天信息展示窗口
        private void ChatShowBox_DrawItem(object sender, DrawItemEventArgs e)
        {
        }

        private void ChatUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ChatUserList.SelectedIndex;
            if(index != -1)
            {
                string Name = ChatUserList.SelectedItem.ToString();
                string content = GlobalParams.UserList[index].Name.ToString() + " " +
                                           GlobalParams.UserList[index].ID.ToString() + " " +
                                           GlobalParams.UserList[index].Class.ToString();
                ChatName.Text = content;
                GlobalParams.SelectedName = Name;
                //清空输入窗口
                this.ChatInputBox.Clear();
                this.ChatShowBox.Clear();

                //加载聊天记录
                AddNewMessage();
            }
            

        }   //ChatShowBox_DrawItem函数结束

        private void ChatRefreshButton_Click(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(ChatRefreshButton, "刷新用户列表");

            Message msg = new Message();
            msg.MessageType = "Refresh";
            msg.ID = GlobalParams.ID;
            string JsonStr = JsonConvert.SerializeObject(msg, Formatting.Indented);
            //将刷新信息发送给服务器
            GlobalParams.ClientMyself.SendMessage(JsonStr);

            Thread.Sleep(100);
            this.RefreshUserList();
        }//ChatRefreshButton_Click函数结束


        public void showRegisterResult(string str)
        {
            MessageBox.Show(str);
        }

        public void RefreshUserList()
        {
            //遍历系统变量用户列表，然后将用户列表的每一项的Name变量加入listbox
            lock(ChatUserList){
                ChatUserList.Items.Clear();
                foreach (var item in GlobalParams.UserList)
                {
                    ChatUserList.Items.Add(item.Name);
                }
                ChatName.Text = String.Empty;
                //ChatUserList.SelectedIndex = 0;

                if (ChatUserList.Items.Count > 0)
                {
                    ChatUserList.SelectedIndex = 0;
                }
                else
                {
                    ChatShowBox.Clear();
                }
            }
            
        }//RefreshUserList函数结束

        //发送输入文字函数，将用户输入的文字发送给服务器进行转发
        private void ChatSendButton_Click(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(ChatSendButton, "点击发送消息");
            int index = ChatUserList.SelectedIndex;

            if (this.ChatInputBox.Text.Length == 0)
            {
                Console.WriteLine("输入内容为空！");
            }
            else if (index == -1)
            {
                MessageBox.Show("选择一位好友吧！");
            }
            else
            {

                Talk msg = new Talk();
                msg.ID = GlobalParams.ID;
                msg.talkContent = this.ChatInputBox.Text.ToString();
                msg.targetID = GlobalParams.UserList[index].ID.ToString();
                string JsonStr = JsonConvert.SerializeObject(msg, Formatting.Indented);
                Console.WriteLine(JsonStr);
                GlobalParams.ClientMyself.SendMessage(JsonStr);

                //将消息显示在文本框内
                ChatShowBox.AppendText("我："+"\n");
                ChatShowBox.AppendText(this.ChatInputBox.Text +"\n");
                ChatShowBox.AppendText("\n");

                //创建记录类对象
                TalkRecord tr = new TalkRecord();
                tr.SendPerson = "我";
                tr.WithPerson = GlobalParams.UserList[index].Name.ToString();
                tr.Content = this.ChatInputBox.Text.Trim();
                GlobalParams.RecordList.Add(tr);
                //清空输入框
                ChatInputBox.Clear();

                
            }

            

        }//ChatSendButton函数结束

        private void ChatClearButton_Click(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(ChatClearButton, "点击清理消息缓存");

            ChatShowBox.Clear();
            GlobalParams.RecordList.Clear();
        }//ChatClearButton_Click函数结束

        public void AddNewMessage()
        {
            string Name = ChatUserList.SelectedItem.ToString();
            ChatShowBox.Clear();
            //加载聊天记录
            foreach (var item in GlobalParams.RecordList)
            {
                if (Name.Equals(item.WithPerson.ToString()))
                {
                    ChatShowBox.AppendText(item.SendPerson.Trim() +"：" + "\n");
                    ChatShowBox.AppendText(item.Content.ToString() + "\n");
                    ChatShowBox.AppendText("\n");
                }
            }

        }//AddNewMessage函数结束

        //代理函数，用于在线用户变更时，异步控制UserList列表
        public void CheckUserChange()
        {

            if (ChatUserList.InvokeRequired)
            {
                Action action = new Action(RefreshUserList);
                Invoke(action, new object[] { });
                GlobalParams.UserNumber = GlobalParams.UserList.Count();
            }
            else
            {
                this.RefreshUserList();
                GlobalParams.UserNumber = GlobalParams.UserList.Count();
            }

        }//CheckUserChange函数结束

        //使用代理，实时更新聊天信息
        public void NewMessage()
        {
            if (ChatShowBox.InvokeRequired || ChatUserList.InvokeRequired)
            {
                Action action = new Action(AddNewMessage);
                Invoke(action, new object[] { });
            }
            else
            {
                this.AddNewMessage();
            }
        } // NewMessage函数结束



    }
}
