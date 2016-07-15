using System.Collections.ObjectModel;

using Vkazo.Model;
using Vkazo.Resources;
using Vkazo.Resources.Education;

using Xamarin.Forms;

namespace Vkazo.ViewModel
{
    public class MaterialListViewModel : AbstractListViewModel<Customer>
    {
        public MaterialListViewModel()
        {
            Title = AppResources.MaterialLesson;
            Items = new ObservableCollection<Customer> {
                new Customer {
                    Title = MaterialLessonResources.ScissorLattice,
                    Description = MaterialLessonResources.ScissorLatticeDescription,                    
                    Image = MaterialLessonResources.ScissorLatticeImage
                },
                new Customer {
                    Title = MaterialLessonResources.TrafficCone,
                    Description = MaterialLessonResources.TrafficConeDescription,                    
                    Image = MaterialLessonResources.TrafficConeImage
                },
                new Customer {
                    Title = MaterialLessonResources.FoldingTrafficSignal,
                    Description = MaterialLessonResources.FoldingTrafficSignalDescription,
                    Image = MaterialLessonResources.FoldingTrafficSignalImage
                },
                new Customer {
                    Title = MaterialLessonResources.Flashlamp,
                    Description = MaterialLessonResources.FlashlampDescription,
                    Image = MaterialLessonResources.FlashlampImage
                }
            };
        }

        #region Overrides of AbstractListViewModel<Customer>

        public override void OnSelectedItem(Customer item, INavigation navigation)
        {
            var detailPage = new Pages.CustomerDetailPage {Item = item};
            navigation.PushAsync(detailPage);
        }

        #endregion
    }
}