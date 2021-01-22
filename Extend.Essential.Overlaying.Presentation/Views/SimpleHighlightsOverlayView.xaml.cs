namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Overlaying.Presentation.Views
{
    public partial class SimpleHighlightsOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        public SimpleHighlightsOverlayView(Models.View.SimpleHighlightsViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public override void ShowIn()
        {
            var animation = new XFToolKit.Presentation.Transform.Animations.TranslateToAnimation
            {
                Target = this,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                TranslateY = 0
            };

            animation.Begin();
        }

        public override void ShowOut()
        {
            var animation = new XFToolKit.Presentation.Transform.Animations.TranslateToAnimation
            {
                Target = this,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn,
                TranslateY = 100
            };

            animation.Begin();
        }
    }
}