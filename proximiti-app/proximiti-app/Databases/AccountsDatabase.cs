using proximiti.Helpers;
using proximiti.Objects;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace proximiti.Databases
{
    public class AccountsDatabase
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
        public AccountsDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        //The aforementioned async initializer that initializes the database
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Account).Name))
                {
                    await Database.CreateTableAsync(typeof(Account), CreateFlags.None).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        //This method returns the account associated with the UUID provided
        public Task<Account> GetAccount(int id)
        {
            return Database.Table<Account>().Where(i => i.UUID == id).FirstOrDefaultAsync();
        }

        //This method takes an Account object and stores it in the database
        public Task<int> SaveAccount(Account newAccount)
        {
            if (newAccount.ID != 0)
            {
                return Database.UpdateAsync(newAccount);
            }
            else {
                return Database.InsertAsync(newAccount);
            }
        }

        //This method deletes the account associated with the UUID provided
        public Task<int> DeleteAccount(int id)
        {
            return Database.DeleteAsync(GetAccount(id));
        }
    }
}