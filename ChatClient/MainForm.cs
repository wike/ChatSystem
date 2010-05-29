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
    public partial class MainForm : forms.Form, IClientView
    {
        private IClientModel model;
        private IClientController controller;

        private MainForm(){
            InitializeComponent();
        }

        public MainForm(IClientController controller) : this() {
            this.controller = controller;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChatMessage message = new ChatMessage();
            message.content = rtMessage.Text;
            rtChat.AppendText(message.toXml().InnerXml);
            rtChat.AppendText("\n");
            controller.send(message);
        }

        private void MainForm_FormClosed(object sender, forms.FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        #region IClientView Members

        public void setUserList(LinkedList<User> userList)
        {
            throw new NotImplementedException();
        }

        public void receiveMessage(AbstractMessage message)
        {
            throw new NotImplementedException();
        }

        public void update(AbstractMessage message)
        {
            rtChat.AppendText(message.toXml().ToString());
        }

        public void setModelController(IClientModel model, IClientController controller)
        {
            this.model = model;
            this.controller = controller;
        }

        #endregion
    }
}
