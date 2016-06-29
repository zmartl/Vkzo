using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vkazo.Model;

using Xamarin.Forms;

namespace Vkazo
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();

            NavPage.ListView.ItemSelected += NavListViewOnItemSelected;
        }

        private void NavListViewOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var item = (Startscreen)e.SelectedItem;

            switch (item.Title)
            {
                case "Einsätze":
                    PushAsync(new CustomerPage());
                    break;
                default:
                    DisplayAlert("Error", "En error occured", "Ok");
                    break;
            }
            ((ListView)sender).SelectedItem = null;
            IsPresented = false;
        }

        private async Task PushAsync(ContentPage page, bool clearStack = true)
        {
            if (clearStack)
            {
                await NavigationStack.PopToRootAsync(true);
            }
            await NavigationStack.PushAsync(page);
            
        }
    }
}
