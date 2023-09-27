namespace SmartSolucionesCuba.Viderhe.Extend.Hotel.OTT.Overlaying.Presentation.Views
{
    public partial class PionnerOTTHotelTVOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        public PionnerOTTHotelTVOverlayView()
        {
            InitializeComponent();

            Opacity = 0;
        }

        public override void ShowIn()
        {
            var animation = new XFToolKit.Presentation.Transform.Animations.FadeToAnimation
            {
                Target = this,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                Opacity = 1
            };

            animation.Begin();
        }

        public override void ShowOut()
        {
            var animation = new XFToolKit.Presentation.Transform.Animations.FadeToAnimation
            {
                Target = this,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn,
                Opacity = 0
            };

            animation.Begin();
        }
    }
}