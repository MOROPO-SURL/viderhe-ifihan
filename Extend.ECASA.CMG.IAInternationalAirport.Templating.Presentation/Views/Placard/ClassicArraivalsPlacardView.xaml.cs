using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Models.View.Placard;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Views.Placard
{
    public partial class ClassicArraivalsPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView, Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private static Thickness TABLE_ITEM_MARGIN = new Thickness(12);

        private static Common.Templating.Presentation.Converters.SizeToRelativeValueConverter SIZE_TO_RELATIVE_VALUE_CONVERTER = new Common.Templating.Presentation.Converters.SizeToRelativeValueConverter();

        private readonly ClassicOperationsPlacardViewModel model;

        private Label timeSizeReferenceLabel;
        private Label gateSizeReferenceLabel;

        public ClassicArraivalsPlacardView(ClassicOperationsPlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;

            TableLayout.BackgroundColor = model.TableBackgroundColor;

            TableHeaderGrid.BackgroundColor = model.TableHeaderBackgroundColor;

            if (model.Background != null)
            {
                BackgroundColor = model.TableBackgroundColor;

                TableLayout.BackgroundColor = TableLayout.BackgroundColor.MultiplyAlpha((100.0D - model.ForegroundTransparency) / 100);

                var unresponsiveMarginFactor = (Application.Current.MainPage.Width + Application.Current.MainPage.Height) / 2 * 0.04;

                var responsiveMarginFactor = (double)SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(unresponsiveMarginFactor, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture) * RelativeSizeScaleFactor;

                TableLayout.Margin = new Thickness(responsiveMarginFactor);

                View backgroundView = null;

                switch (model.Background.Kind)
                {
                    case BackgroundKind.Gradient:
                        var gradientModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.GradientContextModel>(model.Background.SerializedContext);

                        backgroundView = new MagicGradients.GradientView
                        {
                            GradientSource = MagicGradients.CssGradientSource.Parse(gradientModel.Data)
                        };

                        break;

                    case BackgroundKind.Image:
                        var imageModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.ImageContextModel>(model.Background.SerializedContext).ToViewModel();

                        backgroundView = new FFImageLoading.Forms.CachedImage
                        {
                            Source = ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(imageModel.Id)),
                            FadeAnimationEnabled = false,
                            Aspect = Aspect.AspectFill,
                            CacheType = FFImageLoading.Cache.CacheType.Disk,
                            CacheDuration = System.TimeSpan.MaxValue
                        };

                        break;

                    //case Enumerations.BackgroundKind.Video:
                    //    var videoModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.VideoContextModel>(model.Background.SerializedContext).ToViewModel();

                    //    Content = new FFImageLoading.Forms.CachedImage
                    //    {
                    //        Source = ImageSource.FromUri(Support.Presentation.Factories.ThumbnailUriFactory.BuildThumbnailUri(videoModel.ThumbnailId)),
                    //        FadeAnimationEnabled = false,
                    //        Aspect = Aspect.AspectFill,
                    //        CacheType = FFImageLoading.Cache.CacheType.Disk,
                    //        CacheDuration = System.TimeSpan.MaxValue
                    //    };

                    //    break;
                }

                ArraivalsLayout.Children.Insert(0, backgroundView);
            }

            var tableHeaderItemFontSize = (double)SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(model.TableHeaderFontSize, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture) * RelativeSizeScaleFactor;

            model.InitializeTableHeader(TableHeaderGrid, Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival, TABLE_ITEM_MARGIN, tableHeaderItemFontSize, out timeSizeReferenceLabel, out gateSizeReferenceLabel);
            
            this.model = model;
        }

        public override Layout<View> WrapLayout => Wrapper;

        public override View PlacardView => ArraivalsLayout;

        public override void ConfigureLayout(View view)
        {
            Grid.SetColumn(view, 0);
            Grid.SetRow(view, 0);
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            var client = new Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.OperationsAPIConnectClient(this);

            client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
            {
                Kind = Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival
            }).ContinueWith(FetchOperations_Callback);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            timeSizeReferenceLabel = null;
        }

        private void FetchOperations_Callback(System.Threading.Tasks.Task<Service.ECASA.CMG.InterFIDS.API.Common.Models.OperationDisplayModel[]> task)
        {
            if (BindingContext == null) return;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            if (!task.IsCanceled && task.Exception == null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    TableBodyStackLayout.Children.Clear();
                });

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

            if (delay <= System.TimeSpan.Zero)
            {
                client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
                {
                    Kind = Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival
                }).ContinueWith(FetchOperations_Callback);
            }
            else
            {
                System.Threading.Tasks.Task.Delay(delay).ContinueWith(delayTask =>
                {
                    client.FilterAsync(new Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
                    {
                        Kind = Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Arraival
                    }).ContinueWith(FetchOperations_Callback);
                });
            }
        }

        #region IHttpClientHelperProviderFacade implementation

        public MOROPO.Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper
        {
            get
            {
                if (BindingContext == null) throw new System.InvalidOperationException();

                return new MOROPO.Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(
                    string.Format("{0}://{1}/api/", model.UseSSL ? "https" : "http", model.APIServer),
                    null,
                    () => { return new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Constants.Authentication.API_KEY_HEADER_PROPERTY, model.APIKey) }; });
            }
        }

        #endregion
    }
}