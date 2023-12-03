using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Placard;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Views.Placard
{
    public partial class CenteredTraslucentIntroOverImagePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public CenteredTraslucentIntroOverImagePlacardView(CenteredTraslucentIntroOverImagePlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;

            OverlapLayout.BackgroundColor = model.OverlapBackgroundColor.MultiplyAlpha(model.OverlapOpacity);
            OverlapLayout.IsVisible = false;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => PlacardLayout;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            BackgroundImagen.Source = null;
            BackgroundImageThumbnailImage.Source = null;
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var concreteBindingContext = BindingContext as CenteredTraslucentIntroOverImagePlacardViewModel;

            var internalShowInStoryboard = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                Delay = "2000",
                IsParallel = true
            };

            OverlapLayout.IsVisible = true;

            int overlapShowInAnimationDuration = 650;
            int infoBlockShoInAnimationDuration = 600;

            var infoBlockLayoutIndex = 0;

            switch (concreteBindingContext.ContentBoxPresentationKind)
            {
                case CenteredContentBoxPresentationKind.Inmersive:
                    OverlapLayout.Opacity = 0;

                    foreach (var infoBlockLayout in InfoBlocksLayout.Children)
                    {
                        if (infoBlockLayout.BindingContext is TransparentSeparatorContentBlockViewModel) continue;

                        infoBlockLayout.Scale = 0;
                    }

                    internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeToAnimation
                    {
                        Target = OverlapLayout,
                        Opacity = 1,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.Linear,
                        Duration = overlapShowInAnimationDuration.ToString()
                    });
                    
                    foreach (var infoBlockLayout in InfoBlocksLayout.Children)
                    {
                        if (infoBlockLayout.BindingContext is TransparentSeparatorContentBlockViewModel) continue;

                        internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
                        {
                            Target = infoBlockLayout,
                            Scale = 1,
                            Delay = (overlapShowInAnimationDuration + infoBlockShoInAnimationDuration / 2 * infoBlockLayoutIndex++).ToString(),
                            EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.SpringOut,
                            Duration = infoBlockShoInAnimationDuration.ToString()
                        });
                    }

                    break;

                case CenteredContentBoxPresentationKind.FloatBandHorizontal:
                    OverlapLayout.TranslationY = Height;

                    foreach (var infoBlockLayout in InfoBlocksLayout.Children)
                    {
                        if (infoBlockLayout.BindingContext is TransparentSeparatorContentBlockViewModel) continue;

                        infoBlockLayout.Opacity = 0;
                    }

                    internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToYAnimation
                    {
                        Target = OverlapLayout,
                        TranslateY = 0,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.SpringOut,
                        Duration = overlapShowInAnimationDuration.ToString()
                    });

                    var iteration = 1;

                    foreach (var infoBlockLayout in InfoBlocksLayout.Children)
                    {
                        if (infoBlockLayout.BindingContext is TransparentSeparatorContentBlockViewModel) continue;

                        internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeInAnimation
                        {
                            Target = infoBlockLayout,
                            Direction = iteration++ % 2 == 0 ? SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Left : SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Right,
                            RelativeOffset = 100d,
                            Delay = (overlapShowInAnimationDuration + infoBlockShoInAnimationDuration / 2 * infoBlockLayoutIndex++).ToString(),
                            EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                            Duration = infoBlockShoInAnimationDuration.ToString()
                        });
                    }

                    break;

                case CenteredContentBoxPresentationKind.FloatBandVertical:
                    OverlapLayout.TranslationX = Width;

                    foreach (var infoBlockLayout in InfoBlocksLayout.Children)
                    {
                        if (infoBlockLayout.BindingContext is TransparentSeparatorContentBlockViewModel) continue;

                        infoBlockLayout.Opacity = 0;
                    }

                    internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = OverlapLayout,
                        TranslateX = 0,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.SpringOut,
                        Duration = overlapShowInAnimationDuration.ToString()
                    });

                    foreach (var infoBlockLayout in InfoBlocksLayout.Children)
                    {
                        if (infoBlockLayout.BindingContext is TransparentSeparatorContentBlockViewModel) continue;

                        internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeInAnimation
                        {
                            Target = infoBlockLayout,
                            Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Up,
                            RelativeOffset = 100d,
                            Delay = (overlapShowInAnimationDuration + infoBlockShoInAnimationDuration / 2 * infoBlockLayoutIndex++).ToString(),
                            EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                            Duration = infoBlockShoInAnimationDuration.ToString()
                        });
                    }

                    break;

                case CenteredContentBoxPresentationKind.FloatBoxFilled:
                default:
                    OverlapLayout.Scale = 0;

                    foreach (var infoBlockLayout in InfoBlocksLayout.Children)
                    {
                        if (infoBlockLayout.BindingContext is TransparentSeparatorContentBlockViewModel) continue;

                        infoBlockLayout.Scale = 0;
                    }

                    internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
                    {
                        Target = OverlapLayout,
                        Scale = 1,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.SpringOut,
                        Duration = overlapShowInAnimationDuration.ToString()
                    });

                    foreach (var infoBlockLayout in InfoBlocksLayout.Children)
                    {
                        if (infoBlockLayout.BindingContext is TransparentSeparatorContentBlockViewModel) continue;

                        internalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
                        {
                            Target = infoBlockLayout,
                            Scale = 1,
                            Delay = (overlapShowInAnimationDuration + infoBlockShoInAnimationDuration / 2 * infoBlockLayoutIndex++).ToString(),
                            EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.SpringOut,
                            Duration = infoBlockShoInAnimationDuration.ToString()
                        });
                    }

                    break;
            }

            internalShowInStoryboard.Begin();

            if (concreteBindingContext.BackgroundImageZoomingEnabled && concreteBindingContext.ScreenPresentationTime > System.TimeSpan.Zero)
            {
                var presentedImageZoominAnimation = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.ScaleToAnimation
                {
                    Target = BackgroundImageWrapper,
                    Scale = 1.2,
                    Duration = concreteBindingContext.ScreenPresentationTime.TotalMilliseconds.ToString()
                };

                presentedImageZoominAnimation.Begin();
            }
        }
    }
}