using System.Collections.Generic;

using Vkazo.Model;
using Vkazo.Resources;

using Xamarin.Forms;

namespace Vkazo
{
    public partial class NavPage : ContentPage
    {
        public ListView ListView => NavListView;

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

    }
}