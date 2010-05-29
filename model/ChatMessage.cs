using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Xml;

namespace Model
{
    [Serializable]
    public class ChatMessage : AbstractMessage
    {
        public int id{ get; set; }
        public User from { get; set; }
        public User to { get; set; }
        public String content { get; set; }
        public EStatus status { get; set; }
        public Room room { get; set; }

        public String toString()
        {
            return String.Format("id={0:d}, from={1:d}, to={2:d}\ncontent={3},\nstatus={4:d}, room={5:d}",
                                  id, from, to, content, this.status, room);
        }

        public override XmlDocument toXml()
        {
            return Serializer.serialize<ChatMessage>(this);
        }
    }
}
