namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Models.Page
{
    public class ImagesPickPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private int total;
        private bool isLoadingInfinity;

        public ImagesPickPageModel()
        {
            isLoadingInfinity = false;

            SelectableImages = new System.Collections.ObjectModel.ObservableCollection<View.SelectableModelViewModel<Presentation.Models.View.ImageViewModel>>();
        }

        public System.Collections.ObjectModel.ObservableCollection<View.SelectableModelViewModel<Presentation.Models.View.ImageViewModel>> SelectableImages { get; set; }

        public int Total { get => total; set => SetProperty(ref total, value); }

        public bool IsLoadingInfinite { get => isLoadingInfinity; set => SetProperty(ref isLoadingInfinity, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            SelectableImages.Clear();

            SelectableImages = null;
        }
    }
}
