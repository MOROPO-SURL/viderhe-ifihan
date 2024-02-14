namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Views
{
    public partial class AuroraOTTHotelTVOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        public AuroraOTTHotelTVOverlayView(Models.View.AuroraOTTHotelTVOverlayViewModel model)
        {
            InitializeComponent();

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

        private void ActionsCollectionView_SelectionChanged(object sender, Xamarin.Forms.SelectionChangedEventArgs eventArgs)
        {

        }
    }
}