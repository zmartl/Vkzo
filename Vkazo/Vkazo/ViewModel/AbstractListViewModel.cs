using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace Vkazo.ViewModel
{
    public abstract class AbstractListViewModel<TItem> : AbstractViewModel, IOnItemSelected
    {
        private ObservableCollection<TItem> _items = new ObservableCollection<TItem>();
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (value == _title) return;
                _title = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TItem> Items
        {
            get { return _items; }
            set
            {
                if (Equals(value, _items)) return;
                _items = value;
                OnPropertyChanged();
            }
        }

        #region Implementation of IOnItemSelected

        public void OnSelectedItem(object o, INavigation navigation)
        {
            if (o is TItem)
                OnSelectedItem((TItem) o, navigation);
        }

        #endregion

        public virtual void OnSelectedItem(TItem item, INavigation navigation) {}
    }
}