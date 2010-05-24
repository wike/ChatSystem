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
            Client2 client = new Client2();
            client.sendText("this should be printed and also returned");
        }
    }
}
