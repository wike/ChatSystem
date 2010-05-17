using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace ChatClient
{
    public class Program
    {
        public static void Main()
        {
            Client client = new Client();
            client.sendText("this should be printed and also returned");
        }
    }
}
