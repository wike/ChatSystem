using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
namespace Model
{
    public class RequestUserListMessage : AbstractMessage
    {
        static String command = "RequestUserList";

        public RequestUserListMessage() : base()
        {

        }

        public override XmlDocument toXml()
        {
            return Serializer.serialize<RequestUserListMessage>(this);
        }
    }
}