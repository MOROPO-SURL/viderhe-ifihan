namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Presentation.Views
{
    public partial class NMTourOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        internal static readonly double INLINEADVICES_LAYOUT_MOTION_TRANSLATION = 80;

        private readonly Models.Context.NMTourOverlayContextModel model;

        public NMTourOverlayView(Models.Context.NMTourOverlayContextModel model)
        {
            this.model = model;

            InitializeComponent();

            BindingContext = new Models.View.NMTourOverlayViewModel();

            UpdateInLineAdvises(model.FailbackMessage);

            System.Threading.Tasks.Task.Run(() =>
            {
                return SAPRESSC.Business.Billboard.CPCC.Web.Api.Client.AdvisesApiClient.Get(new System.Uri(string.Format("{0}://{1}", model.IsSecureServer ? "https" : "http", model.ServerName)));
            }).ContinueWith(task =>
            {
                if (task.Exception != null || task.IsCanceled || task.Result == null) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    UpdateInLineAdvises(string.Join(string.Format(" {0} ", model.Separator), task.Result));
                });
            });
        }

        private void OverlayViewTapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Pages.PopUp.NMTourPopUpPage());
        }

        public override void ShowIn()
        {
            var animation = new XFToolKit.Presentation.Transform.Animations.TranslateToAnimation
            {
                Target = InLineAdvicesLayout,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                TranslateY = 0
            };

            animation.Begin();
        }

        public override void ShowOut()
        {
            var animation = new XFToolKit.Presentation.Transform.Animations.TranslateToAnimation
            {
                Target = InLineAdvicesLayout,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn,
                TranslateY = INLINEADVICES_LAYOUT_MOTION_TRANSLATION
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

            (BindingContext as Models.View.AdvicesMarqueeOverlayViewModel).InLineAdvices = textBuilder.ToString();
        }
    }
}