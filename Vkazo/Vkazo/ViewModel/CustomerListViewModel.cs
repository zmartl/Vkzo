using System.Collections.ObjectModel;

using Vkazo.Model;
using Vkazo.Resources;

using Xamarin.Forms;

namespace Vkazo.ViewModel
{
    public class CustomerListViewModel : AbstractListViewModel<Customer>
    {
        public CustomerListViewModel()
        {
            Title = AppResources.UnsereEinsaetze;
            Items = new ObservableCollection<Customer> {
                new Customer {
                    Title = AppResources.ZurichZoo,
                    Description = AppResources.ZurichZooDescription,
                    DescriptionLong = AppResources.ZurichZooDescription,
                    Image = AppResources.ImageZurichZoo
                },
                new Customer {
                    Title = AppResources.HinwilBadi,
                    Description = AppResources.HinwilBadiDescription,
                    DescriptionLong = AppResources.HinwilBadiDescription,
                    Image = AppResources.ImageHinwilBadi
                },
                new Customer {
                    Title = AppResources.LiveAtSunset,
                    Description = AppResources.LiveAtSunsetDescription,
                    DescriptionLong = AppResources.LiveAtSunsetDescription,
                    Image = AppResources.ImageLiveAtSunset
                },
                new Customer {
                    Title = AppResources.HinwilRocKTheRing,
                    Description = AppResources.HinwilRocKTheRingDescription,
                    DescriptionLong = AppResources.HinwilRocKTheRingDescription,
                    Image = AppResources.ImageRockTheRing
                }
            };
        }

        #region Overrides of AbstractListViewModel<Customer>

        public override void OnSelectedItem(Customer item, INavigation navigation)
        {
            var detailPage = new CustomerDetailPage {Item = item};
            navigation.PushAsync(detailPage);
        }

        #endregion
    }
}