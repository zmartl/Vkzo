using System.Threading.Tasks;

using Vkazo.Model;
using Vkazo.ViewModel;

using Xamarin.Forms;

namespace Vkazo
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();

            NavPage.ListView.ItemSelected += NavListViewOnItemSelected;
            NavPage.ListView.Footer = string.Empty;
        }

        private async void NavListViewOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var item = (Startscreen) e.SelectedItem;

            switch (item.Title)
            {
                case "Einsätze":
                    await PushAsync(new ImageDetailPage {BindingContext = new CustomerListViewModel()});
                    break;
                case "Verband":
                    await PushAsync(new ImageDetailPage {BindingContext = new AssociationListViewModel()});
                    break;
                case "Ausbildung":
                    await PushAsync(new ImageDetailPage { BindingContext = new EducationListViewModel() });
                    break;
                default:
                    await DisplayAlert("Error", "En error occured", "Ok");
                    break;
            }
            ((ListView) sender).SelectedItem = null;
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