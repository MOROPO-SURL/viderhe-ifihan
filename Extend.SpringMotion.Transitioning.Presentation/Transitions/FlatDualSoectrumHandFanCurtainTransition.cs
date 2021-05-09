using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations;

namespace SmartSolucionesCuba.Viderhe.Extend.SpringMotion.Transitioning.Presentation.Transitions
{
    public class FlatDualSoectrumHandFanCurtainTransition : Common.Transitioning.Presentation.Transitions.AbstractTransition
    {
        private Xamarin.Forms.BoxView startFlatSpectrumHandFanPrimaryBoxView;
        private Xamarin.Forms.BoxView startFlatSpectrumHandFanSecoundaryBoxView;
        private Xamarin.Forms.BoxView startFlatSpectrumHandFanNeutralBoxView;
        private Xamarin.Forms.BoxView startFlatSpectrumHandFanPrimaryOpaqueBoxView;
        private Xamarin.Forms.BoxView startFlatSpectrumHandFanSecoundaryOpaqueBoxView;
        private Xamarin.Forms.BoxView startFlatSpectrumHandFanNeutralOpaqueBoxView;

        private Xamarin.Forms.BoxView endFlatSpectrumHandFanPrimaryBoxView;
        private Xamarin.Forms.BoxView endFlatSpectrumHandFanSecoundaryBoxView;
        private Xamarin.Forms.BoxView endFlatSpectrumHandFanNeutralBoxView;
        private Xamarin.Forms.BoxView endFlatSpectrumHandFanPrimaryOpaqueBoxView;
        private Xamarin.Forms.BoxView endFlatSpectrumHandFanSecoundaryOpaqueBoxView;
        private Xamarin.Forms.BoxView endFlatSpectrumHandFanNeutralOpaqueBoxView;

        private Models.Context.BaseFlatSpectrumTransitionContextModel context;

        private AbstractAnimation factShowInAnimation;

        public FlatDualSoectrumHandFanCurtainTransition(Common.Presentation.Views.BasePlacardPresentationView incomingPlacardPresentationView, Common.Presentation.Views.BasePlacardPresentationView outgoingPlacardPresentationView, Models.Context.BaseFlatSpectrumTransitionContextModel context, System.Action<Common.Presentation.Views.BasePlacardPresentationView> motionCompletedActionCallback) : base(incomingPlacardPresentationView, outgoingPlacardPresentationView, motionCompletedActionCallback)
        {
            this.context = context;
        }

        protected override AbstractAnimation FactShowInAnimation => factShowInAnimation;

