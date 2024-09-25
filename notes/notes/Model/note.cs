using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace notes.Model
{
    public class note
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
