﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace proximiti.Helpers
{
    public static class Constants
    {
        //Names of the databases
        public const string AccountsDatabase = "AccountsSQLite.db3";
        public const string MessagesDatabase = "MessagesSQLite.db3";
        public const string StoriesDatabase = "StoresSQLite.db3";

        //Default enum values used to init database connections
        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache |
            SQLite.SQLiteOpenFlags.FullMutex |
            SQLite.SQLiteOpenFlags.ProtectionComplete;

        //Finds and returns the path of the database
        public static string getDatabasePath (String databaseName)
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(basePath, databaseName);
        }
    }
}
