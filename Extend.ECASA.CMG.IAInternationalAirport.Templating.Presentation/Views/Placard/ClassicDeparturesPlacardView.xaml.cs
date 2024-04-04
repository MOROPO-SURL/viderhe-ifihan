using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Models.View.Placard;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Views.Background;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Contract;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Views.Placard
{
    public partial class ClassicDeparturesPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView, Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private const double LOGO_IMAGE_VIEW_HEIGHT = 120d;

        private static Thickness TABLE_ITEM_MARGIN = new Thickness(12);

        private static Common.Templating.Presentation.Converters.SizeToRelativeValueConverter SIZE_TO_RELATIVE_VALUE_CONVERTER = new Common.Templating.Presentation.Converters.SizeToRelativeValueConverter();

        private ClassicOperationsPlacardViewModel model;

        private System.DateTime startedAt;

        private Label timeSizeReferenceLabel;
        private Label gateSizeReferenceLabel;

        private View globalBackgroundView;
        private View bannerBackgroundView;

        public ClassicDeparturesPlacardView(ClassicOperationsPlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;

            if (model.HeaderBackground != null)
            {
                HeaderBaseBackgroundBoxView.Opacity = model.HeaderBackgroundOpacity / 100;

                switch (model.HeaderBackground.Kind)
                {
                    case BackgroundKind.Gradient:
                        var gradientModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.GradientContextModel>(model.HeaderBackground.SerializedContext);

                        bannerBackgroundView = new MagicGradients.GradientView
                        {
                            GradientSource = MagicGradients.CssGradientSource.Parse(gradientModel.Data)
                        };

                        break;

                    case BackgroundKind.Image:
                        var imageModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.ImageContextModel>(model.HeaderBackground.SerializedContext).ToViewModel();

                        bannerBackgroundView = new FFImageLoading.Forms.CachedImage
                        {
                            HeightRequest = (double)SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(LOGO_IMAGE_VIEW_HEIGHT + 12 + 32, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture) * RelativeSizeScaleFactor,
                            Source = ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(imageModel.Id)),
                            FadeAnimationEnabled = false,
                            Aspect = Aspect.AspectFill,
                            CacheType = FFImageLoading.Cache.CacheType.Disk,
                            CacheDuration = System.TimeSpan.MaxValue
                        };

                        break;
                }

                HeaderGrid.Children.Insert(0, bannerBackgroundView);
            }

            TableLayout.BackgroundColor = model.TableBackgroundColor;

            TableHeaderGrid.BackgroundColor = model.TableHeaderBackgroundColor;

            if (model.Background != null)
            {
                BackgroundColor = model.TableBackgroundColor;
                
                TableLayout.BackgroundColor = TableLayout.BackgroundColor.MultiplyAlpha((100.0D - model.ForegroundTransparency) / 100);

                var unresponsiveMarginFactor = (Application.Current.MainPage.Width + Application.Current.MainPage.Height) / 2 * 0.04;

                var responsiveMarginFactor = (double)SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(unresponsiveMarginFactor, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture) * RelativeSizeScaleFactor;

                TableLayout.Margin = new Thickness(responsiveMarginFactor);
                TableLayout.IsClippedToBounds = true;

                switch (model.Background.Kind)
                {
                    case BackgroundKind.Gradient:
                        var gradientModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.GradientContextModel>(model.Background.SerializedContext);

                        globalBackgroundView = new MagicGradients.GradientView
                        {
                            GradientSource = MagicGradients.CssGradientSource.Parse(gradientModel.Data)
                        };

                        break;

                    case BackgroundKind.Image:
                        var imageModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.ImageContextModel>(model.Background.SerializedContext).ToViewModel();

                        globalBackgroundView = new FFImageLoading.Forms.CachedImage
                        {
                            Source = ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(imageModel.Id)),
                            FadeAnimationEnabled = false,
                            Aspect = Aspect.AspectFill,
                            CacheType = FFImageLoading.Cache.CacheType.Disk,
                            CacheDuration = System.TimeSpan.MaxValue
                        };

                        break;
                }

                DeparturesLayout.Children.Insert(0, globalBackgroundView);
            }

            var tableHeaderItemFontSize = (double)SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(model.TableHeaderFontSize, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture) * RelativeSizeScaleFactor;

            model.InitializeTableHeader(TableHeaderGrid, Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure, TABLE_ITEM_MARGIN, tableHeaderItemFontSize, out timeSizeReferenceLabel, out gateSizeReferenceLabel);

            this.model = model;

            HeaderBaseBackgroundBoxView.Color = model.HeaderBackgroundColor;

            if (model.IsHideHeaderBuildInInfoRequired)
            {
                OperationSymbolLabel.IsVisible = false;
                HeaderTitleLabel.IsVisible = false;
                HeaderSubTitleLabel.IsVisible = false;
                DateLabel.IsVisible = false;
                TimeLabel.IsVisible = false;
                DateTimeSeparatorBoxView.IsVisible = false;

                LogoBacklightBoxView.Opacity = 0;
                LogoImageView.Opacity = 0;
            }
            else
            {
                OperationSymbolLabel.TextColor = model.HeaderBackgroundColor.ToBlackOrWhiteForText();
                HeaderTitleLabel.TextColor = OperationSymbolLabel.TextColor;
                HeaderSubTitleLabel.TextColor = model.HeaderBackgroundColor.ToBlackOrWhiteForText().WithAlpha(0.85);
                TimeLabel.TextColor = OperationSymbolLabel.TextColor;
                DateLabel.TextColor = OperationSymbolLabel.TextColor;
                DateTimeSeparatorBoxView.Color = OperationSymbolLabel.TextColor;

                LogoBacklightBoxView.Color = model.HeaderBackgroundColor.ToBlackOrWhiteForText();

                LogoImageView.Source = DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>().LogoImageSource;

                LogoImageView.HeightRequest = (double)SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(LOGO_IMAGE_VIEW_HEIGHT, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture) * RelativeSizeScaleFactor;
                LogoImageView.WidthRequest = LogoImageView.HeightRequest;

                if (model.LogoSizeMode == AccountLogoSizeMode.Rectangle19x6)
                {
                    LogoImageView.WidthRequest = LogoImageView.HeightRequest * 1.7777777777777777777777777777778d;
                }
                else if (model.LogoSizeMode == AccountLogoSizeMode.Rectangle4x3)
                {
                    LogoImageView.WidthRequest = LogoImageView.HeightRequest * 1.3333333333333333333333333333333d;
                }

                Device.StartTimer(System.TimeSpan.FromSeconds(15), Timer_Callback);

                Timer_Callback();
            }
        }

        public override Layout<View> WrapLayout => Wrapper;

        public override View PlacardView => DeparturesLayout;

        public override void ConfigureLayout(View view)
        {
            Grid.SetColumn(view, 0);
            Grid.SetRow(view, 0);
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            startedAt = System.DateTime.Now;

            var client = new Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.OperationsAPIConnectClient(this);

            client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
            {
                Kind = Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure
            }).ContinueWith(FetchOperations_Callback);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            if (TableBodyStackLayout.Children.Count > 0)
            {
                foreach (var child in TableBodyStackLayout.Children)
                {
                    if (!(child is Grid)) continue;

                    var operationGrid = child as Grid;

                    foreach (var operationGridChild in operationGrid.Children)
                    {
                        if (!(operationGridChild is StackLayout)) continue;

                        var boxedCachedImage = (operationGridChild as StackLayout).Children[0] as BoxedCachedImage;

                        boxedCachedImage.Source = null;
                    }
                }
            }

            if (globalBackgroundView != null)
            {
                if (globalBackgroundView is ImageBackgroundView)
                {
                    (globalBackgroundView as ImageBackgroundView).Source = null;
                }
                else if (globalBackgroundView is GradientBackgroundView)
                {
                    (globalBackgroundView as GradientBackgroundView).GradientSource = null;
                }

                globalBackgroundView = null;
            }

            if (bannerBackgroundView != null)
            {
                if (bannerBackgroundView is ImageBackgroundView)
                {
                    (bannerBackgroundView as ImageBackgroundView).Source = null;
                }
                else if (bannerBackgroundView is GradientBackgroundView)
                {
                    (bannerBackgroundView as GradientBackgroundView).GradientSource = null;
                }

                bannerBackgroundView = null;
            }

            LogoImageView.Source = null;

            timeSizeReferenceLabel = null;

            model.Items.Clear();

            model = null;
        }

        private void TableBodyStackLayout_ChildRemoved(object sender, ElementEventArgs eventArgs)
        {
            var operationGrid = eventArgs.Element as Grid;

            foreach (var child in operationGrid.Children)
            {
                if (!(child is StackLayout)) continue;

                var boxedCachedImage = (child as StackLayout).Children[0] as BoxedCachedImage;

                boxedCachedImage.Source = null;
            }
        }

        private void OutgoingRowAnimation_Completed(object sender, System.EventArgs eventArgs)
        {
            var animation = sender as AbstractAnimation;

            animation.Completed -= OutgoingRowAnimation_Completed;

            Device.BeginInvokeOnMainThread(() =>
            {
                TableBodyStackLayout.Children.Remove(animation.Target as View);
            });
        }

        private void FetchOperations_Callback(System.Threading.Tasks.Task<Service.ECASA.CMG.InterFIDS.API.Common.Models.OperationDisplayModel[]> task)
        {
            if (BindingContext == null) return;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            var tableBodyStackLayoutChildrenCount = TableBodyStackLayout.Children.Count;

            if (!task.IsCanceled && task.Exception == null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (tableBodyStackLayoutChildrenCount <= 0) return;

                    var startIndex = tableBodyStackLayoutChildrenCount - 1;
                    var iterationIndex = 0;

                    var outgoingRowsStoryboard = new Storyboard { IsParallel = true };

                    for (int i = startIndex; i >= 0; i--)
                    {
                        var outgoingRowAnimation = new TranslateToXAnimation
                        {
                            Target = TableBodyStackLayout.Children[i],
                            Duration = "360",
                            Delay = (120 * iterationIndex++).ToString(),
                            EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut
                        };

                        outgoingRowAnimation.TranslateX = outgoingRowAnimation.Target.Width;

                        outgoingRowAnimation.Completed += OutgoingRowAnimation_Completed;

                        outgoingRowsStoryboard.Animations.Add(outgoingRowAnimation);
                    }

                    outgoingRowsStoryboard.Begin();
                });

                if (tableBodyStackLayoutChildrenCount > 0) System.Threading.Thread.Sleep(System.TimeSpan.FromMilliseconds(120 * tableBodyStackLayoutChildrenCount + 120));

                var tableBodyItemFontSize = (double)SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(model.RowFontSize, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture) * RelativeSizeScaleFactor;

                var index = 0;

                foreach (var item in task.Result)
                {
                    System.Threading.Thread.Sleep(System.TimeSpan.FromMilliseconds(250));

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        item.AttachTo(index++, TableBodyStackLayout, TableHeaderGrid.ColumnDefinitions, model, TABLE_ITEM_MARGIN, tableBodyItemFontSize, timeSizeReferenceLabel?.Width ?? 0, gateSizeReferenceLabel?.Width ?? 0);
                    });
                }
            }

            stopwatch.Stop();

            var client = new Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.OperationsAPIConnectClient(this);

            var delay = System.TimeSpan.FromSeconds(model.UpdateInterval) - stopwatch.Elapsed;

            if (model.ScreenPresentationTime > System.TimeSpan.Zero && model.ScreenPresentationTime <= (System.DateTime.Now - startedAt + delay + System.TimeSpan.FromSeconds(5))) return;

            if (delay <= System.TimeSpan.Zero)
            {
                client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
                {
                    Kind = Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure
                }).ContinueWith(FetchOperations_Callback);
            }
            else
            {
                System.Threading.Tasks.Task.Delay(delay).ContinueWith(delayTask =>
                {
                    client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
                    {
                        Kind = Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure
                    }).ContinueWith(FetchOperations_Callback);
                });
            }
        }

        private bool Timer_Callback()
        {
            var now = System.DateTime.Now;

            DateLabel.Text = now.ToString("MMM dd").ToUpperInvariant();

            TimeLabel.Text = now.ToString("HH:mm");

            return model != null;
        }

        #region IHttpClientHelperProviderFacade implementation

        public Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper
        {
            get
            {
                if (BindingContext == null) throw new System.InvalidOperationException();

                if (model.UseSSL && model.AllowAnyCertificate)
                {
                    return new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(
                        new System.Net.Http.HttpClientHandler
                        {
                            ServerCertificateCustomValidationCallback = (request, certificate, chain, errors) => true
                        },
                        string.Format("https://{0}/api/", model.APIServer),
                        null,
                        () => { return new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(Service.ECASA.CMG.InterFIDS.API.Common.Constants.Authentication.API_KEY_HEADER_PROPERTY, model.APIKey) }; }); ;
                }

                return new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(
                    string.Format("{0}://{1}/api/", model.UseSSL ? "https" : "http", model.APIServer),
                    null,
                    () => { return new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(Service.ECASA.CMG.InterFIDS.API.Common.Constants.Authentication.API_KEY_HEADER_PROPERTY, model.APIKey) }; });
            }
        }

        #endregion
    }
}