using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ChatClient
{
    public class Client2
    {

        private TcpClient client;
        private NetworkStream clientStream;
        private ASCIIEncoding encoder = new ASCIIEncoding();

        private int port = 3001;
        private string ip = "127.0.0.1";

        public Client2()
        {
            this.client = new TcpClient(ip, port);

            clientStream = client.GetStream();

            Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
            clientThread.Start(client);
        }

        private void HandleClientComm(object clients)
        {
            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                if (!clientStream.DataAvailable){
                    //the client has disconnected from the server
                    //htClients.Remove(tcpClient); //need to keep the client list up to date
                    break;
                }

                try{
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }catch{
                    //a socket error has occured
                    break;
                }

                //message has successfully been received
                System.Console.WriteLine(encoder.GetString(message, 0, bytesRead));
            }

            client.Close();
        }

        public void sendText(string txt)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(txt);
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }
    }
}
