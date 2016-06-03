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
                    Description = AppResources.ZurichZooDescription,
                    DescriptionLong = AppResources.ZurichZooDescription,
                    Image = AppResources.ImageZurichZoo
                },
                new Customer
                {
                    Title = AppResources.HinwilBadi,
                    Description = AppResources.HinwilBadiDescription,
                    DescriptionLong = AppResources.HinwilBadiDescription,
                    Image = AppResources.ImageHinwilBadi
                },
                new Customer
                {
                    Title = AppResources.LiveAtSunset,
                    Description = AppResources.LiveAtSunsetDescription,
                    DescriptionLong = AppResources.LiveAtSunsetDescription,
                    Image = AppResources.ImageLiveAtSunset
                },
                new Customer
                {
                    Title = AppResources.HinwilRocKTheRing,
                    Description = AppResources.HinwilRocKTheRingDescription,
                    DescriptionLong = AppResources.HinwilRocKTheRingDescription,
                    Image = AppResources.ImageRockTheRing
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