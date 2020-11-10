using SmartSolucionesCuba.Videre.Support.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Pages
{
    public partial class PrePickVideoPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Support.Presentation.Dashboard.Models.Page.VideoPickPageModel>
    {
        private Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor;
        private System.Action successfulCompleteCallbackAction;
        private System.Action<Support.Presentation.Models.View.VideoViewModel, Common.Templating.Descriptors.ITemplateDescriptor, System.Action> videoPickedCallbackAction;
        private SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider;
        private Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper;

        public PrePickVideoPage(Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action successfulCompleteCallbackAction, System.Action<Support.Presentation.Models.View.VideoViewModel, Common.Templating.Descriptors.ITemplateDescriptor, System.Action> videoPickedCallbackAction, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider)
            : base(new Support.Presentation.Dashboard.Models.Page.VideoPickPageModel { IsBusy = true })
        {
            InitializeComponent();

            this.templateDescriptor = templateDescriptor;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;
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
            var targetImageViewModel = (sender as Xamarin.Forms.BindableObject).BindingContext as Support.Presentation.Models.View.VideoViewModel;

            videoPickedCallbackAction.Invoke(targetImageViewModel, templateDescriptor, OnSuccessfulComplete);
        }

        private void VideoOverviewDetailButton_Clicked(object sender, System.EventArgs e)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.VideoDetailPage((sender as Xamarin.Forms.BindableObject).BindingContext as Support.Presentation.Models.View.VideoViewModel));
        }

        private void OnSuccessfulComplete()
        {
            this.NavigationPopPageAsync();

            successfulCompleteCallbackAction.Invoke();
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

            templateDescriptor = null;
            successfulCompleteCallbackAction = null;
            exceptionHandleHelper = null;
            httpClientHelperProvider = null;
            videoPickedCallbackAction = null;
        }
    }
}