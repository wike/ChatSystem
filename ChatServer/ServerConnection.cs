using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace ChatServer
{
    public class ServerConnection
    {
        public ServerConnection()
        {
            ChannelServices.RegisterChannel(new HttpChannel(9999), true);
            RemotingConfiguration.RegisterWellKnownServiceType(
                Type.GetType("model.Message"), "Message",
                WellKnownObjectMode.SingleCall);

        }
    }
}
