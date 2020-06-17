using System;
using System.Collections.Generic;
using System.Text;

namespace proximiti.Objects
{
    class MessageWrapper
    {
        public int SenderUUID { get; set; }
        public int ReceiverUUID { get; set; }
        public DateTime MessageSendTime { get; set; }
        public Message message { get; set; }
    }
}
