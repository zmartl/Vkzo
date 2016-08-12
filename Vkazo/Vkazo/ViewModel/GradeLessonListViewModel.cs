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
            Title = AppResources.GradeLesson;
            Items = new ObservableCollection<Customer> {
                new Customer {
                    Title = GradeLessonResources.AspLong,
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
                },
                new Customer {
                    Title = GradeLessonResources.Lt,
                    Description = GradeLessonResources.LtLong,
                    Image = GradeLessonResources.LtImage
                },
                new Customer {
                    Title = GradeLessonResources.Oblt,
                    Description = GradeLessonResources.ObltLong,
                    Image = GradeLessonResources.ObltImage
                },
                new Customer {
                    Title = GradeLessonResources.Hptm,
                    Description = GradeLessonResources.HptmLong,
                    Image = GradeLessonResources.HptmImage
                },
                new Customer {
                    Title = GradeLessonResources.Maj,
                    Description = GradeLessonResources.MajLong,
                    Image = GradeLessonResources.MajImage
                },
                new Customer {
                    Title = GradeLessonResources.Adj,
                    Description = GradeLessonResources.AdjLong,
                    Image = GradeLessonResources.AdjImage
                },
                new Customer {
                    Title = GradeLessonResources.Oberstlt,
                    Description = GradeLessonResources.OberstltLong,
                    Image = GradeLessonResources.OberstltImage
                },
                new Customer {
                    Title = GradeLessonResources.Oberst,
                    Description = GradeLessonResources.OberstLong,
                    Image = GradeLessonResources.OberstImage
                },
                new Customer {
                    Title = GradeLessonResources.Praesident,
                    Description = GradeLessonResources.PraesidentLong,
                    Image = GradeLessonResources.PraesidentImage
                }
            };
        }

        #region Overrides of AbstractListViewModel<Customer>

        public override void OnSelectedItem(Customer item, INavigation navigation)
        {
            var detailPage = new Pages.GradeDetailPage {Item = item};
            navigation.PushAsync(detailPage);
        }

        #endregion
    }
}