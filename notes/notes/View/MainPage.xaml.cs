using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using notes.Model;
using Xamarin.Forms;

namespace notes
{
    public partial class MainPage : ContentPage
    {
        private readonly Database _database;
        private async void LoadNotes()
        {
            var notes = await _database.GetNotesAsync();            
            NotesListView.ItemsSource = notes; // notesListView, XAML'de tanımlı ListView kontrolü
        }
        public MainPage(Database database)
        {
            InitializeComponent();
            _database = database;
            LoadNotes();
        }
    }
}
