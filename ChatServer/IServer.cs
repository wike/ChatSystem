using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatServer
{
    interface IServer
    {
        public int connect();
        public int disconnect();

        public int login(User user);
        public int logout(User user);

        public int sendMessage(Message message);
    }
}
