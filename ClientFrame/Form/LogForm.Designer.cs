namespace ClientFrame
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.logToRegister = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LogID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LogPassword = new System.Windows.Forms.TextBox();
            this.LogLogin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // logToRegister
            // 
            this.logToRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logToRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.logToRegister.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logToRegister.ForeColor = System.Drawing.Color.White;
            this.logToRegister.Location = new System.Drawing.Point(274, 471);
            this.logToRegister.Name = "logToRegister";
            this.logToRegister.Size = new System.Drawing.Size(327, 52);
            this.logToRegister.TabIndex = 0;
            this.logToRegister.TabStop = false;
            this.logToRegister.Text = "Register";
            this.logToRegister.UseVisualStyleBackColor = false;
            this.logToRegister.Click += new System.EventHandler(this.logToRegister_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.LogExit);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 85);
            this.panel1.TabIndex = 1;
            // 
            // LogExit
            // 
            this.LogExit.BackColor = System.Drawing.Color.Transparent;
            this.LogExit.FlatAppearance.BorderSize = 0;
            this.LogExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.LogExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogExit.Image = ((System.Drawing.Image)(resources.GetObject("LogExit.Image")));
            this.LogExit.Location = new System.Drawing.Point(813, 17);
            this.LogExit.Name = "LogExit";
            this.LogExit.Size = new System.Drawing.Size(50, 50);
            this.LogExit.TabIndex = 2;
            this.LogExit.UseVisualStyleBackColor = false;
            this.LogExit.Click += new System.EventHandler(this.LogExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(94, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thinking makes perfect";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(317, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please Login First";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(387, 114);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label3.Location = new System.Drawing.Point(272, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "学号";
            // 
            // LogID
            // 
            this.LogID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogID.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogID.Location = new System.Drawing.Point(341, 298);
            this.LogID.Name = "LogID";
            this.LogID.Size = new System.Drawing.Size(262, 32);
            this.LogID.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label4.Location = new System.Drawing.Point(272, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码";
            // 
            // LogPassword
            // 
            this.LogPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogPassword.Location = new System.Drawing.Point(341, 355);
            this.LogPassword.Name = "LogPassword";
            this.LogPassword.PasswordChar = '·';
            this.LogPassword.Size = new System.Drawing.Size(262, 32);
            this.LogPassword.TabIndex = 7;
            this.LogPassword.UseSystemPasswordChar = true;
            // 
            // LogLogin
            // 
            this.LogLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.LogLogin.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogLogin.ForeColor = System.Drawing.Color.White;
            this.LogLogin.Location = new System.Drawing.Point(274, 413);
            this.LogLogin.Name = "LogLogin";
            this.LogLogin.Size = new System.Drawing.Size(327, 52);
            this.LogLogin.TabIndex = 8;
            this.LogLogin.TabStop = false;
            this.LogLogin.Text = "Login";
            this.LogLogin.UseVisualStyleBackColor = false;
            this.LogLogin.Click += new System.EventHandler(this.LogLogin_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(875, 571);
            this.Controls.Add(this.LogLogin);
            this.Controls.Add(this.LogPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LogID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.logToRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogForm_FormClosed);
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.Shown += new System.EventHandler(this.LogForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logToRegister;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LogExit;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LogID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LogPassword;
        private System.Windows.Forms.Button LogLogin;
    }
}