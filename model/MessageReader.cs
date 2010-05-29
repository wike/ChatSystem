using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Xml;
namespace Model
{
    public class MessageReader
    {
        public static XmlDocument readMessage(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] buffer = new byte[4096];
            do
            {
                ns.Read(buffer, 0, buffer.Length);
            } while (ns.DataAvailable);

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(new MemoryStream(buffer));
            return xmldoc;
        }
    }
}
