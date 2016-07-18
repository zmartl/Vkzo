using Vkazo.ViewModel;

using Xamarin.Forms;

namespace Vkazo.Pages
{
    public partial class ImageDetailPage : ContentPage
    {
        public ImageDetailPage()
        {
            InitializeComponent();
            CustomerListView.Footer = string.Empty;
        }

        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null || !(BindingContext is IOnItemSelected))
                return;

            var vm = (IOnItemSelected) BindingContext;

            vm.OnSelectedItem(e.SelectedItem, Navigation);

            ((ListView) sender).SelectedItem = null;
        }
    }
}