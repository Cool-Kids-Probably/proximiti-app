using proximiti.Helpers;
using proximiti.Objects;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proximiti.Databases
{
    class MessagesDatabase
    {
        //Creates an initializer for the database that doesn't open until called for
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.AccountsDatabase, Constants.Flags);
        });

        //Instance of the lazy initializer
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        //Status of database initialization
        static bool initialized = false;

        //Default constructor, calls an async initializer to prevent lockups
        public MessagesDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        //The aforementioned async initializer that initializes the database
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Message).Name))
                {
                    await Database.CreateTableAsync(typeof(Message), CreateFlags.None).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        //This method returns the account associated with the UUID provided
        public Task<Message> GetMessage(int id)
        {
            return Database.Table<Message>().Where(i => i.MessageID == id).FirstOrDefaultAsync();
        }

        //This method takes an Account object and stores it in the database
        public Task<int> SaveMessage(Message newMessage)
        {
            if (newMessage.MessageID != 0)
            {
                return Database.UpdateAsync(newMessage);
            }
            else
            {
                return Database.InsertAsync(newMessage);
            }
        }

        //This method deletes the account associated with the UUID provided
        public Task<int> DeleteMessage(int id)
        {
            return Database.DeleteAsync(GetMessage(id));
        }
    }
}
