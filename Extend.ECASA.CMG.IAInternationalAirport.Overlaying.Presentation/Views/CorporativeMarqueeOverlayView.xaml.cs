using System.Linq;
using Xamarin.CommunityToolkit.Extensions;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Presentation.Views
{
    public partial class CorporativeMarqueeOverlayView : Common.Overlaying.Presentation.Views.BaseOverlayView
    {
        private Models.Context.CorporativeMarqueeOverlayContextModel model;

        public CorporativeMarqueeOverlayView(Models.Context.CorporativeMarqueeOverlayContextModel model)
        {
            this.model = model;

            InitializeComponent();

            BindingContext = new Models.View.CorporativeMarqueeOverlayViewModel
            {
                Context = model
            };

            var referenceSize = System.Math.Max(Xamarin.Forms.Application.Current.MainPage.Width, Xamarin.Forms.Application.Current.MainPage.Height);

            LogoImageView.Source = Xamarin.Forms.DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>().LogoImageSource;

            LogoGrid.WidthRequest = referenceSize * 1 / 10;
            LogoGrid.HeightRequest = LogoGrid.WidthRequest;

            if (model.LogoSizeMode == Enumerations.MarqueeLogoSizeMode.Rectangle19x6)
            {
                LogoGrid.WidthRequest = referenceSize * 1.7777777777777777777777777777778d / 10 * 0.75;
                LogoGrid.HeightRequest = LogoGrid.WidthRequest / 1.7777777777777777777777777777778d;
            }
            else if (model.LogoSizeMode == Enumerations.MarqueeLogoSizeMode.Rectangle4x3)
            {
                LogoGrid.WidthRequest = referenceSize * 1.3333333333333333333333333333333d / 10 * 0.87;
                LogoGrid.HeightRequest = LogoGrid.WidthRequest / 1.3333333333333333333333333333333d;
            }

            TranslationY = LogoGrid.HeightRequest;

            if (model.InformationSourceKind == Enumerations.CorporativeInformationSourceKind.Managed)
            {
                UpdateMarqueeContent(model.InformationSource);
            }
            else
            {
                CodeHollow.FeedReader.FeedReader.ReadAsync(model.InformationSource).ContinueWith(task =>
                {
                    if (task.IsCanceled || task.Exception != null || task.Result.Items.Count <= 0)
                    {
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() => UpdateMarqueeContent(model.FailbackMessage));

                        return;
                    }

                    var formattedSeparator = string.Format(" {0} ", model.Separator);

                    var textBuilder = new System.Text.StringBuilder();

                    var list = task.Result.Items.Take(10).ToArray();

                    foreach (var item in list)
                    {
                        if (textBuilder.Length > 0)
                        {
                            textBuilder.Append(formattedSeparator);
                        }

                        textBuilder.Append(item.Title);
                    }

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        UpdateMarqueeContent(textBuilder.ToString());
                    });
                });
            }

            if (model.IsDateTimePresentationRequired)
            {
                DateIconLabel.TextColor = DateLabel.TextColor = TimeIconLabel.TextColor = TimeLabel.TextColor = Xamarin.Forms.Color.FromHex(model.FrontierColor).ToBlackOrWhiteForText();

                Xamarin.Forms.Device.StartTimer(System.TimeSpan.FromSeconds(15), Timer_Callback);

                Timer_Callback();
            }
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            model = null;
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
                TranslateY = LogoGrid.HeightRequest
            };

            animation.Begin();
        }

        private bool Timer_Callback()
        {
            var now = System.DateTime.Now;

            DateLabel.Text = now.ToString("dddd dd, MMMM, yyyy");

            TimeLabel.Text = now.ToString("HH:mm");

            return model != null;
        }

        private void UpdateMarqueeContent(string body)
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

            (BindingContext as Models.View.CorporativeMarqueeOverlayViewModel).MarqueeContent = textBuilder.ToString();
        }
    }
}