using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View.Contract;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View
{
    public class LandscapeAnonimusHeroPlacardViewModel : AbstractMuseographyPlacardViewModel
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
