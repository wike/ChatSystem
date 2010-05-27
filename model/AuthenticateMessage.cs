using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Xml;
using System.Xml.Serialization;
namespace Model
{
    [Serializable]
    public class AuthenticateMessage : Message
    {
        const String command = "authenticate";
        User user;

        /*Avoid empty message*/
        private AuthenticateMessage(){
        }

        public AuthenticateMessage(User user){
            this.user = user;
        }

        public override XmlDocument toXml()
        {
            return Serializer.serialize<ChatMessage>(this);
        }
    }
}
