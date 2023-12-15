using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG_KK_Git
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;
        public Database(string db)
        {
            _database = new SQLiteAsyncConnection(db);
        }
    }
}
