namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View
{
    public class PortraitTranslucentContextualOverlapForImagePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        public Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        public string Title { get; set; }

        public string TitleFontFamily { get; set; }

        public int TitleFontSize { get; set; }

        public TextContentBlockModel[] ContentBlocks { get; set; }

        public Enumerations.OverlapVerticalAlignment OverlapVerticalAlignment { get; set; }

        public Xamarin.Forms.ImageSource ContextedImageSource { get; set; }

        public bool ContextedImageZoomingEnabled { get; set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get; set; }

        public Xamarin.Forms.Color TextColor { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImageSource = null;
        }
    }
}
