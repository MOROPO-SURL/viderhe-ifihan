using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Views
{
    public partial class AuroraOTTHotelTVOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        public AuroraOTTHotelTVOverlayView(Models.View.AuroraOTTHotelTVOverlayViewModel model)
        {
            InitializeComponent();

            BrandLogoImageView.Source = FFImageLoading.Svg.Forms.SvgImageSource.FromResource("MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Assets.Image.bluediamond-header-logo.svg", GetType().Assembly);

            BindingContext = model;
        }

        public override void ShowIn()
        {
            var animation = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeToAnimation
            {
                Target = this,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                Opacity = 1
            };

            animation.Begin();
        }

        public override void ShowOut()
        {
            var animation = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeToAnimation
            {
                Target = this,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn,
                Opacity = 0
            };

            animation.Begin();
        }

        private void Button_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            var parent = ((Xamarin.Forms.Button)sender).Parent as Xamarin.Forms.Grid;

            parent.Scale = 1.025;
            parent.BackgroundColor = Xamarin.Forms.Color.DarkBlue;
        }

        private void Button_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            var parent = ((Xamarin.Forms.Button)sender).Parent as Xamarin.Forms.Grid;

            parent.Scale = 1.0;
            parent.BackgroundColor = Xamarin.Forms.Color.FromHex("#DF000000");
        }

        private void BrandChannelButton_Clicked(object sender, System.EventArgs e)
        {
            Xamarin.Forms.Application.Current.MainPage.NavigationPushModalPageAsync(new Pages.BrandChannelPage(((Models.View.AuroraOTTHotelTVOverlayViewModel)BindingContext).Context, null));
        }
    }
}