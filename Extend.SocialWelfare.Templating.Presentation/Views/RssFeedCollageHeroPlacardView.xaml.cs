using SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Views
{
    public partial class RssFeedCollageHeroPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private Models.Context.RssFeedCollageHeroContextModel placardContext;

        public RssFeedCollageHeroPlacardView(Models.Context.RssFeedCollageHeroContextModel model)
        {
            InitializeComponent();

            placardContext = model;

            BindingContext = new Models.View.RssFeedCollageHeroPlacardViewModel
            {
                ScreenPresentationTime = model.ScreenPresentationTime,
                RequireUnobstructedPresetation = model.RequireUnobstructedPresetation,
                IsBusy = true,
                TintColor = Xamarin.Forms.Color.FromHex(model.TintColor)
            };

            IsEnabled = false;
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

            var concreteBindingContextModel = BindingContext as Models.View.RssFeedCollageHeroPlacardViewModel;

            CodeHollow.FeedReader.FeedReader.ReadAsync(placardContext.FeedUrl).ContinueWith(task =>
            {
                if (task.IsCanceled || task.Exception != null || task.Result.Items.Count <= 0)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        EndPresentation();
                    });

                    return;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    concreteBindingContextModel.FeedTitle = task.Result.Title;
                    concreteBindingContextModel.FeedDescription = task.Result.Description;
                    concreteBindingContextModel.FeedLastUpdatedDateString = task.Result.LastUpdatedDateString;
                    concreteBindingContextModel.FeedImageSource = task.Result.ImageUrl == null ? null : Xamarin.Forms.ImageSource.FromUri(new System.Uri(task.Result.ImageUrl));

                    concreteBindingContextModel.HeroFeedItem = task.Result.Items.ElementAt(0).ToRssFeedItemViewModel();

                    if (task.Result.Items.Count > 1)
                    {
                        concreteBindingContextModel.SecoundFeedItem = task.Result.Items.ElementAt(1).ToRssFeedItemViewModel();

                        if (task.Result.Items.Count > 2)
                        {
                            concreteBindingContextModel.ThirdFeedItem = task.Result.Items.ElementAt(2).ToRssFeedItemViewModel();

                            if (task.Result.Items.Count > 3)
                            {
                                concreteBindingContextModel.FourthFeedItem = task.Result.Items.ElementAt(3).ToRssFeedItemViewModel();
                            }
                        }
                    }

                    concreteBindingContextModel.IsBusy = false;

                    var infoShowInStoryboard = new XFToolKit.Presentation.Transform.Animations.Storyboard
                    {
                        IsParallel = true
                    };

                    infoShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToYAnimation
                    {
                        Target = HeadLayout,
                        TranslateY = 0,
                        EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Duration = "700"
                    });
                    infoShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = HeroFeedItemLayout,
                        TranslateX = 0,
                        EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Delay = "500"
                    });
                    infoShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = SecoundFeedItemLayout,
                        TranslateX = 0,
                        EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Delay = "900"
                    });
                    infoShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = ThirdFeedItemLayout,
                        TranslateX = 0,
                        EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Delay = "1100"
                    });
                    infoShowInStoryboard.Animations.Add(new XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = FourthFeedItemLayout,
                        TranslateX = 0,
                        EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Delay = "1300"
                    });

                    infoShowInStoryboard.Begin();
                });
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            placardContext = null;

            var concreteBindingContextModel = BindingContext as Models.View.RssFeedCollageHeroPlacardViewModel;

            concreteBindingContextModel.FeedImageSource = null;
            concreteBindingContextModel.HeroFeedItem = null;
            concreteBindingContextModel.SecoundFeedItem = null;
            concreteBindingContextModel.ThirdFeedItem = null;
            concreteBindingContextModel.FourthFeedItem = null;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (IsEnabled || width == -1 || height == -1) return;

            IsEnabled = true;

            HeadLayout.TranslationY = HeadLayout.Height * -1;

            HeroFeedItemLayout.TranslationX = HeroFeedItemLayout.Width * -1;

            SecoundFeedItemLayout.TranslationX = SecoundFeedItemLayout.Width;
            
            ThirdFeedItemLayout.TranslationX = ThirdFeedItemLayout.Width;
            
            FourthFeedItemLayout.TranslationX = FourthFeedItemLayout.Width;
        }
    }
}