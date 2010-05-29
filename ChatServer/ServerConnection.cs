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

        private Queue<AbstractMessage> messageQueueIn;
        private Queue<AbstractMessage> messageQueueOut;

        private ArrayList clientList;

        public ServerConnection()
        {
            //Initialize needed objects before receiving any connections or data
            clientList = new ArrayList();
            messageQueueIn = new Queue<AbstractMessage>();
            messageQueueOut = new Queue<AbstractMessage>();
        }

        public ServerConnection(int port)
            : this()
        {
            //Start listening
            this.port = port;
            tcpListener = new TcpListener(IPAddress.Any, this.port);

            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
            /*
                        senderThread = new Thread(new ThreadStart(HandleIncommingMessages));
                        senderThread.Start();
            */
        }

        /// <summary>
        /// Adds message into the incoming message queue
        /// </summary>
        /// <param name="message">Message object to be send</param>
        public void queueMessageIn(AbstractMessage message)
        {
            messageQueueIn.Enqueue(message);
        }

        /// <summary>
        /// Gets the message from the incoming message queue
        /// </summary>
        /// <returns>Returns message in the beginning of the message queue</returns>

        public AbstractMessage dequeueMessageIn()
        {
            return messageQueueIn.Dequeue();
        }

        /// <summary>
        /// Add message into the outgoing message queue
        /// </summary>
        /// <param name="message">Message to queue</param>
        public void queueMessageOut(AbstractMessage message)
        {
            messageQueueOut.Enqueue(message);
        }

        /// <summary>
        /// Get message from the outgoing message queue
        /// </summary>
        /// <returns>Message in the beginningof the message queue</returns>
        public AbstractMessage dequeueMessageOut()
        {
            return messageQueueOut.Dequeue();
        }

        private void ListenForClients()
        {
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                //blocks until a client has connected to the server

                if (client.Connected)
                {
                    clientList.Add(client); //add to client lists

                    ThreadStart clientThread = delegate { new ServerConnection().HandleUserConnection(client); };
                    new Thread(clientThread).Start();
                }
               
            }

        }

        private void HandleUserConnection(TcpClient client)
        {
            ServerController.Instance.mainForm.addMessage("New client connected\n");
            while (true)
            {
                XmlDocument xmlMessage = MessageReader.readMessage(client);
                ChatMessage message = (ChatMessage)MessageParser.parse(xmlMessage);
                //read & process the message
                ServerController.Instance.mainForm.addMessage(String.Format("new message : {0}", message.content));
                sendChatMessageToAll(message);
            }
        }
        /// <summary>
        /// Converts raw String to the Message object using deserialization
        /// </summary>
        /// <param name="data">Data to be deserialized</param>
        /// <returns>Message object from the supplied data</returns>
        private AbstractMessage stringToMessage(String data)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AbstractMessage));

            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            MemoryStream ms = new MemoryStream(byteArray);
            XmlReader xmlReader = XmlReader.Create(ms);

            AbstractMessage message = null;
            //here comes the dragons ;) 
            if (xmlSerializer.CanDeserialize(xmlReader))
            {
                message = xmlSerializer.Deserialize(xmlReader) as AbstractMessage;
            }

            return message;
        }

        public void listClients()
        {
            foreach (User user in clientList)
            {
                Console.WriteLine("Entry Key {0} Value {1}", user.id, user.name);
            }
        }

        public void sendChatMessageToAll(ChatMessage message)
        {
            foreach (TcpClient client in clientList)
            {
                MessageWriter.writeMessage(client, message);
            }
        }

        public void closeConnection()
        {
            tcpListener.Stop();
            listenThread.Abort();
        }
    }
}