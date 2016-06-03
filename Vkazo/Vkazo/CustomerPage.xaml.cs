using System.Collections.Generic;
using Vkazo.Model;
using Vkazo.Resources;
using Xamarin.Forms;

namespace Vkazo
{
    public partial class CustomerPage : ContentPage
    {
        public CustomerPage()
        {
            InitializeComponent();

            CustomerListView.ItemsSource = new List<Customer>
            {
                new Customer
                {
                    Title = AppResources.ZurichZoo,
                    Description = "Blablabla",
                    Image = "warning.png"
                },
                new Customer
                {
                    Title = "Volketswil, Obi",
                    Description = "Blablabla",
                    Image = "warning.png"
                }
            };
        }

        public void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var detailPage = new CustomerDetailPage
            {
                Item = (Customer)e.SelectedItem
            };
            Navigation.PushAsync(detailPage);
            ((ListView)sender).SelectedItem = null;
        }
    }
}