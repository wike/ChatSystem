using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace model
{
    class Room
    {
        private int id {get; set;}
        private String topic { get; set; }
        private List<User> users {get; set;}
    }
}
