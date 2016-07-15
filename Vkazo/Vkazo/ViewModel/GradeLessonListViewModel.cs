using System.Collections.ObjectModel;

using Vkazo.Model;
using Vkazo.Resources;
using Vkazo.Resources.Education;

using Xamarin.Forms;

namespace Vkazo.ViewModel
{
    public class GradeLessonListViewModel : AbstractListViewModel<Customer>
    {
        public GradeLessonListViewModel()
        {
            Title = AppResources.MaterialLesson;
            Items = new ObservableCollection<Customer> {
                new Customer {
                    Title = GradeLessonResources.Asp,
                    Description = GradeLessonResources.AspLong,                    
                    Image = GradeLessonResources.AspImage
                },
                new Customer {
                    Title = GradeLessonResources.Vk,
                    Description = GradeLessonResources.VkLong,                    
                    Image = GradeLessonResources.VkImage
                },
                new Customer {
                    Title = GradeLessonResources.Gfr,
                    Description = GradeLessonResources.GfrLong,
                    Image = GradeLessonResources.GfrImage
                },
                new Customer {
                    Title = GradeLessonResources.Kpl,
                    Description = GradeLessonResources.KplLong,
                    Image = GradeLessonResources.KplImage
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