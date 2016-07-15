using System.Collections.ObjectModel;

using Vkazo.Model;
using Vkazo.Resources;
using Vkazo.Resources.Organisations;

using Xamarin.Forms;

namespace Vkazo.ViewModel
{
    public class OrganisationListViewModel : AbstractListViewModel<Organisation>
    {
        public OrganisationListViewModel()
        {
            Title = AppResources.Organisations;
            Items = new ObservableCollection<Organisation> {
                new Organisation {
                    Title = ResVkazo.Short,
                    Description = ResVkazo.Long,
                    Image = ResVkazo.Image,
                    Founder = ResVkazo.Founder,
                    FoundingYear = ResVkazo.FoundingYear,
                    VehicleName = ResVkazo.VehicleName,
                    Email = ResVkazo.Email,
                    Telephone = ResVkazo.Telephonenumer
                },
                new Organisation {
                    Title = ResVkazu.Short,
                    Description = ResVkazu.Long,
                    Image = ResVkazu.Image,
                    Founder = ResVkazu.Founder,
                    FoundingYear = ResVkazu.FoundingYear,
                    VehicleName = ResVkazu.VehicleName,
                    Email = ResVkazu.Email,
                    Telephone = ResVkazu.Telephonenumer
                }
            };
        }

        #region Overrides of AbstractListViewModel<Organisation>

        public override void OnSelectedItem(Organisation item, INavigation navigation)
        {
            var organisationDetailPage = new OrganisationDetailPage {Item = item};
            navigation.PushAsync(organisationDetailPage);
        }

        #endregion
    }
}