using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace ChatClient
{
    public class ClientConnection
    {
        private int port;
        private String ServerAddress;

        public ClientConnection(String ServerAddress, int port) {
            // Register channel
            ChannelServices.RegisterChannel(new HttpClientChannel(), true);

         
        }
    }
}
