using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;

using Model;
using System.Windows.Forms;
namespace ChatClient
{
    public class ChatClientApp
    {
        public static void Main()
        {
            ClientController controller = ClientController.Instance;
            Application.Run(new LoginForm(controller));
        }
    }
}
