namespace ChatClient
{
    partial class Form1
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
            this.gb_users = new System.Windows.Forms.GroupBox();
            this.lb_users = new System.Windows.Forms.ListBox();
            this.bt_send = new System.Windows.Forms.Button();
            this.rt_chat = new System.Windows.Forms.RichTextBox();
            this.rt_message = new System.Windows.Forms.RichTextBox();
            this.gb_users.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_users
            // 
            this.gb_users.Controls.Add(this.lb_users);
            this.gb_users.Location = new System.Drawing.Point(406, 12);
            this.gb_users.Name = "gb_users";
            this.gb_users.Size = new System.Drawing.Size(185, 279);
            this.gb_users.TabIndex = 1;
            this.gb_users.TabStop = false;
            this.gb_users.Text = "Online users";
            // 
            // lb_users
            // 
            this.lb_users.FormattingEnabled = true;
            this.lb_users.Location = new System.Drawing.Point(6, 19);
            this.lb_users.Name = "lb_users";
            this.lb_users.Size = new System.Drawing.Size(170, 251);
            this.lb_users.TabIndex = 1;
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(412, 302);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(179, 51);
            this.bt_send.TabIndex = 2;
            this.bt_send.Text = "Send";
            this.bt_send.UseVisualStyleBackColor = true;
            // 
            // rt_chat
            // 
            this.rt_chat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rt_chat.Location = new System.Drawing.Point(9, 12);
            this.rt_chat.Name = "rt_chat";
            this.rt_chat.Size = new System.Drawing.Size(385, 278);
            this.rt_chat.TabIndex = 3;
            this.rt_chat.Text = "";
            this.rt_chat.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // rt_message
            // 
            this.rt_message.Location = new System.Drawing.Point(6, 299);
            this.rt_message.Name = "rt_message";
            this.rt_message.Size = new System.Drawing.Size(387, 53);
            this.rt_message.TabIndex = 4;
            this.rt_message.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 365);
            this.Controls.Add(this.rt_message);
            this.Controls.Add(this.rt_chat);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.gb_users);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gb_users.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_users;
        private System.Windows.Forms.ListBox lb_users;
        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.RichTextBox rt_chat;
        private System.Windows.Forms.RichTextBox rt_message;
    }
}

