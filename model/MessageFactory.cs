using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Model
{
    class MessageFactory
    {
        public static AbstractMessage createMessage(String type, Hashtable data) {
            switch (data["type"].ToString()) {
                case "chatMessage": return new ChatMessage(); 
                default: return null;
            }
        }
    }
}