        public override void GetReady(Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider, Xamarin.Forms.Layout<Xamarin.Forms.View> wrapper)
        {
            var flatSpectrumHandFanBoxViewRequiredWidth = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Orientation == Xamarin.Essentials.DisplayOrientation.Portrait ? wrapper.Width : wrapper.Width / 2;
            var flatSpectrumHandFanBoxViewRequiredHeight = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Orientation == Xamarin.Essentials.DisplayOrientation.Portrait ? wrapper.Height / 2 : wrapper.Height;

            startFlatSpectrumHandFanPrimaryBoxView = new Xamarin.Forms.BoxView
            {
                Color = accountInformationProvider.PrimaryColor,
                WidthRequest = flatSpectrumHandFanBoxViewRequiredWidth,
                HeightRequest = flatSpectrumHandFanBoxViewRequiredHeight,
                TranslationX = flatSpectrumHandFanBoxViewRequiredWidth * -1,
                TranslationY = flatSpectrumHandFanBoxViewRequiredHeight * -1,
                Rotation = 45 * -1
            };

            incomingPlacardPresentationView.ConfigureLayout(startFlatSpectrumHandFanPrimaryBoxView);

            endFlatSpectrumHandFanPrimaryBoxView = new Xamarin.Forms.BoxView
            {
                Color = accountInformationProvider.PrimaryColor,
                WidthRequest = flatSpectrumHandFanBoxViewRequiredWidth,
                HeightRequest = flatSpectrumHandFanBoxViewRequiredHeight,
                TranslationX = flatSpectrumHandFanBoxViewRequiredWidth,
                TranslationY = flatSpectrumHandFanBoxViewRequiredHeight,
                Rotation = 45
            };

            incomingPlacardPresentationView.ConfigureLayout(endFlatSpectrumHandFanPrimaryBoxView);

            startFlatSpectrumHandFanSecoundaryBoxView = new Xamarin.Forms.BoxView
            {
                Color = accountInformationProvider.SecoundaryColor,
                WidthRequest = flatSpectrumHandFanBoxViewRequiredWidth,
                HeightRequest = flatSpectrumHandFanBoxViewRequiredHeight,
                TranslationX = flatSpectrumHandFanBoxViewRequiredWidth * -1,
                TranslationY = flatSpectrumHandFanBoxViewRequiredHeight * -1,
                Rotation = 45 * -1
            };

            incomingPlacardPresentationView.ConfigureLayout(startFlatSpectrumHandFanSecoundaryBoxView);

            endFlatSpectrumHandFanSecoundaryBoxView = new Xamarin.Forms.BoxView
            {
                Color = accountInformationProvider.SecoundaryColor,
                WidthRequest = flatSpectrumHandFanBoxViewRequiredWidth,
                HeightRequest = flatSpectrumHandFanBoxViewRequiredHeight,
                TranslationX = flatSpectrumHandFanBoxViewRequiredWidth,
                TranslationY = flatSpectrumHandFanBoxViewRequiredHeight,
                Rotation = 45
            };

            incomingPlacardPresentationView.ConfigureLayout(endFlatSpectrumHandFanSecoundaryBoxView);

            if (context.UseOpaqueFlatSpectrumItems)
            {
                startFlatSpectrumHandFanPrimaryOpaqueBoxView = new Xamarin.Forms.BoxView
                {
                    Color = accountInformationProvider.PrimaryColor.MultiplyAlpha(0.5),
                    WidthRequest = flatSpectrumHandFanBoxViewRequiredWidth,
                    HeightRequest = flatSpectrumHandFanBoxViewRequiredHeight,
                    TranslationX = flatSpectrumHandFanBoxViewRequiredWidth * -1,
                    TranslationY = flatSpectrumHandFanBoxViewRequiredHeight * -1,
                    Rotation = 45 * -1
                };

                incomingPlacardPresentationView.ConfigureLayout(startFlatSpectrumHandFanPrimaryOpaqueBoxView);

                endFlatSpectrumHandFanPrimaryOpaqueBoxView = new Xamarin.Forms.BoxView
                {
                    Color = accountInformationProvider.PrimaryColor.MultiplyAlpha(0.5),
                    WidthRequest = flatSpectrumHandFanBoxViewRequiredWidth,
                    HeightRequest = flatSpectrumHandFanBoxViewRequiredHeight,
                    TranslationX = flatSpectrumHandFanBoxViewRequiredWidth,
                    TranslationY = flatSpectrumHandFanBoxViewRequiredHeight,
                    Rotation = 45
                };

                incomingPlacardPresentationView.ConfigureLayout(endFlatSpectrumHandFanPrimaryOpaqueBoxView);

                startFlatSpectrumHandFanSecoundaryOpaqueBoxView = new Xamarin.Forms.BoxView
                {
                    Color = accountInformationProvider.SecoundaryColor.MultiplyAlpha(0.5),
                    WidthRequest = flatSpectrumHandFanBoxViewRequiredWidth,
                    HeightRequest = flatSpectrumHandFanBoxViewRequiredHeight,
                    TranslationX = flatSpectrumHandFanBoxViewRequiredWidth * -1,
                    TranslationY = flatSpectrumHandFanBoxViewRequiredHeight * -1,
                    Rotation = 45 * -1
                };

                incomingPlacardPresentationView.ConfigureLayout(startFlatSpectrumHandFanSecoundaryOpaqueBoxView);

                endFlatSpectrumHandFanSecoundaryOpaqueBoxView = new Xamarin.Forms.BoxView
                {
                    Color = accountInformationProvider.SecoundaryColor.MultiplyAlpha(0.5),
                    WidthRequest = flatSpectrumHandFanBoxViewRequiredWidth,
                    HeightRequest = flatSpectrumHandFanBoxViewRequiredHeight,
                    TranslationX = flatSpectrumHandFanBoxViewRequiredWidth,
                    TranslationY = flatSpectrumHandFanBoxViewRequiredHeight,
                    Rotation = 45
                };

                incomingPlacardPresentationView.ConfigureLayout(endFlatSpectrumHandFanSecoundaryOpaqueBoxView);
            }

            if (context.UseNeutralFlatSpectrumItems)
            {
                startFlatSpectrumHandFanNeutralBoxView = new Xamarin.Forms.BoxView
                {
                    Color = Xamarin.Forms.Color.White,
                    WidthRequest = flatSpectrumHandFanBoxViewRequiredWidth,
                    HeightRequest = flatSpectrumHandFanBoxViewRequiredHeight,
                    TranslationX = flatSpectrumHandFanBoxViewRequiredWidth * -1,
                    TranslationY = flatSpectrumHandFanBoxViewRequiredHeight * -1,
                    Rotation = 45 * -1
                };

                incomingPlacardPresentationView.ConfigureLayout(startFlatSpectrumHandFanNeutralBoxView);

                endFlatSpectrumHandFanNeutralBoxView = new Xamarin.Forms.BoxView
                {
                    Color = Xamarin.Forms.Color.White,
                    WidthRequest = flatSpectrumHandFanBoxViewRequiredWidth,
                    HeightRequest = flatSpectrumHandFanBoxViewRequiredHeight,
                    TranslationX = flatSpectrumHandFanBoxViewRequiredWidth,
                    TranslationY = flatSpectrumHandFanBoxViewRequiredHeight,
                    Rotation = 45
                };

                incomingPlacardPresentationView.ConfigureLayout(endFlatSpectrumHandFanNeutralBoxView);

                if (context.UseOpaqueFlatSpectrumItems)
                {
                    startFlatSpectrumHandFanNeutralOpaqueBoxView = new Xamarin.Forms.BoxView
                    {
                        Color = Xamarin.Forms.Color.White.MultiplyAlpha(0.5),
                        WidthRequest = flatSpectrumHandFanBoxViewRequiredWidth,
                        HeightRequest = flatSpectrumHandFanBoxViewRequiredHeight,
                        TranslationX = flatSpectrumHandFanBoxViewRequiredWidth * -1,
                        TranslationY = flatSpectrumHandFanBoxViewRequiredHeight * -1,
                        Rotation = 45 * -1
                    };

                    incomingPlacardPresentationView.ConfigureLayout(startFlatSpectrumHandFanNeutralOpaqueBoxView);
                }

                if (context.UseOpaqueFlatSpectrumItems)
                {
                    endFlatSpectrumHandFanNeutralOpaqueBoxView = new Xamarin.Forms.BoxView
                    {
                        Color = Xamarin.Forms.Color.White.MultiplyAlpha(0.5),
                        WidthRequest = flatSpectrumHandFanBoxViewRequiredWidth,
                        HeightRequest = flatSpectrumHandFanBoxViewRequiredHeight,
                        TranslationX = flatSpectrumHandFanBoxViewRequiredWidth,
                        TranslationY = flatSpectrumHandFanBoxViewRequiredHeight,
                        Rotation = 45 * -1
                    };

                    incomingPlacardPresentationView.ConfigureLayout(endFlatSpectrumHandFanNeutralOpaqueBoxView);
                }
            }

            incomingPlacardPresentationView.PlacardView.IsVisible = false;

            if (context.UseNeutralFlatSpectrumItems)
            {
                incomingPlacardPresentationView.WrapLayout.Children.Add(startFlatSpectrumHandFanNeutralBoxView);
                incomingPlacardPresentationView.WrapLayout.Children.Add(endFlatSpectrumHandFanNeutralBoxView);
            }

            if (context.UseOpaqueFlatSpectrumItems)
            {
                if (context.UseNeutralFlatSpectrumItems)
                {
                    incomingPlacardPresentationView.WrapLayout.Children.Add(startFlatSpectrumHandFanNeutralOpaqueBoxView);
                    incomingPlacardPresentationView.WrapLayout.Children.Add(endFlatSpectrumHandFanNeutralOpaqueBoxView);
                }

                incomingPlacardPresentationView.WrapLayout.Children.Add(startFlatSpectrumHandFanSecoundaryOpaqueBoxView);
                incomingPlacardPresentationView.WrapLayout.Children.Add(endFlatSpectrumHandFanSecoundaryOpaqueBoxView);
                incomingPlacardPresentationView.WrapLayout.Children.Add(startFlatSpectrumHandFanPrimaryOpaqueBoxView);
                incomingPlacardPresentationView.WrapLayout.Children.Add(endFlatSpectrumHandFanPrimaryOpaqueBoxView);
            }

            incomingPlacardPresentationView.WrapLayout.Children.Add(startFlatSpectrumHandFanSecoundaryBoxView);
            incomingPlacardPresentationView.WrapLayout.Children.Add(endFlatSpectrumHandFanSecoundaryBoxView);
            incomingPlacardPresentationView.WrapLayout.Children.Add(startFlatSpectrumHandFanPrimaryBoxView);
            incomingPlacardPresentationView.WrapLayout.Children.Add(endFlatSpectrumHandFanPrimaryBoxView);
        }

