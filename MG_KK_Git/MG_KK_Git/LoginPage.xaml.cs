using MG_KK_Git.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (Login_Entry.Text.Length != 8 || users.Count == 0)
            {
                await DisplayAlert("Blad", "Podano nieprawidlowe dane", "OK");
                return;
            }

            var user = users.ElementAt(0);
            if (user.IsTeacher)
            {
                await Navigation.PushAsync(new TeacherMainPage(user));
            }
            else
            {
                await Navigation.PushAsync(new StudentMainPage(user));
            }
            
        }
        public void Btn_SwapViews_Clicked(object sender, EventArgs e)
        {
            SwapViews();
        }
        public void SwapViews()
        {
            SL_LoginView.IsVisible = SL_RegisterView.IsVisible;
            SL_RegisterView.IsVisible = !SL_LoginView.IsVisible;
        }
        private async void Register_Button_Clicked(object sender, EventArgs e)
        {
            if (Password_Entry_1.Text != Password_Entry_2.Text)
            {
                await DisplayAlert("Error", "Hasła są nieprawidłowe","OK");
                return;
            }
            if (!new Regex("[a-zA-Z]").IsMatch(E_Name.Text) && !new Regex("[a-zA-Z]").IsMatch(E_Surname.Text))
            {
                await DisplayAlert("Error", "Wpisano nieprawidłowe znaki", "OK");
                return;
            }
            User newUser = new User();
            string login = "";
            Random random = new Random();
            do
            {
                for (int i = 0; i < 7; i++)
                {
                    login += random.Next(0, 9);
                }
            } while (App.Database.GetUsers().Result.Where(user => user.Login != login && user.IsTeacher == CB_IsTeacher.IsChecked) == null);
            
            newUser.Login = login;
            if (CB_IsTeacher.IsChecked)
            {
                newUser.Login = newUser.Login + "n";
            }
            else
            {
                newUser.Login = newUser.Login + "u";
            }
            newUser.Password = Password_Entry_1.Text;
            newUser.IsTeacher = CB_IsTeacher.IsChecked;
            newUser.Name = E_Name.Text;
            newUser.Surname = E_Surname.Text;
            await App.Database.InsertUser(newUser);
            await DisplayAlert("Sukces", $"Twój login do konta to: {newUser.Login}", "OK");
            SwapViews();
        }
    }
}