using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page
{
    public class ImagesPickPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool hasMoreImages;

        public ImagesPickPageModel()
        {
            SelectableImages = new System.Collections.ObjectModel.ObservableCollection<View.SelectableModelViewModel<ImageViewModel>>();
        }

        public System.Collections.ObjectModel.ObservableCollection<View.SelectableModelViewModel<ImageViewModel>> SelectableImages { get; set; }

        public bool HasMoreImages { get => hasMoreImages; set => SetProperty(ref hasMoreImages, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            SelectableImages.Clear();

            SelectableImages = null;
        }
    }
}
