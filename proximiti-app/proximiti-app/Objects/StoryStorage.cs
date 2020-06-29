using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace proximiti.Objects
{
    class StoryStorage
    {
        [PrimaryKey, AutoIncrement]
        public int StoryUID { get; set; }
        public Story StoryObject { get; set; }
    }
}
