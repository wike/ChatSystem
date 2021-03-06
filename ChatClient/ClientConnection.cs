﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ChatClient
{
    public class ClientConnection
    {

        private TcpClient client;
        private NetworkStream clientStream;
        private UTF8Encoding encoder;

        private int port = 7777;
        private string ip = "127.0.0.1";

        public ClientConnection(String ip, int port)
        {
            encoder = new UTF8Encoding();

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
            byte[] buffer = Encoding.UTF8.GetBytes(txt);
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }
    }
}
