using System.Collections.Generic;
using Vkazo.Model;
using Xamarin.Forms;

namespace Vkazo
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            MainListView.ItemsSource = new List<Startscreen>
            {
                new Startscreen
                {
                    Image = "warning.png",
                    Title = "asdfdsaf",
                    Description = "Description"
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
            var item = (Startscreen) e.SelectedItem;

            switch (item.Title)
            {
                case "asdfdsaf":
                    var customerPage = new CustomerPage();
                    Navigation.PushAsync(customerPage);
                    break;
                default:
                    DisplayAlert("Error", "En error occured", "Ok");
                    break;
            }
            ((ListView) sender).SelectedItem = null;
        }
    }
}