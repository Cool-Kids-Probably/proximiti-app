using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace proximiti.Objects
{
    class AccountStorage
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Account { get; set; }
        public int FriendStatus { get; set; }
    }
}
