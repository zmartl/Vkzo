using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vkazo.Model;
using Xamarin.Forms;

namespace Vkazo
{
    public partial class CustomerDetailPage : ContentPage
    {
        public CustomerDetailPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        private Customer _item;
        public Customer Item
        {
            get { return _item; }
            set
            {
                if(_item == value)
                    return;
                _item = value;
                OnPropertyChanged();
            }
        }
    }
}

