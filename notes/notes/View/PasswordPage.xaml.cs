using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using notes.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordPage : ContentPage
    {
        public PasswordPage()
        {
            InitializeComponent();
        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string p = PasswordEntry.Text.ToString();
            if (await App.database.GetPasswordControl(p)==true)
            {
                await Navigation.PushAsync(new MainPage(new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.db3"))));
            }
            else
            {
                await DisplayAlert("Hata", "Geçersiz şifre. Lütfen tekrar deneyin.", "Tamam");
            }
        }
    }
}