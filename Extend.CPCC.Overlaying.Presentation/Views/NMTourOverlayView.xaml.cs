namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Presentation.Views
{
    public partial class NMTourOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        internal static readonly double INLINEADVICES_LAYOUT_MOTION_TRANSLATION = 80;

        private readonly Models.Context.NMTourOverlayContextModel model;

        //private XFToolKit.Presentation.Transform.Animations.HeartAnimation screenInteractionSuggestLabelAnimation;

        public NMTourOverlayView(Models.Context.NMTourOverlayContextModel model)
        {
            this.model = model;

            InitializeComponent();

            IsEnabled = false;

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

        //private void ScreenInteractionSuggestLabelAnimation_Completed(object sender, System.EventArgs eventArgs)
        //{
        //    if (!IsEnabled) return;

        //    System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(10)).ContinueWith(_ =>
        //    {
        //        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
        //        {
        //            InterationIndicationLayout.Scale = 1;

        //            screenInteractionSuggestLabelAnimation?.Begin();
        //        });
        //    });
        //}

        private void ShowInAnimation_Completed(object sender, System.EventArgs e)
        {
            (sender as XFToolKit.Presentation.Transform.Animations.AbstractAnimation).Completed -= ShowInAnimation_Completed;

            //Xamarin.Forms.Device.BeginInvokeOnMainThread(EnableInteractionEmplasisAnimation);

            IsEnabled = true;
        }

        private void OverlayViewTapGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            //DisableInteractionEmplasisAnimation();

            var animation = new XFToolKit.Presentation.Transform.Animations.FadeToAnimation
            {
                Target = InterationIndicationLayout,
                Opacity = 0,
                Duration = "100"
            };

            animation.Begin();

            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Pages.PopUp.NMTourPopUpPage(InteractivePresentationComplete_Callback));
        }

        private void InteractivePresentationComplete_Callback()
        {
            var animation = new XFToolKit.Presentation.Transform.Animations.FadeToAnimation
            {
                Target = InterationIndicationLayout,
                Opacity = 1,
                Duration = "180"
            };

            animation.Completed += ShowInAnimation_Completed;

            animation.Begin();
        }

        public override void ShowIn()
        {
            var animation = new XFToolKit.Presentation.Transform.Animations.TranslateToAnimation
            {
                Target = InLineAdvicesLayout,
                EasingType = XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                TranslateY = 0
            };

            animation.Completed += ShowInAnimation_Completed;

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

        //private void EnableInteractionEmplasisAnimation()
        //{
        //    IsEnabled = true;

        //    InterationIndicationLayout.Scale = 1;

        //    screenInteractionSuggestLabelAnimation = new XFToolKit.Presentation.Transform.Animations.HeartAnimation
        //    {
        //        Target = InterationIndicationLayout
        //    };

        //    screenInteractionSuggestLabelAnimation.Completed += ScreenInteractionSuggestLabelAnimation_Completed;

        //    screenInteractionSuggestLabelAnimation.Begin();
        //}

        //private void DisableInteractionEmplasisAnimation()
        //{
        //    IsEnabled = false;

        //    if (screenInteractionSuggestLabelAnimation == null) return;

        //    screenInteractionSuggestLabelAnimation.Completed -= ScreenInteractionSuggestLabelAnimation_Completed;
        //    screenInteractionSuggestLabelAnimation = null;
        //}
    }
}