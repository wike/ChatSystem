using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;

using Model;
namespace ChatClient
{
    public class Program
    {
        public static void Main()
        {
           // Client2 client = new Client2();
          //  client.sendText("this should be printed and also returned");

            User from = new User();
            User to = new User();

            from.id = 1;
            from.name = "test1";

            from.password = "meh";

            to.id = 2;
            to.name = "test2";
            to.password = "qwe";

            ChatMessage msg = new ChatMessage();
            msg.from = from;
            msg.to = to;
            msg.content = "Hello";
            msg.toXml();
            //System.Console.Write("{0}",msg.toXml());
            System.Console.ReadKey();
        }
    }
}
