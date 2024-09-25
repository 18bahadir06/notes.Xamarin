using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace notes.Model
{
    public class Password
    {
        [PrimaryKey, AutoIncrement]
        public int IdUser { get; set; }
        public string MyPassword { get; set; }
    }
}
