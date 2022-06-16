using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page
{
    public class CenteredTraslucentIntroOverImagePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel headerImage;
        private Support.Presentation.Models.View.ImageViewModel backgroundImage;
        private bool backgroundImageZoomingEnabled;
        private Xamarin.Forms.Color overlapBackgroundColor;
        private Xamarin.Forms.Color textColor;
        private CenteredContentBoxPresentationKind contentBoxPresentationKind;
        private string title;
        private string titleFontFamily;
        private int titleFontSize;
        private int overlapOpacity;

        public CenteredTraslucentIntroOverImagePlacardConfigurationPageModel()
        {
            TitleFontSize = 48;
            OverlapOpacity = 50;
            OverlapBackgroundColor = Xamarin.Forms.Color.Black;
            TextColor = Xamarin.Forms.Color.White;
            ContentBlocks = new System.Collections.ObjectModel.ObservableCollection<View.TextContentBlockViewModel>();
            AvailableContentBoxPresentationKinds = new CenteredContentBoxPresentationKind[]
            {
                CenteredContentBoxPresentationKind.Inmersive,
                CenteredContentBoxPresentationKind.FloatBoxFilled,
                CenteredContentBoxPresentationKind.FloatBandHorizontal,
                CenteredContentBoxPresentationKind.FloatBandVertical
            };
        }

        public Support.Presentation.Models.View.ImageViewModel HeaderImage { get => headerImage; set => SetProperty(ref headerImage, value); }

        public Support.Presentation.Models.View.ImageViewModel BackgroundImage { get => backgroundImage; set => SetProperty(ref backgroundImage, value); }

        public bool BackgroundImageZoomingEnabled { get => backgroundImageZoomingEnabled; set => SetProperty(ref backgroundImageZoomingEnabled, value); }

        public int OverlapOpacity { get => overlapOpacity; set => SetProperty(ref overlapOpacity, value); }

        public Xamarin.Forms.Color OverlapBackgroundColor { get => overlapBackgroundColor; set => SetProperty(ref overlapBackgroundColor, value); }

        public Xamarin.Forms.Color TextColor { get => textColor; set => SetProperty(ref textColor, value); }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string TitleFontFamily { get => titleFontFamily; set => SetProperty(ref titleFontFamily, value); }

        public int TitleFontSize { get => titleFontSize; set => SetProperty(ref titleFontSize, value); }

        public System.Collections.ObjectModel.ObservableCollection<View.TextContentBlockViewModel> ContentBlocks { get; private set; }

        public CenteredContentBoxPresentationKind ContentBoxPresentationKind { get => contentBoxPresentationKind; set => SetProperty(ref contentBoxPresentationKind, value); }

        public CenteredContentBoxPresentationKind[] AvailableContentBoxPresentationKinds { get; private set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            HeaderImage = null;
            BackgroundImage = null;
        }
    }
}
