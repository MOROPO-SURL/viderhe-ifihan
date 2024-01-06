namespace MOROPO.VIDERHE.Extend.CPCC.Templating.Presentation.Models.View
{
    public class PortraitPosterVideoEventPromotionPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel
    {
        public Xamarin.Forms.ImageSource PosterSource { get; set; }

        public SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource VideoSource { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PosterSource = null;
            VideoSource = null;
        }
    }
}
