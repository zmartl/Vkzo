using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Newtonsoft.Json;

using PCLStorage;
using PCLStorage.Exceptions;

using Plugin.Connectivity;

using Vkazo.Model;
using Vkazo.ViewModel;

using Xamarin.Forms;

namespace Vkazo.Pages
{
    public partial class OrganisationOverviewPage : ContentPage, INotifyPropertyChanged
    {
        private const string FOLDERNAME = "Vkazo";
        private const string FILENAME = "VkzoOrganisationPage.txt";
        private const string URL = "https://luca-marti.ch/app/organisation.php";
        private IFile _localFile;
        private IFolder _localFolder;
        private ObservableCollection<Organisation> _organisationList;
        public new event PropertyChangedEventHandler PropertyChanged = delegate { };

        public ObservableCollection<Organisation> OrganisationList
        {
            get { return _organisationList; }
            set
            {
                _organisationList = value;
                RaisePropertyChanged();
            }
        }

        public OrganisationOverviewPage()
        {
            InitializeComponent();
            BindingContext = this;
            OrganisationList = new ObservableCollection<Organisation>();
            CustomerListView.Footer = string.Empty;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var result = "";
            var rootFolder = FileSystem.Current.LocalStorage;

            if (CrossConnectivity.Current.IsConnected)
            {
                // Uncomment when not behind proxy              
                // var client = new HttpClient();
                // result = await client.GetStringAsync(URL);
                var folder = await rootFolder.CreateFolderAsync(FOLDERNAME, CreationCollisionOption.OpenIfExists);

                var file = await folder.CreateFileAsync(FILENAME, CreationCollisionOption.ReplaceExisting);

                //comment when not behind proxy
                result = "[{\"Title\":\"VKAZO\",\"Image\":\"icon.png\",\"Description\":\"Verkehrskadetten Zürcher Oberland\",\"Founder\":\"Heinrich Guggenbühl\",\"FoundingYear\":\"1967\",\"Nickname\":\"Regula\",\"Email\":\"einsatz.info@vkazo.ch\",\"Telephonenumber\":\"079 693 50 56\"}]";

                if (result == "")
                {
                    result = "[{\"Title\": \"Keine Daten vorhanden\"}]";
                }

                await file.WriteAllTextAsync(result);
            }
            else
            {
                try
                {
                    _localFolder = await rootFolder.GetFolderAsync(FOLDERNAME);
                    _localFile = await _localFolder.GetFileAsync(FILENAME);
                    result = await _localFile.ReadAllTextAsync();

                    if (string.IsNullOrEmpty(result))
                    {
                        throw new FileNotFoundException("result is empty");
                    }
                }
                catch (FileNotFoundException e)
                {
                    DisplayAlert("Keine Netzwerkverbindung", "Die Daten konnten nicht geladen werden", "Ok");
                    result = "[{\"Date\": \"Die Daten konten nicht geladen werden\"}]";
                }                        
                
            }
            OrganisationList = new ObservableCollection<Organisation>(JsonConvert.DeserializeObject<IEnumerable<Organisation>>(result));
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