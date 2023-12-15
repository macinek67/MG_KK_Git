using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MG_KK_Git
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "librus.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainTabbed());
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
