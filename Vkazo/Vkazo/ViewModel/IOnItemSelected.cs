using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Vkazo.ViewModel
{
    public interface IOnItemSelected
    {
        void OnSelectedItem(object o, INavigation navigation);
    }
}
