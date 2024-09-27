using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using notes.Bussines;
using notes.Model;
using Xamarin.Forms;

namespace notes
{
    public partial class MainPage : ContentPage
    {
        private readonly Database _database;
        private readonly BussinesClass _bussinesClass;
        private async void LoadNotes()
        {
            var notes = await _database.GetNotesAsync();            
            NotesListView.ItemsSource = notes; // notesListView, XAML'de tanımlı ListView kontrolü
        }
        public MainPage(Database database)
        {
            InitializeComponent();
            _bussinesClass = new BussinesClass();
            _database = database;
            LoadNotes();
        }
        private async void OnNewNoteClicked(object sender, EventArgs e)
        {
            Color color1 = _bussinesClass.RandomColor();
            string color=_bussinesClass.ColorToHex(color1);
            note not = new note()
            {
                Content =NoteEntry.Text.ToString(),
                Time=DateTime.Now,
                Color= color
            };
            await _database.SaveNoteAsync(not);
        }
    }
}
