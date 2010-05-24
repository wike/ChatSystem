using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace model
{
    public class Message : MarshalByRefObject,IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
