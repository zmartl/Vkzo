using System.Collections.ObjectModel;

using Vkazo.Model;
using Vkazo.Resources;

using Xamarin.Forms;

namespace Vkazo.ViewModel
{
    public class OrganisationLessonListViewModel : AbstractListViewModel<Base>
    {
        public OrganisationLessonListViewModel()
        {
            Title = AppResources.OrganisationLesson;
            Items = new ObservableCollection<Base> {
                new Base {
                    Title = AppResources.MaterialLesson,
                    Description = AppResources.MaterialLessonDescription
                },
                new Base {
                    Title = AppResources.OrganisationLesson,
                    Description = AppResources.OrganisationLessonDescription
                },
                new Base {
                    Title = AppResources.GradeLesson,
                    Description = AppResources.GradeLessonDescription
                }
            };
        }

        #region Overrides of AbstractListViewModel<Base>

        public override void OnSelectedItem(Base item, INavigation navigation)
        {            
            
        }

        #endregion
    }
}