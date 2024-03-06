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
    public partial class StudentsDetailsPage : TabbedPage
    {
        User student;
        public StudentsDetailsPage(User student)
        {
            InitializeComponent();
            this.student = student;
            foreach (var item in App.Database.GetSubjects().Result)
            {
                P_Subject_name.Items.Add(item.Name.ToString());
            }
            GetStudentsScores();
        }
        public async void GetStudentsScores()
        {
            List<List<string>> period1_Scories = new List<List<string>>();
            List<List<string>> period2_Scories = new List<List<string>>();

            var subjects = await App.Database.GetSubjects();
            foreach (var subject in subjects)
            {
                List<string> row = new List<string>();

                var scoriesPeriodOne = await App.Database.GetScories(student.User_id, subject.Subject_id, "Okres 1");
                string scoriesPeriodOneText = "";
                foreach (var score in scoriesPeriodOne)
                {
                    scoriesPeriodOneText += score.Value + " ";
                }
                row.Add(scoriesPeriodOneText);
                row.Add(subject.Name);

                period1_Scories.Add(row);
            }

            foreach (var subject in subjects)
            {
                List<string> row = new List<string>();

                var scoriesPeriodTwo = await App.Database.GetScories(student.User_id, subject.Subject_id, "Okres 2");
                string scoriesPeriodTwoText = "";
                foreach (var score in scoriesPeriodTwo)
                {
                    scoriesPeriodTwoText += score.Value + " ";
                }
                row.Add(scoriesPeriodTwoText);
                row.Add(subject.Name);

                period2_Scories.Add(row);
            }

            LV_UserScores_Period_1.ItemsSource = period1_Scories;
            LV_UserScores_Period_2.ItemsSource = period2_Scories;
        }
        public async void AddScore()
        {
            Score s = new Score()
            {
                User_id = student.User_id,
                Subject_id = App.Database.GetSubjects().Result[P_Subject_name.SelectedIndex].Subject_id.ToString(),
                Value = P_Value.Items[P_Value.SelectedIndex],
                Date = DateTime.Now,
                Description = E_Description.Text,
                Period = P_Period.Items[P_Period.SelectedIndex]
            };
            await App.Database.InsertScore(s);
        }

        private void Btn_AddScore_Clicked(object sender, EventArgs e)
        {
            AddScore();
            GetStudentsScores();
            P_Value.SelectedIndex = -1;
            E_Description.Text = "";
            P_Period.SelectedIndex = -1;
            P_Subject_name.SelectedIndex = -1;
        }
    }
}