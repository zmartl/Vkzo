using System.Collections.ObjectModel;

using Vkazo.Model;
using Vkazo.Resources;

using Xamarin.Forms;

namespace Vkazo.ViewModel
{
    public class AssociationListViewModel : AbstractListViewModel<Association>
    {
        public AssociationListViewModel()
        {
            Title = AppResources.Association;
            Items = new ObservableCollection<Association> {
                new Association {Title = "Allgemein", Description = "Informationen über den SVKV", Image = "info.png"},
                new Association {Title = "Vereine", Description = "Alle Vereine im Überblick", Image = "organisation.png"}
            };
        }

        #region Overrides of AbstractListViewModel<Association>

        public override void OnSelectedItem(Association item, INavigation navigation)
        {

            switch (item.Title)
            {
                case "Allgemein":
                    var infoPage = new Pages.ImageDetailPage { BindingContext = new AssociationInfoListViewModel() };
                    navigation.PushAsync(infoPage);
                    break;
                case "Vereine":
                    var organisationPage = new Pages.ImageDetailPage {BindingContext = new OrganisationListViewModel()};
                    navigation.PushAsync(organisationPage);
                    break;
                
            }
        }

        #endregion
    }
}