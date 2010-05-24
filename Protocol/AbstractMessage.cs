using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol
{
    public abstract class AbstractMessage
    {
        public abstract String toXML();

        public String createXML(String type, String data){
            //@TODO: create XML message 
            return "";    
        }

        public String createXML(String type) {
            return createXML(type, null);
        }
    }
}
