using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Room
    {
        private int id {get; set;}
        private String topic { get; set; }
        private List<User> users {get; set;}
    }
}
