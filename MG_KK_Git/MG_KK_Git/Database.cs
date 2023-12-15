using MG_KK_Git.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MG_KK_Git
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;
        public Database(string db)
        {
            _database = new SQLiteAsyncConnection(db);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Score>().Wait();
            _database.CreateTableAsync<Subject>().Wait();
        }

        public Task<int> InsertUser(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<List<User>> GetUsers()
        {
            return _database.QueryAsync<User>("SELECT * FROM User");
        }

        public Task<List<User>> GetUserFilter(string login, string password)
        {
            return _database.QueryAsync<User>("SELECT * FROM User WHERE Login=? AND Password=?", login, password);
        }
    }
}
