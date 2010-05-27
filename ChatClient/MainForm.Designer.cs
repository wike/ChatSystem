namespace ChatClient
{
    partial class MainForm
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
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.rtChat = new System.Windows.Forms.RichTextBox();
            this.rtMessage = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Location = new System.Drawing.Point(562, 12);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(188, 251);
            this.lbUsers.TabIndex = 0;
            // 
            // rtChat
            // 
            this.rtChat.Location = new System.Drawing.Point(12, 12);
            this.rtChat.Name = "rtChat";
            this.rtChat.Size = new System.Drawing.Size(544, 249);
            this.rtChat.TabIndex = 1;
            this.rtChat.Text = "";
            // 
            // rtMessage
            // 
            this.rtMessage.Location = new System.Drawing.Point(12, 267);
            this.rtMessage.Name = "rtMessage";
            this.rtMessage.Size = new System.Drawing.Size(544, 83);
            this.rtMessage.TabIndex = 2;
            this.rtMessage.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 362);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(562, 267);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 362);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.rtMessage);
            this.Controls.Add(this.rtChat);
            this.Controls.Add(this.lbUsers);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.RichTextBox rtChat;
        private System.Windows.Forms.RichTextBox rtMessage;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnSend;
    }
}