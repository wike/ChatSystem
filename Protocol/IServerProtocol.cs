using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;

namespace Protocol
{
    /**
     * <summary>Describes the protocol used to communicate with the server</summary>
    */
    interface IServerProtocol
    {
        /**
         <summary>
            Tries to authenticate the user
            <param name="user">Contains early user object with authentication data</summary>
            <returns>True if authentication was successful or false if not</returns>
         </summary>
         */
        User authenticate(User user);

        /**
         <summary>
            This method gets list of all users in database (both offline and online)
            <returns>LinkedList of users<returns>
         </summary>
         */ 
        LinkedList<User> getUserList();

        /**
         <summary>
            Sends message to the server
            <param name="message">Contains message to deliver</param>
            <returns>True if message was delivered, false if not</returns>
         </summary>
         */
        Boolean sendMessage(ChatMessage message);
   
        /**
         <summary>Pings the server
           <returns>True if ping delivered.</returns>
         </summary>
        */
        Boolean ping();
    }
}
