namespace ChatServer
{
    partial class frm_Main
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
            this.lb_users = new System.Windows.Forms.ListBox();
            this.bt_kick = new System.Windows.Forms.Button();
            this.bt_newuser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_users
            // 
            this.lb_users.FormattingEnabled = true;
            this.lb_users.Location = new System.Drawing.Point(25, 62);
            this.lb_users.Name = "lb_users";
            this.lb_users.Size = new System.Drawing.Size(211, 251);
            this.lb_users.TabIndex = 0;
            // 
            // bt_kick
            // 
            this.bt_kick.Location = new System.Drawing.Point(107, 26);
            this.bt_kick.Name = "bt_kick";
            this.bt_kick.Size = new System.Drawing.Size(76, 29);
            this.bt_kick.TabIndex = 1;
            this.bt_kick.Text = "Kick user";
            this.bt_kick.UseVisualStyleBackColor = true;
            // 
            // bt_newuser
            // 
            this.bt_newuser.Location = new System.Drawing.Point(25, 26);
            this.bt_newuser.Name = "bt_newuser";
            this.bt_newuser.Size = new System.Drawing.Size(76, 30);
            this.bt_newuser.TabIndex = 2;
            this.bt_newuser.Text = "New user";
            this.bt_newuser.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Clients online:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP Address:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "Start/Stop";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 375);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_newuser);
            this.Controls.Add(this.bt_kick);
            this.Controls.Add(this.lb_users);
            this.Name = "frm_Main";
            this.Text = "Chat system - Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_users;
        private System.Windows.Forms.Button bt_kick;
        private System.Windows.Forms.Button bt_newuser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

