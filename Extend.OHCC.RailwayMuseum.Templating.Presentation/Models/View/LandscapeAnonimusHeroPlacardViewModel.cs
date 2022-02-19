namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View
{
    public class LandscapeAnonimusHeroPlacardViewModel : Contract.AbstractMuseographyPlacardViewModel
    {
        public Xamarin.Forms.ImageSource HeroImageSource { get; set; }

        public Enumerations.AnonimusHeroBackgroundMode BackgroundMode { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            HeroImageSource = null;
        }
    }
}
