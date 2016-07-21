using Vkazo.Model;

using Xamarin.Forms;

namespace Vkazo.Pages
{
    public partial class GradeDetailPage : ContentPage
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

        public GradeDetailPage()
        {
            InitializeComponent();

            BindingContext = this;
        }
    }
}