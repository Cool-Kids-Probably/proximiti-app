using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace proximiti.Objects
{
    public class Account
    {
        [PrimaryKey]
        public int UUID { get; set; }
        public String Name { get; set; }
        [MaxLength(250)]
        public String Username { get; set; }
    }
}
