using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG_KK_Git.Tables
{
    public class Score
    {
        [AutoIncrement, PrimaryKey]
        public int Score_id { get; set; }
        public int User_id { get; set; }
        public int Subject_id { get; set; }
        public string Value { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
