using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections;
using System.Collections.Generic;

using System.Windows.Forms;
namespace ChatServer
{
    public class Program
    {
        public static void Main()
        {
            ServerController controller = ServerController.Instance;
            MainForm mainForm = new MainForm(controller);
            controller.mainForm = mainForm;
            Application.Run(mainForm);
        }
    }
}
