namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeContextualTranslucentOverlapForImagePlacardConfigurationPageModel : Contract.AbstractLandscapeContextualOperlapForImagePlacardConfigurationPageModel
    {
        private Xamarin.Forms.Color overlapBackgroundColor;
        private Xamarin.Forms.Color textColor;

        public LandscapeContextualTranslucentOverlapForImagePlacardConfigurationPageModel()
        {
            OverlapBackgroundColor = Xamarin.Forms.Color.Black;
            TextColor = Xamarin.Forms.Color.White;
        }

        public Xamarin.Forms.Color OverlapBackgroundColor { get => overlapBackgroundColor; set => SetProperty(ref overlapBackgroundColor, value); }

        public Xamarin.Forms.Color TextColor { get => textColor; set => SetProperty(ref textColor, value); }
    }
}
