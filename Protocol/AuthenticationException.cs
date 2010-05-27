using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
namespace Protocol
{
    [Serializable]
    public class AuthenticationException : Exception, ISerializable
    {
        public AuthenticationException(String message) : base(message){
        }
    }
}
