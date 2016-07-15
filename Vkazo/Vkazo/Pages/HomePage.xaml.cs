using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Newtonsoft.Json;

using PCLStorage;

using Plugin.Connectivity;

using Vkazo.Model;

using Xamarin.Forms;

namespace Vkazo.Pages
{
    public partial class HomePage : ContentPage, INotifyPropertyChanged
    {
        private const string FOLDERNAME = "Vkazo";
        private const string FILENAME = "VkzoHomePage.txt";
        private IFile _localFile;
        private IFolder _localFolder;
        private ObservableCollection<Program> _programList;

        public ObservableCollection<Program> ProgramList
        {
            get { return _programList; }
            set
            {
                _programList = value;
                RaisePropertyChanged();
            }
        }

        public HomePage()
        {
            InitializeComponent();
            BindingContext = this;
            ProgramList = new ObservableCollection<Program>();
            MainListView.Footer = string.Empty;
        }

        #region Overrides of Page

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var result = "";
            var rootFolder = FileSystem.Current.LocalStorage;


            //remove ! if not behind proxy
            if (CrossConnectivity.Current.IsConnected)
            {
                // Uncomment when not behind proxy
                //const string URL = "https://luca-marti.ch/app/program.php";
                //var client = new HttpClient();
                //result = await client.GetStringAsync(URL);

                var folder = await rootFolder.CreateFolderAsync(FOLDERNAME, CreationCollisionOption.OpenIfExists);

                var file = await folder.CreateFileAsync(FILENAME, CreationCollisionOption.ReplaceExisting);

                // Uncomment when behind proxy
                result =
                    "[{\"Date\": \"01.07.2016\", \"Title\": \"Hauptsitz Flughafen ZÃ¼rich AG\",},  {\"Date\": \"02.07.2016\",\"Title\": \"Hauptsitz Flughafen ZÃ¼rich AG\",},{\"Date\": \"03.07.2016\",\"Title\": \"ZÃ¼rich Zoo\",}]";

                if (result == "")
                {
                    result = "[{\"Date\": \"Keine Daten vorhanden\"}]";
                }

                await file.WriteAllTextAsync(result);
            }
            else
            {
                _localFolder = await rootFolder.GetFolderAsync(FOLDERNAME);
                _localFile = await _localFolder.GetFileAsync(FILENAME);
                //result = await _localFile.ReadAllTextAsync();

                if (result == "")
                {
                    await DisplayAlert("Keine Netzwerkverbindung", "Die Daten konnten nicht geladen werden", "Ok");
                    result = "[{\"Date\": \"Die Daten konten nicht geladen werden\"}]";
                }
            }
            ProgramList = new ObservableCollection<Program>(JsonConvert.DeserializeObject<IEnumerable<Program>>(result));
        }

        #endregion

        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView) sender).SelectedItem = null;
        }

        #region INotifyPropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}