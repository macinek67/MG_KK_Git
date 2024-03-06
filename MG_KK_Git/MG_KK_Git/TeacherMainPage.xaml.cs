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
    public partial class TeacherMainPage : TabbedPage
    {
        User user;
        public TeacherMainPage(User user)
        {
            InitializeComponent();
            this.user = user;
            UploadData();
        }
        public async void UploadData()
        {
            LV_StudentsList.ItemsSource = (await App.Database.GetUsers()).Where(user => user.IsTeacher == false);
        }
        private void TI_Logout_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private void Btn_AddSubject_Clicked(object sender, EventArgs e)
        {
            AddSubject();
            E_SubjectName.Text = "";
        }
        public async void AddSubject()
        {
            Subject addSubject = new Subject()
            {
                Name = E_SubjectName.Text
            };
            await App.Database.InsertSubject(addSubject);
        }
        private void Btn_StudentDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StudentsDetailsPage((sender as Button).CommandParameter as User));
        }
    }
}