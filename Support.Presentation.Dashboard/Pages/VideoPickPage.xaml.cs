using SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Pages
{
    public partial class VideoPickPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.VideoPickPageModel>
    {
        private System.Action<Presentation.Models.View.VideoViewModel> videoPickedCallbackAction;
        private SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider;
        private Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper;

        private Presentation.Models.View.VideoViewModel except;

        public VideoPickPage(Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, System.Action<Presentation.Models.View.VideoViewModel> videoPickedCallbackAction, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, Presentation.Models.View.VideoViewModel except = null)
            : base(new Models.Page.VideoPickPageModel { IsBusy = true })
        {
            InitializeComponent();

            // TODO Use it!
            this.except = except;
            this.videoPickedCallbackAction = videoPickedCallbackAction;
            this.httpClientHelperProvider = httpClientHelperProvider;
            this.exceptionHandleHelper = exceptionHandleHelper;

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            LoadVideos();

            IsEnabled = true;
        }

        private void VideoOverviewPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var targetImageViewModel = (sender as Xamarin.Forms.BindableObject).BindingContext as Presentation.Models.View.VideoViewModel;

            videoPickedCallbackAction.Invoke(targetImageViewModel);

            this.NavigationPopPageAsync();
        }

        private void VideoOverviewDetailButton_Clicked(object sender, System.EventArgs e)
        {
            this.NavigationPushPageAsync(new VideoDetailPage((sender as Xamarin.Forms.BindableObject).BindingContext as Presentation.Models.View.VideoViewModel));
        }

        private void LoadVideos(int page = 0)
        {
            System.Threading.Tasks.Task.Run(async () =>
            {
                var client = new Cloud.Api.Connect.Clients.VideosApiClient(httpClientHelperProvider.HttpClientHelper);

                return await client.GetPageAsync(page);
            }).ContinueWith((System.Threading.Tasks.Task<SAPRESSC.Core.Common.Models.PaginationModel<Cloud.Api.Common.Models.VideoDisplayModel>> task) =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null)
                    {
                        exceptionHandleHelper.HandleException(task.Exception);
                    }
                    else
                    {
                        BindingContextPageModel.Total = task.Result.Limit * task.Result.MaxPageCount;

                        if (page == 0 && BindingContextPageModel.Videos.Count > 0)
                        {
                            BindingContextPageModel.Videos.Clear();
                        }

                        foreach (var item in task.Result.List)
                        {
                            BindingContextPageModel.Videos.Add(item.ToViewModel());
                        }
                    }
                });
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            except = null;
            exceptionHandleHelper = null;
            httpClientHelperProvider = null;
            videoPickedCallbackAction = null;
        }
    }
}