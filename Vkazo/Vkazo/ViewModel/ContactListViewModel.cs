using System.Collections.ObjectModel;

using Vkazo.Model;
using Vkazo.Resources;
using Vkazo.Resources.Contact;

using Xamarin.Forms;

namespace Vkazo.ViewModel
{
    public class ContactListViewModel : AbstractListViewModel<Base>
    {
        public ContactListViewModel()
        {
            Title = AppResources.Contact;
            Items = new ObservableCollection<Base> {
                new Base {Title = ContactResources.Email, Description = ContactResources.EmailAdress},
                new Base {Title = ContactResources.Telephone, Description = ContactResources.TelephoneAdress},
                new Base {Title = ContactResources.BecomeVkTitle, Description = ContactResources.BecomeVkDesc},
                new Base {Title = ContactResources.BecomeDriverTitle, Description = ContactResources.BecomeDriverDesc}
            };
        }

        #region Overrides of AbstractListViewModel<Base>

        public override void OnSelectedItem(Base item, INavigation navigation)
        {
            
        }

        #endregion
    }
}