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
            StreamReader streamReader = new StreamReader(client.GetStream());
            String data = "";
            while (!streamReader.EndOfStream)
            {
                data += streamReader.ReadLine();
            }

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(data);
            return xmldoc;
        }
    }
}
