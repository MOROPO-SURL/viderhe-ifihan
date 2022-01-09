namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Contract
{
    public abstract class AbstractLandscapeContextualOperlapForImagePlacardViewModel : AbstractLandscapeContextualOverlapMediaPlacardViewModel
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
