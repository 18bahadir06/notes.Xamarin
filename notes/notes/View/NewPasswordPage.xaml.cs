using notes.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace notes.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPasswordPage : ContentPage
    {
        private readonly Database _database;
        public NewPasswordPage()
        {
            InitializeComponent();
        }
        private async void OnNewPassword(object sender, EventArgs e)
        {
            string p1 = Pentry1.Text?.Trim();
            string p2 = Pentry2.Text?.Trim();
            if(string.IsNullOrEmpty(p1) || string.IsNullOrEmpty(p2) ) 
            {
                await DisplayAlert("Hata", "Lütfen tüm alanları doldurun.", "Tamam");
                return;
            }
            Password password = new Password();
            if(p1== p2) 
            {
                password.MyPassword = p1;
                await _database.SavePasswordAsync(password);
                await DisplayAlert("Başarılı", "Yeni şifre tanımlandı", "Tamam");
            }
            else
            {
                await DisplayAlert("Hata", "Şifreler birbiriyle uyuşmuyor!!!", "Tamam");
            }
        }
    }
}