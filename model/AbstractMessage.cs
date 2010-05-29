using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
namespace Model
{
    [Serializable]
    public abstract class AbstractMessage
    {
        public abstract XmlDocument toXml();
    }
}
