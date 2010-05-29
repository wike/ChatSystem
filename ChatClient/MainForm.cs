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
            rtChat.AppendText(String.Format("You wrote: {0}\n", message.content));
            controller.send(message);
            rtMessage.Clear();
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
            foreach (User user in userList) {
                lbUsers.Items.Add(user.name);
            }
        }

        public void receiveMessage(AbstractMessage message)
        {
            ChatMessage chatMessage = (ChatMessage)message;
            rtChat.AppendText(
                String.Format("{0} => {1} : {2}", 
                chatMessage.from.name,
                chatMessage.to.name,
                chatMessage.content)
            );
        }

        public void update(AbstractMessage message)
        {
            ChatMessage msg = (ChatMessage) message;
            rtChat.AppendText(msg.content+"\n");
        }

        public void setModelController(IClientModel model, IClientController controller)
        {
            this.model = model;
            this.controller = controller;
        }

        #endregion
    }
}
