namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View.Contract
{
    public abstract class AbstractImageMuseographyPlacardViewModel : AbstractMuseographyPlacardViewModel
    {
        public Xamarin.Forms.ImageSource ContextedImageSource { get; set; }

        public bool ContextedImageZoomingEnabled { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImageSource = null;
        }
    }
}
