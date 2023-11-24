using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Views.Placard
{
    public partial class ClassicDeparturesPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView, MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private static Thickness TABLE_ITEM_MARGIN = new Thickness(12);

        private static Common.Templating.Presentation.Converters.SizeToRelativeValueConverter SIZE_TO_RELATIVE_VALUE_CONVERTER = new Common.Templating.Presentation.Converters.SizeToRelativeValueConverter();

        private readonly Models.View.Placard.ClassicOperationsPlacardViewModel model;

        private Label timeSizeReferenceLabel;

        public ClassicDeparturesPlacardView(Models.View.Placard.ClassicOperationsPlacardViewModel model)
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

                var responsiveMarginFactor = (double)SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(unresponsiveMarginFactor, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture);

                TableLayout.Margin = new Thickness(responsiveMarginFactor);

                View backgroundView = null;

                switch (model.Background.Kind)
                {
                    case Enumerations.BackgroundKind.Gradient:
                        var gradientModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.GradientContextModel>(model.Background.SerializedContext);

                        backgroundView = new MagicGradients.GradientView
                        {
                            GradientSource = MagicGradients.CssGradientSource.Parse(gradientModel.Data)
                        };

                        break;

                    case Enumerations.BackgroundKind.Image:
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

                DeparturesLayout.Children.Insert(0, backgroundView);
            }

            var tableHeaderItemFontSize = (double)SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(model.TableHeaderFontSize, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture);

            model.InitializeTableHeader(TableHeaderGrid, MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure, TABLE_ITEM_MARGIN, tableHeaderItemFontSize, out timeSizeReferenceLabel);

            this.model = model;
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

            var client = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.OperationsAPIConnectClient(this);

            client.FilterAsync(new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
            {
                Kind = MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure
            }).ContinueWith(FetchOperations_Callback);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            timeSizeReferenceLabel = null;
        }

        private void FetchOperations_Callback(System.Threading.Tasks.Task<MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.OperationDisplayModel[]> task)
        {
            if (BindingContext == null) return;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            if (!task.IsCanceled && task.Exception == null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    TableBodyStackLayout.Children.Clear();
                });

                var tableBodyItemFontSize = SIZE_TO_RELATIVE_VALUE_CONVERTER.Convert(model.RowFontSize, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture);

                var index = 0;

                foreach (var item in task.Result)
                {
                    System.Threading.Thread.Sleep(System.TimeSpan.FromMilliseconds(250));

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        item.AttachTo(index++, TableBodyStackLayout, TableHeaderGrid.ColumnDefinitions, model, TABLE_ITEM_MARGIN, (double)tableBodyItemFontSize, timeSizeReferenceLabel.Width);
                    });
                }
            }

            stopwatch.Stop();

            var client = new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Connect.Frontend.Clients.OperationsAPIConnectClient(this);

            var delay = System.TimeSpan.FromSeconds(model.UpdateInterval) - stopwatch.Elapsed;

            if (delay <= System.TimeSpan.Zero)
            {
                client.FilterAsync(new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
                {
                    Kind = MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure
                }).ContinueWith(FetchOperations_Callback);
            }
            else
            {
                System.Threading.Tasks.Task.Delay(delay).ContinueWith(delayTask =>
                {
                    client.FilterAsync(new MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.Filter.OperationFilterModel
                    {
                        Kind = MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Enumerations.OperationKind.Departure
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