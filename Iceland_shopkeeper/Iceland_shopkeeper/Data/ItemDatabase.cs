
using System.Collections.Generic;
using SQLite;
using System.Threading.Tasks;
using Iceland_shopkeeper.Model;

namespace Iceland_shopkeeper.Data
{
    public class ItemDatabase
    {
        readonly SQLiteAsyncConnection database;//SQLiteConnection database;
        SQLiteCommand sqlite_cmd;

        public ItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Item>().Wait();

        }

        public async Task ClearDatabase(string dbPath)
        {
            //database.DropTableAsync<Item>().Wait();
            using (var connection = new SQLiteConnection(dbPath, true))
                await Task.Run(() => connection.DropTable<Item>()).ConfigureAwait(false);
        }

        public Task<List<Item>> GetItemsAsync()
        {
            return database.Table<Item>().ToListAsync();
        }


        public Task<List<Item>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Item>("SELECT * FROM [Item] WHERE [Done] = 'false'");
        }

        public Task<Item> GetItemAsync(int id)
        {
            return database.Table<Item>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Item item)
        {
            if (item.id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            return database.DeleteAsync(item);
        }
    }

}
