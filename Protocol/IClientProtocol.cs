using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
namespace Protocol
{
    /**
     * Describes protocol used to communicate with client
     */

    interface IClientProtocol
    {
        Boolean receiveMessages(LinkedList<Message> message);
        EStatus getStatus();
        Boolean ping();
    }
}
