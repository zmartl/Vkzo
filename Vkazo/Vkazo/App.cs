using System.Net.Http.Headers;

using Vkazo.Resources;

using Xamarin.Forms;

namespace Vkazo
{
    public class App : Application
    {

        public NavigationPage NavigationPage { get; private set; }

        public MasterDetailPage Master { get; private set; }

        public const string MESSAGE_NAVIGATE = "Navigate";

        public App()
        {
            // The root page of your application
            NavigationPage = new NavigationPage(new HomePage());
            Master = new MasterDetailPage {
                Master = new NavPage() {
                    Title = "Menu",
                    Icon = "burger.png",
                }, 
                Detail = NavigationPage
            };
            MainPage = Master;

        }

        protected override void OnStart()
        {
            // Handle when your app starts

            MessagingCenter.Subscribe<App, string>(this, MESSAGE_NAVIGATE, async (sender, page) =>  {
                await NavigationPage.PopToRootAsync(false);

                switch (page)
                {
                    case "Einsätze":
                        await NavigationPage.PushAsync(new CustomerPage());
                        break;
                }
                
                Master.IsPresented = false;
            });
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