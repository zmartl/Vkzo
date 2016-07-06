using System.Collections.ObjectModel;

using Vkazo.Model;
using Vkazo.Resources;

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
                    Title = "VKAZO", 
                    Description = "Verkehrkadetten Zürcher Oberland",
                    Image = "organisation.png"
                }, new Organisation {
                    Title = "VKAZU",
                    Description = "Verkehrkadetten Zürcher Unterland",
                    Image = "organisation.png"
                }
            };
        }

        #region Overrides of AbstractListViewModel<Organisation>

        public override void OnSelectedItem(Organisation item, INavigation navigation)
        {
            var organisationDetailPage = new OrganisationDetailPage { Item = item };
            navigation.PushAsync(organisationDetailPage);
        }

        #endregion
    }
}