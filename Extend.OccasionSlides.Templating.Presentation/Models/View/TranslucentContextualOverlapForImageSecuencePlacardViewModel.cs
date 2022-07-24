namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View
{
    public class TranslucentContextualOverlapForImageSecuencePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel, Contract.IContextualOverlapPlacardViewModelSKPathTransformable
    {
        public Enumerations.OverlapShapeKind OverlapShapeKind { get; set; }

        public Enumerations.OverlapSize OverlapSize { get; set; }

        public string Title { get; set; }

        public string TitleFontFamily { get; set; }

        public int TitleFontSize { get; set; }

        public Templating.Models.Context.TextContentBlockContextModel[] ContentBlocks { get; set; }

        public Enumerations.OverlapAlignment OverlapAlignment { get; set; }

        public Essential.Templating.Models.Context.PictureSlideSecuencePlacardContextModel PresentedPictureSlideSecuence { get; set; }

        public Xamarin.Forms.Color OverlapBackgroundColor { get; set; }

        public Xamarin.Forms.Color TextColor { get; set; }
    }
}
