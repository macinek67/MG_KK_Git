using MG_KK_Git.Tables;
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
    public partial class MainTabbed : TabbedPage
    {
        User user;
        public MainTabbed(User user)
        {
            InitializeComponent();
            this.user = user;
            //dodaj();
        }

        public async void dodaj()
        {
            //User x = new User()
            //{
            //    Name = "Marcin",
            //    Surname = "Gawron",
            //    Login = "000001n",
            //    Password = "admin123",
            //    IsTeacher = true
            //};
            //await App.Database.InsertUser(x);
        }

        public async void UploadData()
        {
            List<List<string>> period1_Scories = new List<List<string>>();

            var subjects = await App.Database.GetSubjects();
            foreach (var subject in subjects)
            {
                List<string> row = new List<string>();

                var scories = await App.Database.GetScories(subject.Subject_id);
                string scoriesText = "";
                foreach (var score in scories)
                {
                    scoriesText += score.Value + " ";
                }
                row.Add(scoriesText);
                row.Add(subject.Name);
            }
        }
    }
}