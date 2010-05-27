using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ChatClient
{
    public class ClientController
    {
        private static volatile ClientController instance;
        private static object syncRoot = new Object(); //for locking, to avoid deadlocks

        private ClientConnection clientConnection;

        private ClientController()
        {
            
        }

        public static ClientController Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ClientController();
                    }
                }
                return instance;
            }
        }

        public void connect(string ip, int port) {
            clientConnection = new ClientConnection(ip, port);
        }

        public void sendMessage(Message message){
            if (clientConnection != null) {
                clientConnection.sendText(message.toXml().InnerXml);
            }
        }
    }
}
