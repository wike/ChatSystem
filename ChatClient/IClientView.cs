using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace ChatClient
{
    public interface IClientView
    {
        void setUserList(LinkedList<User> userList);
        void receiveMessage(AbstractMessage message);
        void setModelController(IClientModel model, IClientController controller);

        void Hide();

        void update(AbstractMessage message);
    }
}