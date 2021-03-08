using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientFrame
{
    public partial class Form1 : Form
    {
        public static Form1 registerForm;
        
        public Form1()
        {
            InitializeComponent();
            registerForm = this;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //是否显示密码函数
        private void registerShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = registerShowPassword.Checked;
            if (isChecked)
            {
                registerPassword.UseSystemPasswordChar = false;
            }
            else
            {
                registerPassword.UseSystemPasswordChar = true;
            }
        }
        
        //界面切换函数，切换到登录界面
        private void registerButtonBack_Click(object sender, EventArgs e)
        {
            Form anotherForm = new LogForm();
            this.Hide();
            anotherForm.ShowDialog();
            Application.ExitThread();
        }

        //注册函数，点击后生成注册类信息，然后发送给服务器
        private void registerButton_Click(object sender, EventArgs e)
        {

            try
            {
                Register register = new Register();

                register.ID = registerNumber.Text.Trim();
                register.Name = registerName.Text.Trim();
                register.Gender = registerGender.SelectedItem.ToString();
                register.School = registerSchool.Text.Trim();
                register.Class = registerClass.SelectedItem.ToString();
                register.Major = registerMajor.Text.Trim();
                register.Password = registerPassword.Text.Trim();
                register.IP = GlobalParams.ClientMyself.IP.ToString(); 

                //将注册类信息转换成JSON格式
                string JsonStr = JsonConvert.SerializeObject(register, Formatting.Indented);

                Console.WriteLine(JsonStr);
                GlobalParams.ClientMyself.SendMessage(JsonStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("您有未填写的信息。");
                Console.WriteLine(ex.Message);
            }
        }

        //MessageBox输出指定的内容
        public void showRegisterResult(string str)
        {
            MessageBox.Show(str);
        }



    }
}
