namespace SmartSolucionesCuba.Videre.Support.Presentation.Dashboard.Models.Page
{
    public class VideoPickPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private int total;
        private bool isLoadingInfinity;

        public VideoPickPageModel()
        {
            isLoadingInfinity = false;

            Videos = new System.Collections.ObjectModel.ObservableCollection<Presentation.Models.View.VideoViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Presentation.Models.View.VideoViewModel> Videos { get; set; }

        public int Total { get => total; set => SetProperty(ref total, value); }

        public bool IsLoadingInfinite { get => isLoadingInfinity; set => SetProperty(ref isLoadingInfinity, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Videos.Clear();

            Videos = null;
        }
    }
}
