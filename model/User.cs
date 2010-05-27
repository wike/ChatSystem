using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
namespace Model
{
    [Serializable]
    public class User
    {
        public int id {get; set;}
        public String name { get; set; }
        public String password { get; set; }

        private enum status { online, offline };
    }
}
