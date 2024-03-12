using MOROPO.VIDERHE.Extend.UICCamaguey.Overlaying.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.UICCamaguey.Overlaying.Presentation.Views
{
    public partial class TextOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        internal static readonly double MotionTranslation = 108;

        public TextOverlayView(TextOverlayViewModel model)
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
                TranslateY = MotionTranslation
            };

            animation.Begin();
        }
    }
}