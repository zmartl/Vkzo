using System.Collections.ObjectModel;

using Vkazo.Model;
using Vkazo.Resources;

using Xamarin.Forms;

namespace Vkazo.ViewModel
{
    public class EducationListViewModel : AbstractListViewModel<Customer>
    {
        public EducationListViewModel()
        {
            Title = AppResources.Education;
            Items = new ObservableCollection<Customer> {
                new Customer {
                    Title = AppResources.MaterialLesson,
                    Description = AppResources.MaterialLessonDescription
                },
                new Customer {
                    Title = AppResources.OrganisationLesson,
                    Description = AppResources.OrganisationLessonDescription
                },
                new Customer {
                    Title = AppResources.GradeLesson,
                    Description = AppResources.GradeLessonDescription
                }
            };
        }

        #region Overrides of AbstractListViewModel<Base>

        public override void OnSelectedItem(Customer item, INavigation navigation)
        {
            switch (item.Title)
            {
                case "Materialkunde":
                    var infoPage = new Pages.ImageDetailPage { BindingContext = new MaterialListViewModel() };
                    navigation.PushAsync(infoPage);
                    break;
                case "Vereinskunde":
                    var organisationPage = new Pages.ImageDetailPage() { BindingContext = new OrganisationLessonListViewModel() };
                    navigation.PushAsync(organisationPage);
                    break;
                case "Ränge":
                    var gradePage = new Pages.ImageDetailPage() { BindingContext = new GradeLessonListViewModel() };
                    navigation.PushAsync(gradePage);
                    break;
            }
            
        }

        #endregion
    }
}