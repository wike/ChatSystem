using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using Model;
namespace ChatClient
{
    public interface IClientModel
    {
        void send(AbstractMessage message);
        void connect(IPAddress ip, int port);

        Boolean isConnected();
        void requestUserList(); 
        void notifyObservers(AbstractMessage message);
        void removeObserver(IClientView clientView);
    }
}
