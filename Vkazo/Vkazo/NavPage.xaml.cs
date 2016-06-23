using System.Collections.Generic;
using Vkazo.Model;
using Vkazo.Resources;
using Xamarin.Forms;

namespace Vkazo
{
    public partial class NavPage : ContentPage
    {
        public NavPage()
        {
            InitializeComponent();

            MainListView.ItemsSource = new List<Startscreen>
            {
                new Startscreen
                {
                    Image = "warning.png",
                    Title = AppResources.Einsaetze,
                    Description = AppResources.UnsereEinsaetze
                },
                new Startscreen
                {
                    Image = "warning.png",
                    Title = "Tiasdfsdftle",
                    Description = "Description"
                },
                new Startscreen
                {
                    Image = "warning.png",
                    Title = "sadf",
                    Description = "Description"
                },
                new Startscreen
                {
                    Image = "warning.png",
                    Title = "wer",
                    Description = "Description"
                },
                new Startscreen
                {
                    Image = "warning.png",
                    Title = "weqr",
                    Description = "Description"
                },
                new Startscreen
                {
                    Image = "warning.png",
                    Title = "qwer",
                    Description = "Description"
                }
            };
        }

        public void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var item = (Startscreen)e.SelectedItem;

            switch (item.Title)
            {
                case "Einsätze":
                    var customerPage = new CustomerPage();
                    Navigation.PushAsync(customerPage);
                    break;
                default:
                    DisplayAlert("Error", "En error occured", "Ok");
                    break;
            }
            ((ListView)sender).SelectedItem = null;
        }
    }
}