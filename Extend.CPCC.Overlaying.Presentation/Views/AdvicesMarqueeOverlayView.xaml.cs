namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Presentation.Views
{
    public partial class AdvicesMarqueeOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        internal static readonly double MOTION_TRANSLATION = 80;

        public AdvicesMarqueeOverlayView(Models.Context.AdvicesMarqueeOverlayContextModel model)
        {
            InitializeComponent();

            BindingContext = new Models.View.AdvicesMarqueeOverlayViewModel();

            System.Threading.Tasks.Task.Run(() =>
            {
                return SAPRESSC.Business.Billboard.CPCC.Web.Api.Client.AdvisesApiClient.Get(new System.Uri(string.Format("{0}://{1}", model.IsSecureServer ? "https" : "http", model.ServerName)));
            }).ContinueWith(task =>
            {
                if (task.Exception != null || task.IsCanceled || task.Result == null)
                {
                    (BindingContext as Models.View.AdvicesMarqueeOverlayViewModel).InLineAdvices = "Dirección del servidor no válida o servicio no disponible ...";

                    return;
                }

                var formattedSeparator = string.Format(" {0} ", model.AdviseSeparator);

                var textBuilder = new System.Text.StringBuilder();

                if (!string.IsNullOrEmpty(model.Head) && !string.IsNullOrWhiteSpace(model.Head))
                {
                    textBuilder.Append(model.Head);

                    textBuilder.Append(formattedSeparator);
                }

                textBuilder.Append(string.Join(model.AdviseSeparator, task.Result));

                if (!string.IsNullOrEmpty(model.Tail) && !string.IsNullOrWhiteSpace(model.Tail))
                {
                    textBuilder.Append(formattedSeparator);

                    textBuilder.Append(model.Tail);
                }

                (BindingContext as Models.View.AdvicesMarqueeOverlayViewModel).InLineAdvices = textBuilder.ToString();
            });
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
                TranslateY = MOTION_TRANSLATION
            };

            animation.Begin();
        }
    }
}