using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using forms = System.Windows.Forms;
using Model;
namespace ChatClient
{
    public partial class MainForm : forms.Form
    {
        private ClientController controller;
        
        private MainForm(){
            InitializeComponent();
        }

        public MainForm(ClientController controller) : this() {
            this.controller = controller;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChatMessage message = new ChatMessage();
            message.content = "test";
            controller.sendMessage(message);
        }

        private void MainForm_FormClosed(object sender, forms.FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
