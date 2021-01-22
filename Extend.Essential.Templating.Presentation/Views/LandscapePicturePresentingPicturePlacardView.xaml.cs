namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Views
{
    public partial class LandscapePicturePresentingPicturePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public LandscapePicturePresentingPicturePlacardView(Models.View.LandscapePicturePresentingPicturePlacardViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => PlacardLayout;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var model = BindingContext as Models.View.LandscapePicturePresentingPicturePlacardViewModel;

            var width = PlacardLayout.Height * model.PresenterImageWidth / model.PresenterImageHeigth;

            if (model.PresenterSide == Enumerations.LandscapePresentationSide.Left)
            {
                PresenterImage.TranslationX = width * -1;
            }
            else
            {
                PresenterImage.TranslationX = width;
            }

            PresenterImage.IsVisible = true;

            var internalShowInStoryboard = new XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                Delay = "2000",
                IsParallel = true
            };

            internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
            {
                Target = PresenterImage,
                TranslateX = 0,                
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut
            });

            if (model.PresentedImageCenteredAtPresentation)
            {
                internalShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                {
                    Target = PresentedImage,
                    TranslateX = model.PresenterSide == Enumerations.LandscapePresentationSide.Left ?  width / 2 : width / 2 * -1,
                    EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                    Delay = "100"
                });
            }

            internalShowInStoryboard.Begin();

            if (model.PresentedImageZoomingEnabled)
            {
                var presentedImageZoominAnimation = new XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
                {
                    Target = PresentedImage,
                    Scale = 1.2,
                    Duration = model.ScreenPresentationTime.TotalMilliseconds.ToString()
                };

                presentedImageZoominAnimation.Begin();
            }
        }
    }
}