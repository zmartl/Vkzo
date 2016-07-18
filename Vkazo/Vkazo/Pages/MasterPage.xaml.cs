using System.Threading.Tasks;

using Vkazo.Model;
using Vkazo.ViewModel;

using Xamarin.Forms;

namespace Vkazo.Pages
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
                    Detail = new NavigationPage(new ImageDetailPage {BindingContext = new CustomerListViewModel()});
                    break;
                case "Verband":
                    Detail = new AssociationTabbedPage();
                    break;
                case "Ausbildung":
                    Detail = new EducationTabbedPage();
                    break;
                case "Kontakt":
                    Detail = new NavigationPage(new ImageDetailPage {BindingContext = new ContactListViewModel()});
                    break;
                default:
                    await DisplayAlert("Fehler", "Fehler beim Laden der Seite", "OK");
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