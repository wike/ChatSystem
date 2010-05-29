using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;
using System.IO;

using System.Xml.Serialization;

namespace Model
{
    public class MessageParser
    {
        public static AbstractMessage parse(XmlDocument message)
        {
            AbstractMessage concreteMessage;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AbstractMessage));
            XmlReader reader = XmlReader.Create(message.InnerText);
            if (xmlSerializer.CanDeserialize(reader))
            {
                concreteMessage = xmlSerializer.Deserialize(reader) as AbstractMessage;
            }
            else
            {
                throw new InvalidOperationException();
            }

            reader.Close();
            return concreteMessage;

        }
    }
}
