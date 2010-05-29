using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using Model;
using System.Net.Sockets;
using System.Xml;
using System.Threading;
using System.Xml.Serialization;
using System.IO;

namespace ChatClient
{
    public class ClientModel : IClientModel
    {
        private LinkedList<IClientView> observerList;

        private TcpClient client;
        private MessageWriter messageWriter;
        private UTF8Encoding encoder;

        public ClientModel()
        {
            observerList = new LinkedList<IClientView>();
            encoder = new UTF8Encoding();
        }

        private void listen()
        {
            StreamReader reader = new StreamReader(client.GetStream());
            AbstractMessage message;
            while (true)
            {
                XmlDocument xmldoc = MessageReader.readMessage(client);
                message = MessageParser.parse(xmldoc);
                notifyObservers(message);
            }
        }

        public void send(AbstractMessage message)
        {
            messageWriter.writeMessage(message);
        }

        #region IClientModel Members

        public void connect(IPAddress ip, int port)
        {
            client = new TcpClient();
            client.Connect(ip, port);

            messageWriter = new MessageWriter(client);
            Thread clientThread = new Thread(new ThreadStart(listen));
            clientThread.Start();
        }

        public Boolean isConnected()
        {
            return client.Connected;
        }

        public void notifyObservers(AbstractMessage message)
        {
            foreach (IClientView view in observerList)
            {
                view.update(message);
            }
        }

        public void removeObserver(IClientView clientView)
        {
            observerList.Remove(clientView);
        }

        public void requestUserList()
        {
            send(new RequestUserListMessage());
        }

        #endregion
    }
}
