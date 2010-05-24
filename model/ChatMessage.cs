using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace model
{
    enum Estatus { delivered, not_delivered };
    public class ChatMessage
    {
        private int id { get; set; }
        private User from { get; set; }
        private User to { get; set; }
        private String content { get; set; }
        private Estatus status { get; set; }
        private Room room {get; set; }

        public String toXML() {
            return "";
        }

        public String toString() {
            return String.Format("id={0:d}, from={1:d}, to={2:d}\ncontent={3},\nstatus={4:d}, room={5:d}",
                                  id, from, to, content, this.status, room);
        }
    }
}
