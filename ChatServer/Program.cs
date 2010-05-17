using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections;
using System.Collections.Generic;

namespace ChatServer
{

    public class Program
    {
        public static void Main()
        {
            Server server = new Server(3001);
        }
    }
}
