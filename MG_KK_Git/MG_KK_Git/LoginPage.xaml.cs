using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MG_KK_Git
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Login_Button_Clicked(object sender, EventArgs e)
        {
            var users = await App.Database.GetUserFilter(Login_Entry.Text, Password_Entry.Text);
            if (Login_Entry.Text.Length != 7 || users.Count == 0)
            {
                DisplayAlert("Blad", "Podano nieprawidlowe dane", "OK");
                return;
            }

            var user = users.ElementAt(0);
            Navigation.PushAsync(new MainTabbed(user));
        }
    }
}