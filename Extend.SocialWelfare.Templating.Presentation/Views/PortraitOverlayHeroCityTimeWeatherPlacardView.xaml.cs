using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Presentation.Models.View.Placard;
using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Presentation.Views.Background;

namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Presentation.Views
{
    public partial class PortraitOverlayHeroCityTimeWeatherPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public PortraitOverlayHeroCityTimeWeatherPlacardView(OverlayHeroCityTimeWeatherPlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            if (model.OverlayColor != null)
            {
                OverlayBoxView.Color = model.OverlayColor.Value;
                OverlayBoxView.Opacity = 0;
            }

            BindingContext = model;

            TimeLabel.Text = model.Now.ToString("hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);

            CityLabel.Opacity = 0;
            DateLabel.Opacity = 0;
            TimeLabel.Opacity = 0;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => PlacardLayout;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        public async override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var concreteBindingContextModel = BindingContext as OverlayHeroCityTimeWeatherPlacardViewModel;

            var weatherApiConnectClient = new Service.Weather.Api.Connect.Clients.OpenWeatherMapApiConnectClient(new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(concreteBindingContextModel.ServiceBaseUri.ToString()));

            var weatherApiConnectStartAt = System.DateTime.Now;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            weatherApiConnectClient.GetOverviewByCityAsync(int.Parse(concreteBindingContextModel.City.Id)).ContinueWith(task =>
            {
                if (task.IsCanceled || task.Exception != null)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        EndPresentation();
                    });

                    return;
                }

                var weatherApiConnectElapsedTime = System.DateTime.Now - weatherApiConnectStartAt;

                var weitTime = System.TimeSpan.FromSeconds(3) - weatherApiConnectElapsedTime;

                if (weitTime > System.TimeSpan.Zero) System.Threading.Thread.Sleep(weitTime);

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    WeatherLayout.Opacity = 0;

                    concreteBindingContextModel.WeatherOverview = task.Result;

                    var weatherInfoShowInStoryboard = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Storyboard
                    {
                        IsParallel = true
                    };

                    weatherInfoShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeInAnimation
                    {
                        Target = WeatherLayout,
                        Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Up
                    });

                    concreteBindingContextModel.IsBusy = false;

                    weatherInfoShowInStoryboard.Begin();
                });
            });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            var globalShowInStoryboard = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                IsParallel = true,
                Delay = "1000"
            };

            globalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeToAnimation
            {
                Target = OverlayBoxView,
                Opacity = 1
            });
            globalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeInAnimation
            {
                Target = CityLabel,
                Delay = "800",
                Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down
            });
            globalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeInAnimation
            {
                Target = DateLabel,
                Delay = "1200",
                Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down
            });
            globalShowInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeInAnimation
            {
                Target = TimeLabel,
                Delay = "1500",
                Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Up
            });

            await globalShowInStoryboard.Begin();

            if (concreteBindingContextModel.WeatherOverview != null) return;

            concreteBindingContextModel.IsBusy = true;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            if (BackgroundContentView.Content is ImageBackgroundView)
            {
                (BackgroundContentView.Content as ImageBackgroundView).Source = null;
            }
            else if (BackgroundContentView.Content is GradientBackgroundView)
            {
                (BackgroundContentView.Content as GradientBackgroundView).GradientSource = null;
            }
        }
    }
}