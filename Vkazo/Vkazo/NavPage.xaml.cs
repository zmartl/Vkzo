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

            NavListView.ItemsSource = new List<Startscreen> {
                new Startscreen {Image = "warning.png", Title = AppResources.Einsaetze},
                new Startscreen {Image = "association.png", Title = AppResources.Association},
                new Startscreen {Image = "education.png", Title = AppResources.Education},
                new Startscreen {Image = "contact.png", Title = AppResources.Contact}
            };
        }

        public void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var item = (Startscreen) e.SelectedItem;

            switch (item.Title)
            {
                case "Einsätze":
                    var customerPage = new CustomerPage();
                     
                    MessagingCenter.Send(this, App.MESSAGE_NAVIGATE, item.Title);
                    break;
                default:
                    DisplayAlert("Error", "En error occured", "Ok");
                    break;
            }
            ((ListView) sender).SelectedItem = null;
        }
    }
}