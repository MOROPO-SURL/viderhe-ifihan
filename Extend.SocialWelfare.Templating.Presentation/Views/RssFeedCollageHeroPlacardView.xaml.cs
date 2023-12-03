using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Models.Context.Placard;
using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Presentation.Models.View.Placard;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Presentation.Views
{
    public partial class RssFeedCollageHeroPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private RssFeedCollageHeroPlacardContextModel placardContext;

        public RssFeedCollageHeroPlacardView(RssFeedCollageHeroPlacardContextModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            placardContext = model;

            BindingContext = new RssFeedCollageHeroPlacardViewModel
            {
                ScreenPresentationTime = model.ScreenPresentationTime,
                RequireUnobstructedPresetation = model.RequireUnobstructedPresetation,
                //IsBusy = true,
                TintColor = Xamarin.Forms.Color.FromHex(model.TintColor)
            };

            IsEnabled = false;

            HeroFeedItemTintFlatBoxView.Color = Xamarin.Forms.Color.FromHex(model.TintColor);
            SecoundFeedItemTintFlatBoxView.Color = HeroFeedItemTintFlatBoxView.Color;
            ThirdFeedItemTintFlatBoxView.Color = HeroFeedItemTintFlatBoxView.Color;
            FourthFeedItemTintFlatBoxView.Color = HeroFeedItemTintFlatBoxView.Color;
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

            var concreteBindingContextModel = BindingContext as RssFeedCollageHeroPlacardViewModel;

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

                while (!IsEnabled) System.Threading.Thread.Sleep(250);

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

                    //concreteBindingContextModel.IsBusy = false;

                    var infoShowInStoryboard = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Storyboard
                    {
                        IsParallel = true
                    };

                    infoShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToYAnimation
                    {
                        Target = HeadLayout,
                        TranslateY = 0,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Duration = "600"
                    });

                    infoShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = HeroFeedItemLightFlatBoxView,
                        TranslateX = HeroFeedItemLightFlatBoxView.Width,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Duration = "700",
                        Delay = "300"
                    });
                    infoShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = HeroFeedItemTintFlatBoxView,
                        TranslateX = HeroFeedItemTintFlatBoxView.Width,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Duration = "1000",
                        Delay = "500"
                    });
                    infoShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = HeroFeedItemLayout,
                        TranslateX = 0,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Duration = "1000",
                        Delay = "500"
                    });

                    infoShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = SecoundFeedItemLightFlatBoxView,
                        TranslateX = SecoundFeedItemLightFlatBoxView.Width * -1,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Duration = "700",
                        Delay = "600"
                    });
                    infoShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = SecoundFeedItemTintFlatBoxView,
                        TranslateX = SecoundFeedItemTintFlatBoxView.Width * -1,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Duration = "1000",
                        Delay = "800"
                    });
                    infoShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = SecoundFeedItemLayout,
                        TranslateX = 0,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Duration = "1000",
                        Delay = "800"
                    });

                    infoShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = ThirdFeedItemTintFlatBoxView,
                        TranslateX = ThirdFeedItemLightFlatBoxView.Width * -1,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Duration = "700",
                        Delay = "800"
                    });
                    infoShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = ThirdFeedItemTintFlatBoxView,
                        TranslateX = ThirdFeedItemTintFlatBoxView.Width * -1,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Duration = "1000",
                        Delay = "1000"
                    });
                    infoShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = ThirdFeedItemLayout,
                        TranslateX = 0,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Duration = "1000",
                        Delay = "1000"
                    });

                    infoShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = FourthFeedItemLightFlatBoxView,
                        TranslateX = FourthFeedItemLightFlatBoxView.Width * -1,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Duration = "700",
                        Delay = "800"
                    });
                    infoShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = FourthFeedItemTintFlatBoxView,
                        TranslateX = FourthFeedItemTintFlatBoxView.Width * -1,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Duration = "1000",
                        Delay = "1000"
                    });
                    infoShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
                    {
                        Target = FourthFeedItemLayout,
                        TranslateX = 0,
                        EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                        Duration = "1000",
                        Delay = "1000"
                    });

                    infoShowInStoryboard.Begin();
                });
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            placardContext = null;

            var concreteBindingContextModel = BindingContext as RssFeedCollageHeroPlacardViewModel;

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

            HeroFeedItemLightFlatBoxView.TranslationX = HeroFeedItemLightFlatBoxView.Width * -1;
            HeroFeedItemTintFlatBoxView.TranslationX = HeroFeedItemTintFlatBoxView.Width * -1;
            HeroFeedItemLayout.TranslationX = HeroFeedItemLayout.Width * -1;

            SecoundFeedItemLightFlatBoxView.TranslationX = SecoundFeedItemLightFlatBoxView.Width;
            SecoundFeedItemTintFlatBoxView.TranslationX = SecoundFeedItemTintFlatBoxView.Width;
            SecoundFeedItemLayout.TranslationX = SecoundFeedItemLayout.Width;

            ThirdFeedItemLightFlatBoxView.TranslationX = ThirdFeedItemLightFlatBoxView.Width;
            ThirdFeedItemTintFlatBoxView.TranslationX = ThirdFeedItemTintFlatBoxView.Width;
            ThirdFeedItemLayout.TranslationX = ThirdFeedItemLayout.Width;

            FourthFeedItemLightFlatBoxView.TranslationX = FourthFeedItemLightFlatBoxView.Width;
            FourthFeedItemTintFlatBoxView.TranslationX = FourthFeedItemTintFlatBoxView.Width;
            FourthFeedItemLayout.TranslationX = FourthFeedItemLayout.Width;
        }
    }
}