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
    public partial class ClassicDualOperationsPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView, Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private const double LOGO_IMAGE_VIEW_HEIGHT = 160d;

        private static Thickness TABLE_ITEM_MARGIN = new Thickness(12);

        private static Common.Templating.Presentation.Converters.SizeToRelativeValueConverter SIZE_TO_RELATIVE_VALUE_CONVERTER = new Common.Templating.Presentation.Converters.SizeToRelativeValueConverter();

        private ClassicOperationsDualPlacardViewModel model;

        private System.DateTime startedAt;

        private Label timeSizeReferenceLabel;
        private Label gateSizeReferenceLabel;

        private View globalBackgroundView;
        private View bannerBackgroundView;

        public ClassicDualOperationsPlacardView(ClassicOperationsDualPlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
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

            ArraivalsTableHeaderGrid.BackgroundColor = model.TableHeaderBackgroundColor;
            DeparturesTableHeaderGrid.BackgroundColor = model.TableHeaderBackgroundColor;

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

            model.InitializeTableHeader(ArraivalsTableHeaderGrid, Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival, TABLE_ITEM_MARGIN, tableHeaderItemFontSize, out timeSizeReferenceLabel, out gateSizeReferenceLabel);
            model.InitializeTableHeader(DeparturesTableHeaderGrid, Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure, TABLE_ITEM_MARGIN, tableHeaderItemFontSize, out timeSizeReferenceLabel, out gateSizeReferenceLabel);

            this.model = model;

            HeaderBaseBackgroundBoxView.Color = model.HeaderBackgroundColor;

            ArraivalsSectionHeaderStackLayout.BackgroundColor = model.TableHeaderBackgroundColor;
            ArraivalsSectionOperationSymbolLabel.TextColor = model.TableHeaderTextColor;
            ArraivalsSectionHeaderTitleLabel.TextColor = model.TableHeaderTextColor;
            ArraivalsSectionHeaderSeparatorBoxView.Color = model.TableHeaderTextColor;
            ArraivalsSectionHeaderSeparatorBoxView.Margin = new Thickness(TABLE_ITEM_MARGIN.Left, 0);

            DeparturesSectionHeaderStackLayout.BackgroundColor = model.TableHeaderBackgroundColor;
            DeparturesSectionOperationSymbolLabel.TextColor = model.TableHeaderTextColor;
            DeparturesSectionHeaderTitleLabel.TextColor = model.TableHeaderTextColor;
            DeparturesSectionHeaderSeparatorBoxView.Color = model.TableHeaderTextColor;
            DeparturesSectionHeaderSeparatorBoxView.Margin = new Thickness(TABLE_ITEM_MARGIN.Left, 0);

            if (model.IsHideHeaderBuildInInfoRequired)
            {
                //OperationSymbolLabel.IsVisible = false;
                //HeaderTitleLabel.IsVisible = false;
                HeaderSubTitleLabel.IsVisible = false;
                DateTimeLabel.IsVisible = false;

                LogoBacklightBoxView.Opacity = 0;
                LogoImageView.Opacity = 0;
            }
            else
            {
                //OperationSymbolLabel.TextColor = model.HeaderBackgroundColor.ToBlackOrWhiteForText();
                //HeaderTitleLabel.TextColor = OperationSymbolLabel.TextColor;
                HeaderSubTitleLabel.TextColor = model.HeaderBackgroundColor.ToBlackOrWhiteForText();
                DateTimeLabel.TextColor = HeaderSubTitleLabel.TextColor;

                LogoBacklightBoxView.Color = model.HeaderBackgroundColor.ToBlackOrWhiteForText();

                LogoImageView.Source = DependencyService.Get<Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>().LogoImageSource;

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

            LogoImageView.WidthRequest = LogoImageView.Height;

            if (model.LogoSizeMode == AccountLogoSizeMode.Rectangle19x6)
            {
                LogoImageView.WidthRequest = LogoImageView.Height * 1.7777777777777777777777777777778d;
            }
            else if (model.LogoSizeMode == AccountLogoSizeMode.Rectangle4x3)
            {
                LogoImageView.WidthRequest = LogoImageView.Height * 1.3333333333333333333333333333333d;
            }

            startedAt = System.DateTime.Now;

            var client = new Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.OperationsAPIConnectClient(this);

            client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
            {
                Kind = Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival
            }).ContinueWith(ArraivalsFetchOperations_Callback);
            client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
            {
                Kind = Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure
            }).ContinueWith(DeparturesFetchOperations_Callback);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            if (ArraivalsTableBodyStackLayout.Children.Count > 0)
            {
                foreach (var child in ArraivalsTableBodyStackLayout.Children)
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

            if (DeparturesTableBodyStackLayout.Children.Count > 0)
            {
                foreach (var child in DeparturesTableBodyStackLayout.Children)
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

            model.ArraivalItems?.Clear();
            model.DepartureItems?.Clear();

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

        private void ArraivalsOutgoingRowAnimation_Completed(object sender, System.EventArgs eventArgs)
        {
            var animation = sender as AbstractAnimation;

            animation.Completed -= ArraivalsOutgoingRowAnimation_Completed;

            Device.BeginInvokeOnMainThread(() =>
            {
                ArraivalsTableBodyStackLayout.Children.Remove(animation.Target as View);
            });
        }

        private void DeparturesOutgoingRowAnimation_Completed(object sender, System.EventArgs eventArgs)
        {
            var animation = sender as AbstractAnimation;

            animation.Completed -= DeparturesOutgoingRowAnimation_Completed;

            Device.BeginInvokeOnMainThread(() =>
            {
                DeparturesTableBodyStackLayout.Children.Remove(animation.Target as View);
            });
        }

        private void ArraivalsFetchOperations_Callback(System.Threading.Tasks.Task<Service.ECASA.CMG.InterFIDS.API.Common.Models.OperationDisplayModel[]> task)
        {
            if (BindingContext == null) return;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            var tableBodyStackLayoutChildrenCount = ArraivalsTableBodyStackLayout.Children.Count;

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
                            Target = ArraivalsTableBodyStackLayout.Children[i],
                            Duration = "360",
                            Delay = (120 * iterationIndex++).ToString(),
                            EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut
                        };

                        outgoingRowAnimation.TranslateX = outgoingRowAnimation.Target.Width;

                        outgoingRowAnimation.Completed += ArraivalsOutgoingRowAnimation_Completed;

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
                        item.AttachTo(index++, Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival, ArraivalsTableBodyStackLayout, ArraivalsTableHeaderGrid.ColumnDefinitions, model, TABLE_ITEM_MARGIN, tableBodyItemFontSize, timeSizeReferenceLabel?.Width ?? 0, gateSizeReferenceLabel?.Width ?? 0);
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
                    Kind = Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival
                }).ContinueWith(ArraivalsFetchOperations_Callback);
            }
            else
            {
                System.Threading.Tasks.Task.Delay(delay).ContinueWith(delayTask =>
                {
                    client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
                    {
                        Kind = Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival
                    }).ContinueWith(ArraivalsFetchOperations_Callback);
                });
            }
        }

        private void DeparturesFetchOperations_Callback(System.Threading.Tasks.Task<Service.ECASA.CMG.InterFIDS.API.Common.Models.OperationDisplayModel[]> task)
        {
            if (BindingContext == null) return;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            var tableBodyStackLayoutChildrenCount = DeparturesTableBodyStackLayout.Children.Count;

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
                            Target = DeparturesTableBodyStackLayout.Children[i],
                            Duration = "360",
                            Delay = (120 * iterationIndex++).ToString(),
                            EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut
                        };

                        outgoingRowAnimation.TranslateX = outgoingRowAnimation.Target.Width * -1;

                        outgoingRowAnimation.Completed += DeparturesOutgoingRowAnimation_Completed;

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
                        item.AttachTo(index++, Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure, DeparturesTableBodyStackLayout, DeparturesTableHeaderGrid.ColumnDefinitions, model, TABLE_ITEM_MARGIN, tableBodyItemFontSize, timeSizeReferenceLabel?.Width ?? 0, gateSizeReferenceLabel?.Width ?? 0);
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
                }).ContinueWith(DeparturesFetchOperations_Callback);
            }
            else
            {
                System.Threading.Tasks.Task.Delay(delay).ContinueWith(delayTask =>
                {
                    client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
                    {
                        Kind = Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure
                    }).ContinueWith(DeparturesFetchOperations_Callback);
                });
            }
        }

        private bool Timer_Callback()
        {
            var now = System.DateTime.Now;

            DateTimeLabel.Text = now.ToString("MMMM dd, HH:mm").ToUpperInvariant();

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