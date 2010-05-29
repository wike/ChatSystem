using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net;
namespace ChatServer
{
    public partial class MainForm : Form
    {
        public ServerController controller { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(ServerController controller)
            : this()
        {
            this.controller = controller;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (controller.serverStarted)
            {
                rbLog.AppendText("Server going offline => ");
                controller.stopServer();
                rbLog.AppendText("[OK]\n");
                lblStatus.Text = "Server offline";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            rbLog.AppendText("Server starting => ");
            lblStatus.Text = "Server loading";
            int port = 0;
            if (!Int32.TryParse(tbPort.Text, out port))
            {
                MessageBox.Show("Port is not valid");
                return;
            }
            try
            {
                controller.startServer(port);
                rbLog.AppendText("[OK]\n");
                lblStatus.Text = "Server online";
            }
            catch (SocketException exception)
            {
                rbLog.AppendText("[Error]\n");
                rbLog.AppendText("Message: " + exception.Message + "\n");
                lblStatus.Text = "Server offline";
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string hostname = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostAddresses(hostname);
            rbLog.AppendText("Server IP interfaces:\n");
            foreach (IPAddress addr in addresses)
            {
                rbLog.AppendText(addr.ToString() + "\n");
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        public void addMessage(String msg)
        {
            CheckForIllegalCrossThreadCalls = false;
            rbLog.AppendText(msg + "\n");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
