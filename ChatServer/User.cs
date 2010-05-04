using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatServer
{
    class User
    {
        private int id {get; set;}
        private string name { get; set; }
        private enum status { online, offline };
    }
}
