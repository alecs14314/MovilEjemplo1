

namespace MovilEjemplo1
{
    using Views;
    using System;
    using System.Linq;
    using Xamarin.Forms;
    using Microsoft.AppCenter;
    using Microsoft.AppCenter.Analytics;
    using Microsoft.AppCenter.Crashes;
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            AppCenter.Start("ios=0e197cd2-7423-4542-8bf7-fa4040038f46;android=63f554f3-2f1e-4b17-8b35-27f391ffa994", typeof(Analytics), typeof(Crashes));
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
