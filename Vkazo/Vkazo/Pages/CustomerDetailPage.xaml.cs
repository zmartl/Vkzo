using Vkazo.Model;

using Xamarin.Forms;

namespace Vkazo.Pages
{
    public partial class CustomerDetailPage : ContentPage
    {
        private Customer _item;

        public Customer Item
        {
            get { return _item; }
            set
            {
                if (_item == value)
                    return;
                _item = value;
                OnPropertyChanged();
            }
        }

        public CustomerDetailPage()
        {
            InitializeComponent();

            BindingContext = this;
        }
    }
}