        protected override void GarbageCollect()
        {
            if (context.UseOpaqueFlatSpectrumItems)
            {
                if (context.UseNeutralFlatSpectrumItems)
                {
                    incomingPlacardPresentationView.WrapLayout.Children.Remove(startFlatSpectrumHandFanNeutralOpaqueBoxView);
                    incomingPlacardPresentationView.WrapLayout.Children.Remove(endFlatSpectrumHandFanNeutralOpaqueBoxView);
                }

                incomingPlacardPresentationView.WrapLayout.Children.Remove(startFlatSpectrumHandFanSecoundaryOpaqueBoxView);
                incomingPlacardPresentationView.WrapLayout.Children.Remove(endFlatSpectrumHandFanSecoundaryOpaqueBoxView);
                incomingPlacardPresentationView.WrapLayout.Children.Remove(startFlatSpectrumHandFanPrimaryOpaqueBoxView);
                incomingPlacardPresentationView.WrapLayout.Children.Remove(endFlatSpectrumHandFanPrimaryOpaqueBoxView);
            }

            if (context.UseNeutralFlatSpectrumItems)
            {
                incomingPlacardPresentationView.WrapLayout.Children.Remove(startFlatSpectrumHandFanNeutralBoxView);
                incomingPlacardPresentationView.WrapLayout.Children.Remove(endFlatSpectrumHandFanNeutralBoxView);
            }

            incomingPlacardPresentationView.WrapLayout.Children.Remove(startFlatSpectrumHandFanSecoundaryBoxView);
            incomingPlacardPresentationView.WrapLayout.Children.Remove(endFlatSpectrumHandFanSecoundaryBoxView);
            incomingPlacardPresentationView.WrapLayout.Children.Remove(startFlatSpectrumHandFanPrimaryBoxView);
            incomingPlacardPresentationView.WrapLayout.Children.Remove(endFlatSpectrumHandFanPrimaryBoxView);

            startFlatSpectrumHandFanNeutralOpaqueBoxView = null;
            startFlatSpectrumHandFanNeutralBoxView = null;
            startFlatSpectrumHandFanSecoundaryOpaqueBoxView = null;
            startFlatSpectrumHandFanPrimaryOpaqueBoxView = null;
            startFlatSpectrumHandFanSecoundaryBoxView = null;
            startFlatSpectrumHandFanPrimaryBoxView = null;

            endFlatSpectrumHandFanNeutralOpaqueBoxView = null;
            endFlatSpectrumHandFanNeutralBoxView = null;
            endFlatSpectrumHandFanSecoundaryOpaqueBoxView = null;
            endFlatSpectrumHandFanPrimaryOpaqueBoxView = null;
            endFlatSpectrumHandFanSecoundaryBoxView = null;
            endFlatSpectrumHandFanPrimaryBoxView = null;

            factShowInAnimation = null;

            context = null;
        }

