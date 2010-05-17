using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Net;

namespace ChatServer
{
    public class Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private Hashtable htClients;
        private Queue<string> q;
        private ASCIIEncoding encoder = new ASCIIEncoding();
        private int port;

        public Server(int port)
        {
            this.port = port;
            this.tcpListener = new TcpListener(IPAddress.Any, this.port);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
            this.htClients = new Hashtable();
            Hashtable.Synchronized(this.htClients);
            this.q = new Queue<string>();
            System.Console.WriteLine("Started listening on port: " + this.port);

            Thread thread = new Thread(new ThreadStart(HandleIncommingMessages));
            thread.Start();
        }

        private void HandleIncommingMessages()
        {
            while (true)
            {
                try
                {
                    lock (q)   //synchronized
                    {
                        sendMessages();
                    }
                    System.Threading.Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    break;
                }
            }
        }

        private void sendMessages()
        {
            while (q.Count > 0)
            {
                string text = q.Dequeue();
                foreach (DictionaryEntry de in htClients)
                {
                    try
                    {
                        ASCIIEncoding encoder = new ASCIIEncoding();
                        byte[] buffer = encoder.GetBytes(text);
                        NetworkStream ns = (NetworkStream)de.Value;
                        ns.Write(buffer, 0, buffer.Length);
                        ns.Flush();
                    }
                    catch
                    {
                        //a socket error has occured
                        break;
                    }
                }
            }
        }

        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();

                //create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            htClients.Add(tcpClient, clientStream); //add to client list

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    htClients.Remove(tcpClient);
                    break;
                }

                //message has successfully been received
                System.Console.WriteLine(encoder.GetString(message, 0, bytesRead));

                string theMessage = encoder.GetString(message, 0, bytesRead);
                //send this message to the sending queue
                q.Enqueue(theMessage);
            }

            tcpClient.Close();
        }

        public void listClients()
        {
            foreach (DictionaryEntry de in htClients)
            {
                Console.WriteLine("Entry Key {0} Value {1}", de.Key, de.Value);
            }
        }
    }
}
