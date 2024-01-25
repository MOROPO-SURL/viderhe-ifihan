using MOROPO.VIDERHE.Extend.Essential.Overlaying.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Essential.Overlaying.Presentation.Views
{
    public partial class SimpleHighlightsOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        public SimpleHighlightsOverlayView(SimpleHighlightsViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public override void ShowIn()
        {
            var animation = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToAnimation
            {
                Target = this,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                TranslateY = 0
            };

            animation.Begin();
        }

        public override void ShowOut()
        {
            var animation = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToAnimation
            {
                Target = this,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn,
                TranslateY = 100
            };

            animation.Begin();
        }
    }
}