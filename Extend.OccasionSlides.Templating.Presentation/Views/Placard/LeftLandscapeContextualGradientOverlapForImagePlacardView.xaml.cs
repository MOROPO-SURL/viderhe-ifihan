using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Views.Placard
{
    public partial class LeftLandscapeContextualGradientOverlapForImagePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public LeftLandscapeContextualGradientOverlapForImagePlacardView(GradientContextualOverlapForImagePlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;

            OverlapLayout.Opacity = 0;
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

            var concreteBindingContext = BindingContext as GradientContextualOverlapForImagePlacardViewModel;

            foreach (var item in InfoBlocksLayout.Children)
            {
                if (item.BindingContext is TransparentSeparatorContentBlockViewModel) continue;

                item.Opacity = 0;
            }

            var contentBoxWidth = Width * ((concreteBindingContext.OverlapSize.ToColumnCount() - 1) / 6d);

            OverlapLayout.TranslationX = Width * (concreteBindingContext.OverlapSize.ToColumnCount() / 6d) * -1;

            int overlapShowInAnimationDuration = 650;
            int infoBlockShoInAnimationDuration = 600;

            var internalShowInStoryboard = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                Delay = "2000",
                IsParallel = true
            };

            internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeInAnimation
            {
                Target = OverlapLayout,
                RelativeOffset = System.Math.Abs(TranslationX),
                Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Right,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                Duration = overlapShowInAnimationDuration.ToString()
            });

            if (concreteBindingContext.ContextedImageCenteredAtPresentation)
            {
                internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                {
                    Target = ContextedImageWrapper,
                    TranslateX = concreteBindingContext.OverlapAlignment == OverlapAlignment.Start ? contentBoxWidth / 2 : contentBoxWidth / 2 * -1,
                    EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicInOut,
                    Delay = "100"
                });
            }

            var index = 0;

            foreach (var infoBlockLayout in InfoBlocksLayout.Children)
            {
                if (infoBlockLayout.BindingContext is TransparentSeparatorContentBlockViewModel) continue;

                internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeInAnimation
                {
                    Target = infoBlockLayout,
                    Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Right,
                    RelativeOffset = 100d,
                    Delay = (overlapShowInAnimationDuration + infoBlockShoInAnimationDuration / 2 * index++).ToString(),
                    EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                    Duration = infoBlockShoInAnimationDuration.ToString()
                });
            }

            internalShowInStoryboard.Begin();

            if (concreteBindingContext.ContextedImageZoomingEnabled && concreteBindingContext.ScreenPresentationTime > System.TimeSpan.Zero)
            {
                var presentedImageZoominAnimation = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
                {
                    Target = ContextedImageWrapper,
                    Scale = 1.2,
                    Duration = concreteBindingContext.ScreenPresentationTime.TotalMilliseconds.ToString()
                };

                presentedImageZoominAnimation.Begin();
            }
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImagen.Source = null;
            ContextedImageThumbnailImage.Source = null;
        }
    }
}