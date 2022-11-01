using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Placard
{
    public class CenteredTraslucentIntroOverImagePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel headerImage;
        private Support.Presentation.Models.View.ImageViewModel backgroundImage;
        private bool backgroundImageZoomingEnabled;
        private Xamarin.Forms.Color overlapBackgroundColor;
        private CenteredContentBoxPresentationKind contentBoxPresentationKind;
        private int overlapOpacity;

        public CenteredTraslucentIntroOverImagePlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 10;
            OverlapOpacity = 50;
            OverlapBackgroundColor = Xamarin.Forms.Color.Black;
            ContentBlocks = new System.Collections.ObjectModel.ObservableCollection<Templating.Presentation.Models.View.Block.Contract.AbstractContentBlockViewModel>();
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

        public System.Collections.ObjectModel.ObservableCollection<Templating.Presentation.Models.View.Block.Contract.AbstractContentBlockViewModel> ContentBlocks { get; private set; }

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
