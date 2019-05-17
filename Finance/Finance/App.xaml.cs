using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Finance
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            string androidAppSecret = "c5036ee6-be31-41ec-9509-48c4f755fd55";
            string iOSAppSecret = "c8ba2a46-d2be-4121-bc69-c91f6450afcf";
            AppCenter.Start($"android={androidAppSecret};ios={iOSAppSecret}", typeof(Crashes));
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
