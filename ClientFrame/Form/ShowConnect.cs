using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientFrame
{
    public partial class ShowConnect : Form
    {
        
        public ShowConnect(string str)
        {
            InitializeComponent();
            ShowConnectState.Text = str;
            
        }

        private void CheckConnected_Click(object sender, EventArgs e)
        {
            if (GlobalParams.ConnectState == -1)
            {
                Process.GetCurrentProcess().Kill();
            }
            else if (GlobalParams.ConnectState == 1)
            {
                this.Hide();
            }
            
        }

        private void ShowConnect_Load(object sender, EventArgs e)
        {

        }
    }
}
