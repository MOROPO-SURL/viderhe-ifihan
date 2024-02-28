namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page.Contract
{
    public abstract class AbstractImagedMuseographyPlacardConfigurationPageModel : AbstractMuseographyPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel contextedImage;
        private bool isContextedImageZoomingEnabled;

        public Support.Presentation.Models.View.ImageViewModel ContextedImage { get => contextedImage; set => SetProperty(ref contextedImage, value); }

        public bool IsContextedImageZoomingEnabled { get => isContextedImageZoomingEnabled; set => SetProperty(ref isContextedImageZoomingEnabled, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImage = null;
        }
    }
}
