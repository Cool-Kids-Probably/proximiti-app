using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace proximiti.Helpers
{
    public static class Constants
    {
        //Names of the databases
        public const string AccountsDatabase = "AccountsSQLite.db3";
        public const string MessagesDatabase = "MessagesSQLite.db3";
        public const string StoriesDatabase = "StoriesSQLite.db3";

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
            return Path.Combine(FileSystem.AppDataDirectory, databaseName);
        }
    }
}
