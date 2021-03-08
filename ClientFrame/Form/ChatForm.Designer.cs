namespace ClientFrame
{
    partial class ChatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChatIDLabel = new System.Windows.Forms.Label();
            this.ChatName = new System.Windows.Forms.Label();
            this.ChatRefreshButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ChatUserList = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ChatShowBox = new System.Windows.Forms.RichTextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ChatClearButton = new System.Windows.Forms.Button();
            this.ChatSendButton = new System.Windows.Forms.Button();
            this.ChatInputBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ChatIDLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 77);
            this.panel1.TabIndex = 0;
            // 
            // ChatIDLabel
            // 
            this.ChatIDLabel.AutoSize = true;
            this.ChatIDLabel.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatIDLabel.ForeColor = System.Drawing.Color.White;
            this.ChatIDLabel.Location = new System.Drawing.Point(12, 12);
            this.ChatIDLabel.Name = "ChatIDLabel";
            this.ChatIDLabel.Size = new System.Drawing.Size(150, 49);
            this.ChatIDLabel.TabIndex = 0;
            this.ChatIDLabel.Text = "label1";
            // 
            // ChatName
            // 
            this.ChatName.AutoSize = true;
            this.ChatName.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChatName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ChatName.Location = new System.Drawing.Point(8, 1);
            this.ChatName.Name = "ChatName";
            this.ChatName.Size = new System.Drawing.Size(94, 36);
            this.ChatName.TabIndex = 1;
            this.ChatName.Text = "label1";
            this.ChatName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChatRefreshButton
            // 
            this.ChatRefreshButton.BackColor = System.Drawing.Color.White;
            this.ChatRefreshButton.FlatAppearance.BorderSize = 0;
            this.ChatRefreshButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.ChatRefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChatRefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("ChatRefreshButton.Image")));
            this.ChatRefreshButton.Location = new System.Drawing.Point(109, 616);
            this.ChatRefreshButton.Name = "ChatRefreshButton";
            this.ChatRefreshButton.Size = new System.Drawing.Size(60, 60);
            this.ChatRefreshButton.TabIndex = 0;
            this.ChatRefreshButton.UseVisualStyleBackColor = false;
            this.ChatRefreshButton.Click += new System.EventHandler(this.ChatRefreshButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.ChatRefreshButton);
            this.panel2.Controls.Add(this.ChatUserList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(178, 685);
            this.panel2.TabIndex = 1;
            // 
            // ChatUserList
            // 
            this.ChatUserList.BackColor = System.Drawing.SystemColors.Window;
            this.ChatUserList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChatUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatUserList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ChatUserList.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChatUserList.FormattingEnabled = true;
            this.ChatUserList.ItemHeight = 65;
            this.ChatUserList.Location = new System.Drawing.Point(0, 0);
            this.ChatUserList.Name = "ChatUserList";
            this.ChatUserList.Size = new System.Drawing.Size(178, 685);
            this.ChatUserList.TabIndex = 0;
            this.ChatUserList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ChatUserList_DrawItem);
            this.ChatUserList.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ChatUserList_MeasureItem);
            this.ChatUserList.SelectedIndexChanged += new System.EventHandler(this.ChatUserList_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ChatShowBox);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(178, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(804, 454);
            this.panel3.TabIndex = 2;
            // 
            // ChatShowBox
            // 
            this.ChatShowBox.BackColor = System.Drawing.Color.White;
            this.ChatShowBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChatShowBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChatShowBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatShowBox.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChatShowBox.Location = new System.Drawing.Point(0, 43);
            this.ChatShowBox.Name = "ChatShowBox";
            this.ChatShowBox.ReadOnly = true;
            this.ChatShowBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ChatShowBox.Size = new System.Drawing.Size(802, 409);
            this.ChatShowBox.TabIndex = 1;
            this.ChatShowBox.Text = "";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.ChatName);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(802, 43);
            this.panel6.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(203, 714);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(779, 48);
            this.panel5.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel4.Controls.Add(this.ChatClearButton);
            this.panel4.Controls.Add(this.ChatSendButton);
            this.panel4.Controls.Add(this.ChatInputBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(178, 531);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(804, 231);
            this.panel4.TabIndex = 5;
            // 
            // ChatClearButton
            // 
            this.ChatClearButton.BackColor = System.Drawing.Color.White;
            this.ChatClearButton.FlatAppearance.BorderSize = 0;
            this.ChatClearButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.ChatClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChatClearButton.ForeColor = System.Drawing.Color.Transparent;
            this.ChatClearButton.Image = ((System.Drawing.Image)(resources.GetObject("ChatClearButton.Image")));
            this.ChatClearButton.Location = new System.Drawing.Point(667, 168);
            this.ChatClearButton.Name = "ChatClearButton";
            this.ChatClearButton.Size = new System.Drawing.Size(63, 53);
            this.ChatClearButton.TabIndex = 2;
            this.ChatClearButton.UseVisualStyleBackColor = false;
            this.ChatClearButton.Click += new System.EventHandler(this.ChatClearButton_Click);
            // 
            // ChatSendButton
            // 
            this.ChatSendButton.BackColor = System.Drawing.Color.White;
            this.ChatSendButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChatSendButton.BackgroundImage")));
            this.ChatSendButton.FlatAppearance.BorderSize = 0;
            this.ChatSendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.ChatSendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChatSendButton.ForeColor = System.Drawing.Color.Transparent;
            this.ChatSendButton.Location = new System.Drawing.Point(736, 169);
            this.ChatSendButton.Name = "ChatSendButton";
            this.ChatSendButton.Size = new System.Drawing.Size(56, 50);
            this.ChatSendButton.TabIndex = 1;
            this.ChatSendButton.UseVisualStyleBackColor = false;
            this.ChatSendButton.Click += new System.EventHandler(this.ChatSendButton_Click);
            // 
            // ChatInputBox
            // 
            this.ChatInputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChatInputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatInputBox.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChatInputBox.Location = new System.Drawing.Point(0, 0);
            this.ChatInputBox.Multiline = true;
            this.ChatInputBox.Name = "ChatInputBox";
            this.ChatInputBox.Size = new System.Drawing.Size(804, 231);
            this.ChatInputBox.TabIndex = 0;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 762);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 809);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Talk With Your Friends";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button ChatRefreshButton;
        private System.Windows.Forms.Label ChatName;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox ChatInputBox;
        private System.Windows.Forms.Button ChatSendButton;
        private System.Windows.Forms.Button ChatClearButton;
        private System.Windows.Forms.Label ChatIDLabel;
        public System.Windows.Forms.RichTextBox ChatShowBox;
        private System.Windows.Forms.ListBox ChatUserList;
    }
}