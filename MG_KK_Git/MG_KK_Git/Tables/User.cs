using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG_KK_Git.Tables
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int User_id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
