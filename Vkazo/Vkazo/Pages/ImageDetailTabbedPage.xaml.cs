using Vkazo.ViewModel;

using Xamarin.Forms;

namespace Vkazo.Pages
{
    public class ImageDetailTabbedPage : TabbedPage
    {
        public ImageDetailTabbedPage()
        {
            this.Title = "Test";
            this.ItemsSource = 
        }

        public void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null || !(BindingContext is IOnItemSelected))
                return;

            var vm = (IOnItemSelected) BindingContext;

            vm.OnSelectedItem(e.SelectedItem, Navigation);

            ((ListView) sender).SelectedItem = null;
        }
    }
}