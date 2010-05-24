using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace model
{
    public class User
    {
        private int id {get; set;}
        private String name { get; set; }
        private String password { get; set; }

        private enum status { online, offline };
    }
}
