using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol
{
    public abstract class AbstractChatMessage : AbstractMessage
    {
        private model.ChatMessage message;

        public AbstractChatMessage(model.ChatMessage message) {
            this.message = message;
        }

        //keyword "new" tells the compiler we want to hide the previous createXML reference
        //reference: http://msdn.microsoft.com/en-us/library/435f1dw2.aspx
        public new string createXML(String type){
            return createXML(type, message.toXML());
        }

        public model.ChatMessage getMessage() {
            return this.message;
        }
    }
}
