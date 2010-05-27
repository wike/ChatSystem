using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using Model;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace ChatServer
{
    public class ServerConnection
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private Thread senderThread;
        private UTF8Encoding encoder = new UTF8Encoding();
        private int port;

        private Queue<Message> messageQueueIn;
        private Queue<Message> messageQueueOut;

        private Hashtable htClients;

        public ServerConnection() {
            //Initialize needed objects before receiving any connections or data
            htClients = new Hashtable();
            Hashtable.Synchronized(this.htClients);
            messageQueueIn = new Queue<Message>();
            messageQueueOut = new Queue<Message>();
        }

        public ServerConnection(int port) : this()
        {
            //Start listening
            this.port = port;
            tcpListener = new TcpListener(IPAddress.Any, this.port);
            
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();

            senderThread = new Thread(new ThreadStart(HandleIncommingMessages));
            senderThread.Start();
        }

        /// <summary>
        /// Adds message into the incoming message queue
        /// </summary>
        /// <param name="message">Message object to be send</param>
        public void queueMessageIn(Message message) {
            messageQueueIn.Enqueue(message);
        }

        /// <summary>
        /// Gets the message from the incoming message queue
        /// </summary>
        /// <returns>Returns message in the beginning of the message queue</returns>

        public Message dequeueMessageIn() {
            return messageQueueIn.Dequeue();
        }

        /// <summary>
        /// Add message into the outgoing message queue
        /// </summary>
        /// <param name="message">Message to queue</param>
        public void queueMessageOut(Message message) {
            messageQueueOut.Enqueue(message);
        }

        /// <summary>
        /// Get message from the outgoing message queue
        /// </summary>
        /// <returns>Message in the beginningof the message queue</returns>
        public Message dequeueMessageOut() {
            return messageQueueOut.Dequeue();
        }

        private void sendMessages()
        {
            while (messageQueueOut.Count > 0){
                XmlDocument message = messageQueueIn.Dequeue().toXml();
                foreach (DictionaryEntry de in htClients){
                        UTF8Encoding encoder = new UTF8Encoding();
                        byte[] buffer = encoder.GetBytes(message.InnerXml);
                        NetworkStream ns = (NetworkStream)de.Value;
                        ns.Write(buffer, 0, buffer.Length);
                        ns.Flush();
                }
            }
        }

        private void ListenForClients()
        {
            tcpListener.Start();

            while (true){
                //blocks until a client has connected to the server
                TcpClient client = tcpListener.AcceptTcpClient();

                //create a thread to handle communication with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientRequest));
                clientThread.Start(client);
            }
        }

        private void HandleClientRequest(object client)
        {
            TcpClient tcpClient = client as TcpClient;
            NetworkStream clientStream = tcpClient.GetStream();

            htClients.Add(tcpClient, clientStream); //add to client list
            ServerController.Instance.mainForm.addMessage("new client");

            byte[] messageBuffer = new byte[4096];
            int bytesRead = 0;
            String data = null;
            while ((bytesRead = clientStream.Read(messageBuffer, 0, messageBuffer.Length)) != 0)
            {
                data = System.Text.Encoding.UTF8.GetChars(messageBuffer, 0, bytesRead).ToString();

                if (!clientStream.DataAvailable)
                {
                    //the client has disconnected from the server
                    htClients.Remove(tcpClient);
                    tcpClient.Close();
                    break;
                }

                //add the message to the incoming message queue for later use
                queueMessageIn(stringToMessage(data));
                ServerController.Instance.messageCame();
            }
        }

        /// <summary>
        /// Converts raw String to the Message object using deserialization
        /// </summary>
        /// <param name="data">Data to be deserialized</param>
        /// <returns>Message object from the supplied data</returns>
        private Message stringToMessage(String data) { 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Message));
            
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            MemoryStream ms = new MemoryStream(byteArray);
            XmlReader xmlReader = XmlReader.Create(ms);

            Message message = null;
            //here comes the dragons ;) 
            if (xmlSerializer.CanDeserialize(xmlReader)) {
                message = xmlSerializer.Deserialize(xmlReader) as Message;
            }
            
            return message;
        }

        private void HandleIncommingMessages()
        {
            while (true)
            {
                try{
                    //synchronized
                    lock (messageQueueIn)
                    {
                        sendMessages();
                    }
                    //Why?
                    //System.Threading.Thread.Sleep(1000);
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }

        public void listClients()
        {
            foreach (DictionaryEntry de in htClients){
                Console.WriteLine("Entry Key {0} Value {1}", de.Key, de.Value);
            }
        }

        public void closeConnection() {
            tcpListener.Stop();
            listenThread.Abort();
        }
    }
}