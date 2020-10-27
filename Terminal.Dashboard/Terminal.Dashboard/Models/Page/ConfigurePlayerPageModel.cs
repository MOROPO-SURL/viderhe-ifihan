namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Models.Page
{
    public class ConfigurePlayerPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string id;
        private string name;
        private string about;
        private Cloud.Api.Common.Models.ScreenplayDisplayModel screenplay;

        public ConfigurePlayerPageModel()
        {
            Screenplays = new System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.ScreenplayDisplayModel>();
        }

        public string Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }

        public Cloud.Api.Common.Models.ScreenplayDisplayModel Screenplay
        {
            get => screenplay;
            set => SetProperty(ref screenplay, value);
        }

        public System.Collections.ObjectModel.ObservableCollection<Cloud.Api.Common.Models.ScreenplayDisplayModel> Screenplays { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Screenplays.Clear();

            Screenplays = null;

            Screenplay = null;
        }
    }
}
