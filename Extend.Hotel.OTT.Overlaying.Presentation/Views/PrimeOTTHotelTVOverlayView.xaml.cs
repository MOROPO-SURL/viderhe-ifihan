using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Views
{
    public partial class PrimeOTTHotelTVOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        public PrimeOTTHotelTVOverlayView(Models.View.PrimeOTTHotelTVOverlayViewModel model)
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
            Xamarin.Forms.Application.Current.MainPage.NavigationPushModalPageAsync(new Pages.BrandChannelPage(((Models.View.PrimeOTTHotelTVOverlayViewModel)BindingContext).Context, SectionPresentationCompleted_Callback));
        }

        private void TelevisionButton_Clicked(object sender, System.EventArgs e)
        {
            IsEnabled = false;

            Providers.TelevisionChannelProvider.Instance.UpdateAsync().ContinueWith(task => Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                LinkedListNode<HIPS.Web.API.Common.Models.TelevisionChannelDisplayModel> lastChannelNode = null;

                if (Xamarin.Forms.Application.Current.Properties.ContainsKey(Constants.LAST_CHANNEL_ID_KEY))
                {
                    var lastChannelId = System.Guid.Parse(Xamarin.Forms.Application.Current.Properties[Constants.LAST_CHANNEL_ID_KEY].ToString());

                    var lastChannel = Providers.TelevisionChannelProvider.Instance.Channels.FirstOrDefault(_item => _item.Id == lastChannelId);

                    lastChannelNode = Providers.TelevisionChannelProvider.Instance.Channels.Find(lastChannel);
                }

                Xamarin.Forms.Application.Current.MainPage.NavigationPushModalPageAsync(new Pages.TelevisionWatchPage(lastChannelNode, SectionPresentationCompleted_Callback));
            }));
        }

        private void SectionPresentationCompleted_Callback()
        {
            IsEnabled = true;
        }
    }
}