        protected override Storyboard CreateShowInMotionStoryboard()
        {
            var storyboard = new Storyboard();

            int flatSpectrumItemCount = 0;

            if (startFlatSpectrumHandFanNeutralOpaqueBoxView != null) storyboard.Animations.Add(CreateAnimationItemStoryboard(startFlatSpectrumHandFanNeutralOpaqueBoxView, 110 * flatSpectrumItemCount++));
            if (endFlatSpectrumHandFanNeutralOpaqueBoxView != null) storyboard.Animations.Add(CreateAnimationItemStoryboard(endFlatSpectrumHandFanNeutralOpaqueBoxView, 110 * flatSpectrumItemCount++));

            if (startFlatSpectrumHandFanSecoundaryOpaqueBoxView != null) storyboard.Animations.Add(CreateAnimationItemStoryboard(startFlatSpectrumHandFanSecoundaryOpaqueBoxView, 110 * flatSpectrumItemCount++));
            if (endFlatSpectrumHandFanSecoundaryOpaqueBoxView != null) storyboard.Animations.Add(CreateAnimationItemStoryboard(endFlatSpectrumHandFanSecoundaryOpaqueBoxView, 110 * flatSpectrumItemCount++));

            if (startFlatSpectrumHandFanPrimaryOpaqueBoxView != null) storyboard.Animations.Add(CreateAnimationItemStoryboard(startFlatSpectrumHandFanPrimaryOpaqueBoxView, 110 * flatSpectrumItemCount++));
            if (endFlatSpectrumHandFanPrimaryOpaqueBoxView != null) storyboard.Animations.Add(CreateAnimationItemStoryboard(startFlatSpectrumHandFanPrimaryOpaqueBoxView, 110 * flatSpectrumItemCount++));

            if (startFlatSpectrumHandFanNeutralBoxView != null) storyboard.Animations.Add(CreateAnimationItemStoryboard(startFlatSpectrumHandFanNeutralBoxView, 110 * flatSpectrumItemCount++));
            if (endFlatSpectrumHandFanNeutralBoxView != null) storyboard.Animations.Add(CreateAnimationItemStoryboard(endFlatSpectrumHandFanNeutralBoxView, 110 * flatSpectrumItemCount++));

            storyboard.Animations.Add(CreateAnimationItemStoryboard(startFlatSpectrumHandFanSecoundaryBoxView, 110 * flatSpectrumItemCount++));
            storyboard.Animations.Add(CreateAnimationItemStoryboard(endFlatSpectrumHandFanSecoundaryBoxView, 110 * flatSpectrumItemCount++));

            var startFlatSpectrumHandFanPrimaryBoxViewShowInAnimation = CreateAnimationItemStoryboard(startFlatSpectrumHandFanPrimaryBoxView, 110 * flatSpectrumItemCount);

            var curtainDownStepAnimation = (startFlatSpectrumHandFanPrimaryBoxViewShowInAnimation as Storyboard).Animations[1];

            curtainDownStepAnimation.Completed += CurtainDownStepAnimation_Completed;

            factShowInAnimation = (startFlatSpectrumHandFanPrimaryBoxViewShowInAnimation as Storyboard).Animations[3];

            storyboard.Animations.Add(startFlatSpectrumHandFanPrimaryBoxViewShowInAnimation);
            storyboard.Animations.Add(CreateAnimationItemStoryboard(endFlatSpectrumHandFanPrimaryBoxView, 110 * flatSpectrumItemCount++));

            return storyboard;
        }

        private Storyboard CreateAnimationItemStoryboard(Xamarin.Forms.VisualElement target, int delayMilisecounds = 0)
        {
            var duration = "250";

            var storyboard = new Storyboard
            {
                IsParallel = true,
                Target = target,
                Delay = delayMilisecounds.ToString()
            };

            storyboard.Animations.Add(new TranslateToAnimation { TranslateX = 0, TranslateY = 0, EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut, Duration = duration });
            storyboard.Animations.Add(new RotateToAnimation { Rotation = 0, EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut, Duration = duration });
            storyboard.Animations.Add(new TranslateToAnimation { TranslateX = target.TranslationX * -1, TranslateY = target.TranslationY * -1, EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn, Duration = duration, Delay = duration });
            storyboard.Animations.Add(new RotateToAnimation { Rotation = target.Rotation * -1, EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut, Duration = duration, Delay = duration });

            return storyboard;
        }

        private void CurtainDownStepAnimation_Completed(object sender, System.EventArgs eventArgs)
        {
            (sender as AbstractAnimation).Completed -= CurtainDownStepAnimation_Completed;

            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                incomingPlacardPresentationView.PlacardView.IsVisible = true;
            });
        }
    }
}
