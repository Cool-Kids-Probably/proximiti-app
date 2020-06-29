using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace proximiti.Objects
{
    public class Message
    {
        [AutoIncrement]
        public int MessageID { get; set; }
        [PrimaryKey]
        public int[] ParticipantIDs { get; set; }
        public String PlaintextMessage { get; set; }
            
    }
}
