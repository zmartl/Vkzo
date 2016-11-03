using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using PCLStorage;
using PCLStorage.Exceptions;
using Plugin.Connectivity;
using Vkazo.Model;
using Xamarin.Forms;

namespace Vkazo.Pages
{
    public partial class OrganisationOverviewPage : ContentPage, INotifyPropertyChanged
    {
        private const string Foldername = "Vkazo";
        private const string Filename = "VkzoOrganisationPage.txt";
        private const string Url = "https://luca-marti.ch/app/organisation.php";
        private IFile _localFile;
        private IFolder _localFolder;
        private ObservableCollection<Organisation> _organisationList;

        public OrganisationOverviewPage()
        {
            InitializeComponent();
            BindingContext = this;
            OrganisationList = new ObservableCollection<Organisation>();
        }

        public ObservableCollection<Organisation> OrganisationList
        {
            get { return _organisationList; }
            set
            {
                _organisationList = value;
                RaisePropertyChanged();
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var result = "";
            var rootFolder = FileSystem.Current.LocalStorage;

            if (CrossConnectivity.Current.IsConnected)
            {
                // Uncomment when not behind proxy              
                var client = new HttpClient();
                result = await client.GetStringAsync(Url);
                var folder = await rootFolder.CreateFolderAsync(Foldername, CreationCollisionOption.OpenIfExists);

                var file = await folder.CreateFileAsync(Filename, CreationCollisionOption.ReplaceExisting);

                if (result == "")
                    result = "[{\"Title\": \"Keine Daten vorhanden\"}]";

                await file.WriteAllTextAsync(result);
            }
            else
            {
                try
                {
                    _localFolder = await rootFolder.GetFolderAsync(Foldername);
                    _localFile = await _localFolder.GetFileAsync(Filename);
                    result = await _localFile.ReadAllTextAsync();

                    if (string.IsNullOrEmpty(result))
                        throw new FileNotFoundException("result is empty");
                }
                catch (FileNotFoundException e)
                {
                    await DisplayAlert("Keine Netzwerkverbindung", "Die Daten konnten nicht geladen werden", "Ok");
                    result = "[{\"Date\": \"Die Daten konten nicht geladen werden\"}]";
                }
            }
            OrganisationList =
                new ObservableCollection<Organisation>(JsonConvert.DeserializeObject<IEnumerable<Organisation>>(result));
        }

        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            Navigation.PushAsync(new OrganisationDetailPage {Item = (Organisation) e.SelectedItem});

            ((ListView) sender).SelectedItem = null;
        }

        #region INotifyPropertyChanged

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}