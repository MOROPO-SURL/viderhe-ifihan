using MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class ManagePlayersPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private PlayerFilterModel filter;
        private bool isGlobalAudioEnabled;
        private bool isBatchActionEnabled;

        public ManagePlayersPageModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<View.PlayerViewModel>();
            IsGlobalAudioEnabled = true;
        }

        public System.Collections.ObjectModel.ObservableCollection<View.PlayerViewModel> Items { get; set; }

        public PlayerFilterModel Filter { get => filter; set => SetProperty(ref filter, value, FilterParamaChangeCallbackAction); }

        public System.Action FilterParamaChangeCallbackAction { get; set; }

        public bool IsGlobalAudioEnabled { get => isGlobalAudioEnabled; set => SetProperty(ref isGlobalAudioEnabled, value); }

        public bool IsBatchActionEnabled { get => isBatchActionEnabled; set => SetProperty(ref isBatchActionEnabled, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Items.Clear();

            Items = null;

            FilterParamaChangeCallbackAction = null;
        }
    }
}
