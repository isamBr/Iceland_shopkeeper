using Iceland_shopkeeper.Data;
using Iceland_shopkeeper.Dependency;
using Iceland_shopkeeper.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Iceland_shopkeeper
{
    public partial class App : Application
    {
        static ItemDatabase database;
        public App()
        {
            InitializeComponent();

            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            var nav = new NavigationPage(new ItemsListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        public static ItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("ItemsSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeItems { get; set; }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
