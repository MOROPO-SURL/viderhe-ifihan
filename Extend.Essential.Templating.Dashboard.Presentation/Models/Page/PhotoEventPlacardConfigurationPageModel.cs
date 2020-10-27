namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class PhotoEventPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractScreenTimedPlacardConfigurationPageModel
    {
        private string title;
        private string when;
        private string where;
        private string about;
        private Support.Presentation.Models.View.ImageViewModel image;
        private bool imageZoomingEnabled;
        private Xamarin.Forms.Aspect aspect;

        public PhotoEventPlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;

            Aspects = new Xamarin.Forms.Aspect[] { Xamarin.Forms.Aspect.AspectFill, Xamarin.Forms.Aspect.AspectFit, Xamarin.Forms.Aspect.Fill };
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string When
        {
            get => when;
            set => SetProperty(ref when, value);
        }

        public string Where
        {
            get => where;
            set => SetProperty(ref where, value);
        }

        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }

        public Xamarin.Forms.Aspect Aspect
        {
            get => aspect;
            set => SetProperty(ref aspect, value);
        }

        public bool IsImageZoomingEnabled
        {
            get => imageZoomingEnabled;
            set => SetProperty(ref imageZoomingEnabled, value);
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
