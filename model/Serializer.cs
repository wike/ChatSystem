using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Serialization;

using System.IO;
namespace Model
{
    class Serializer
    {
        public static XmlDocument serialize<IXmlSerializable>(Object obj) {           
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            XmlDocument xmlDocument = new XmlDocument();

            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    serializer.Serialize(ms, obj);
                    ms.Seek(0, SeekOrigin.Begin);
                    xmlDocument.Load(ms);
                    Console.Write("Debug[xml serialization]:\n{0}\n", xmlDocument.InnerXml.ToString());
                }
                catch (Exception e){
                    Console.Write("{0}", e.Message);
                }
            }
            return xmlDocument;
        }
    }
}
