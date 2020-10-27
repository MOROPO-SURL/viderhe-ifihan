namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class SimplePicturePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel image;
        private Xamarin.Forms.Aspect aspect;

        public SimplePicturePlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;

            Aspects = new Xamarin.Forms.Aspect[] { Xamarin.Forms.Aspect.AspectFill, Xamarin.Forms.Aspect.AspectFit, Xamarin.Forms.Aspect.Fill };
        }

        public Xamarin.Forms.Aspect Aspect
        {
            get => aspect;
            set => SetProperty(ref aspect, value);
        }

        public Support.Presentation.Models.View.ImageViewModel Image { get => image; set => SetProperty(ref image, value); }

        public Xamarin.Forms.Aspect[] Aspects { get; private set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Image = null;

            Aspects = null;
        }
    }
}
