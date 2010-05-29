using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;

namespace Model
{
    public class MessageWriter
    {
        private TcpClient client;

        public MessageWriter(TcpClient client) {
            this.client = client;
        }

        public void writeMessage(AbstractMessage message) {
            StreamWriter writer = new StreamWriter(client.GetStream());
            writer.Write(message.toXml());
            writer.Flush();
           // writer.Close();
        }
    }
}
