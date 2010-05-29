using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ChatClient
{
    public interface IClientController
    {
        void login(User user);
        void logout(User user);
        void requestUserList();
        void send(AbstractMessage message);
        
        void setModel(IClientModel model);
        void setView(IClientView view);

        void connect(System.Net.IPAddress ipAddress, int port);
    }
}
