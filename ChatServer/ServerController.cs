using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Model;
namespace ChatServer
{
    //using singleton pattern, thread safe
    //Reference: http://msdn.microsoft.com/en-us/library/ff650316.aspx
    public sealed class ServerController
    {
        //volatile to read value everytime, because it can be r/w from multiple threads
        private static volatile ServerController instance;
        private static object syncRoot = new Object(); //for locking, to avoid deadlocks
        
        private ServerConnection serverConnection;
        public MainForm mainForm { get; set; }

        public Boolean serverStarted
        {
            get;
            private set;
        }
        

        private ServerController()
        {
            serverStarted = false;
        }

        public static ServerController Instance
        {
            get{
                if (instance == null){
                    lock (syncRoot){
                        if (instance == null)
                            instance = new ServerController();
                    }
                }
                return instance;
            }
        }

        public void startServer(int port)
        {
            if (port > 0){
                serverConnection = new ServerConnection(port);
                serverStarted = true;
            }
        }

        public void stopServer() {
            if (this.serverStarted)
            {
                serverConnection.closeConnection();
                serverStarted = false;
            }
        }

        public Message getIncomingMessage() {
            return serverConnection.dequeueMessageIn();
        }

        public void sendMessageOut(Message message) {
            serverConnection.queueMessageOut(message);
        }

        public void messageCame() { 
            Message m;
            while ((m = getIncomingMessage())!= null) {
                mainForm.addMessage(m.toXml().InnerXml);
            }
        }
    }
}
