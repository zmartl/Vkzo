using Vkazo.Model;

using Xamarin.Forms;

namespace Vkazo
{
    public partial class OrganisationDetailPage : ContentPage
    {
        private Organisation _item;

        public Organisation Item
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

        public OrganisationDetailPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}