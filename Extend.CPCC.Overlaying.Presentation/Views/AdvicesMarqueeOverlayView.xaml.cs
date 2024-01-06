using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Models.Context;
using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Views
{
    public partial class AdvicesMarqueeOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        internal static readonly double MOTION_TRANSLATION = 80;

        private readonly AdvicesMarqueeOverlayContextModel model;

        public AdvicesMarqueeOverlayView(AdvicesMarqueeOverlayContextModel model)
        {
            this.model = model;

            InitializeComponent();

            BindingContext = new Models.View.AdvicesMarqueeOverlayViewModel();

            UpdateInLineAdvises(model.FailbackMessage);

            System.Threading.Tasks.Task.Run(() =>
            {
                return SmartSolucionesCuba.SAPRESSC.Business.Billboard.CPCC.Web.Api.Client.AdvisesApiClient.Get(new System.Uri(string.Format("{0}://{1}", model.IsSecureServer ? "https" : "http", model.ServerName)));
            }).ContinueWith(task =>
            {
                if (task.Exception != null || task.IsCanceled || task.Result == null) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => 
                {
                    UpdateInLineAdvises(string.Join(string.Format(" {0} ", model.Separator), task.Result));
                });
            });
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
                TranslateY = MOTION_TRANSLATION
            };

            animation.Begin();
        }

        private void UpdateInLineAdvises(string body)
        {
            var formattedSeparator = string.Format(" {0} ", model.Separator);

            var textBuilder = new System.Text.StringBuilder();

            if (!string.IsNullOrEmpty(model.Head) && !string.IsNullOrWhiteSpace(model.Head))
            {
                textBuilder.Append(model.Head);

                textBuilder.Append(formattedSeparator);
            }

            textBuilder.Append(body);

            if (!string.IsNullOrEmpty(model.Tail) && !string.IsNullOrWhiteSpace(model.Tail))
            {
                textBuilder.Append(formattedSeparator);

                textBuilder.Append(model.Tail);
            }

            (BindingContext as AdvicesMarqueeOverlayViewModel).InLineAdvices = textBuilder.ToString();
        }
    }
}