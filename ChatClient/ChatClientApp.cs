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
            ClientModel model = new ClientModel();
            LoginForm loginForm = new LoginForm(controller);
            controller.setView(loginForm);
            controller.setModel(model);
            loginForm.setModelController(model, controller);
            Application.Run(loginForm);
        }
    }
}
