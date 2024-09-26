using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace notes.Model
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            InitializeDatabaseAsync();
        }
        public async Task InitializeDatabaseAsync() 
        {
            await _database.CreateTableAsync<note>();
            await _database.CreateTableAsync<Password>();
        }
        public Task<int> SavePasswordAsync(Password p)
        {
            if (p.IdUser != 0)
            {
                return _database.UpdateAsync(p);
            }
            else
            {
                p.IdUser = 1;
                return _database.InsertAsync(p);
            }
        }
        public async Task<bool> GetPasswordControl(string p)
        {
            var a = await _database.Table<Password>().FirstOrDefaultAsync(x=>x.MyPassword==p);
            return a != null;
        }
        public Task<List<Password>> GetPasswordAsync()
        {
            return _database.Table<Password>().ToListAsync();
        }

        public Task<List<note>> GetNotesAsync()
        {
            return _database.Table<note>().ToListAsync();
        }

        public Task<note> GetNoteAsync(int id)
        {
            return _database.Table<note>().FirstOrDefaultAsync(n => n.Id == id);
        }

        public Task<int> SaveNoteAsync(note notes)
        {
            if (notes.Id != 0)
            {
                return _database.UpdateAsync(notes);
            }
            else
            {
                return _database.InsertAsync(notes);
            }
        }

        public Task<int> DeleteNoteAsync(note notes)
        {
            return _database.DeleteAsync(notes);
        }
    }
}

