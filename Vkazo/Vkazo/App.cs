using System.Net.Http.Headers;

using Vkazo.Resources;

using Xamarin.Forms;

namespace Vkazo
{
    public class App : Application
    {

        public App()
        {
            // The root page of your application
            MainPage = new Pages.MasterPage();
        }

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