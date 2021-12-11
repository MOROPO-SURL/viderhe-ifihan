namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View
{
    public class LandscapeVerticalStripeContextualizingImagePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        public Xamarin.Forms.ImageSource ContextedImageSource { get; set; }

        public bool ContextedImageZoomingEnabled { get; set; }

        public Xamarin.Forms.Color StripeBackgroundColor { get; set; }

        public string Header { get; set; }

        public int HeaderFontSize { get; set; }

        public string Content { get; set; }

        public int ContentFontSize { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImageSource = null;
        }
    }
}
