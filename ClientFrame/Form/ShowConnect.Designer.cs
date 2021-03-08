namespace ClientFrame
{
    partial class ShowConnect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnectedState = new System.Windows.Forms.Label();
            this.CheckConnected = new System.Windows.Forms.Button();
            this.ShowConnectState = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectedState
            // 
            this.ConnectedState.AutoSize = true;
            this.ConnectedState.Location = new System.Drawing.Point(43, 27);
            this.ConnectedState.Name = "ConnectedState";
            this.ConnectedState.Size = new System.Drawing.Size(0, 28);
            this.ConnectedState.TabIndex = 0;
            // 
            // CheckConnected
            // 
            this.CheckConnected.Location = new System.Drawing.Point(274, 52);
            this.CheckConnected.Name = "CheckConnected";
            this.CheckConnected.Size = new System.Drawing.Size(86, 37);
            this.CheckConnected.TabIndex = 1;
            this.CheckConnected.Text = "OK";
            this.CheckConnected.UseVisualStyleBackColor = true;
            this.CheckConnected.Click += new System.EventHandler(this.CheckConnected_Click);
            // 
            // ShowConnectState
            // 
            this.ShowConnectState.AutoSize = true;
            this.ShowConnectState.BackColor = System.Drawing.Color.White;
            this.ShowConnectState.Location = new System.Drawing.Point(43, 27);
            this.ShowConnectState.Name = "ShowConnectState";
            this.ShowConnectState.Size = new System.Drawing.Size(84, 28);
            this.ShowConnectState.TabIndex = 2;
            this.ShowConnectState.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.CheckConnected);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 104);
            this.panel1.TabIndex = 3;
            // 
            // ShowConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(399, 129);
            this.Controls.Add(this.ShowConnectState);
            this.Controls.Add(this.ConnectedState);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ShowConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ShowConnect_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ConnectedState;
        private System.Windows.Forms.Button CheckConnected;
        private System.Windows.Forms.Label ShowConnectState;
        private System.Windows.Forms.Panel panel1;
    }
}