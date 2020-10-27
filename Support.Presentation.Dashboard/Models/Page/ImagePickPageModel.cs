namespace SmartSolucionesCuba.Videre.Support.Presentation.Dashboard.Models.Page
{
    public class ImagePickPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private int total;
        private bool isLoadingInfinity;

        public ImagePickPageModel()
        {
            isLoadingInfinity = false;

            Images = new System.Collections.ObjectModel.ObservableCollection<Presentation.Models.View.ImageViewModel>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Presentation.Models.View.ImageViewModel> Images { get; set; }

        public int Total { get => total; set => SetProperty(ref total, value); }

        public bool IsLoadingInfinite { get => isLoadingInfinity; set => SetProperty(ref isLoadingInfinity, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Images.Clear();

            Images = null;
        }
    }
}
