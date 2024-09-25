using System;
using System.IO;
using notes.Model;
using notes.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace notes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.db3");
            Database database = new Database(dbPath);
            InitializeApp(database);
        }
        public async void InitializeApp(Database database)
        {
            var password = await database.GetPasswordAsync();

            if(password.Count==0)
            {
                MainPage = new NavigationPage(new NewPasswordPage());
            }
            else
            {
                MainPage = new NavigationPage(new PasswordPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
