using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatServer
{
    class Message
    {
        private int id { get; set; }
        private string content { get; set; }
        private enum status { pending, delivered };
        private User sender { get; set; }
        private User receiver { get; set; }
    }
}
