using SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Pages
{
    public partial class ImagePickPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ImagePickPageModel>
    {
        private System.Action<Presentation.Models.View.ImageViewModel> imagePickedCallbackAction;
        private SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider;
        private Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper;

        private Presentation.Models.View.ImageViewModel except;

        public ImagePickPage(Helpers.Facade.IExceptionHandleHelperFacade exceptionHandleHelper, SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider, System.Action<Presentation.Models.View.ImageViewModel> imagePickedCallbackAction, Presentation.Models.View.ImageViewModel except = null)
            : base(new Models.Page.ImagePickPageModel
            {
                IsBusy = true
            })
        {
            InitializeComponent();

            // TODO Use it!
            this.except = except;
            this.imagePickedCallbackAction = imagePickedCallbackAction;
            this.httpClientHelperProvider = httpClientHelperProvider;
            this.exceptionHandleHelper = exceptionHandleHelper;

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            LoadImages();

            IsEnabled = true;
        }

        private void ImageOverviewPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.IsBusy = true;

            var targetImageViewModel = (sender as Xamarin.Forms.BindableObject).BindingContext as Presentation.Models.View.ImageViewModel;

            imagePickedCallbackAction.Invoke(targetImageViewModel);

            this.NavigationPopPageAsync();
        }

        private void ImageOverviewDetailButton_Clicked(object sender, System.EventArgs e)
        {
            this.NavigationPushPageAsync(new ImageDetailPage((sender as Xamarin.Forms.BindableObject).BindingContext as Presentation.Models.View.ImageViewModel));
        }

        private void LoadImages(int page = 0)
        {
            System.Threading.Tasks.Task.Run(async () =>
            {
                var client = new Cloud.Api.Connect.Clients.ImagesApiClient(httpClientHelperProvider.HttpClientHelper);

                return await client.GetPageAsync(page);
            }).ContinueWith((System.Threading.Tasks.Task<SAPRESSC.Core.Common.Models.PaginationModel<Cloud.Api.Common.Models.ImageDisplayModel>> task) =>
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

                        if (page == 0 && BindingContextPageModel.Images.Count > 0)
                        {
                            BindingContextPageModel.Images.Clear();
                        }

                        foreach (var item in task.Result.List)
                        {
                            BindingContextPageModel.Images.Add(item.ToViewModel());
                        }
                    }
                });
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            imagePickedCallbackAction = null;
            httpClientHelperProvider = null;
            exceptionHandleHelper = null;
            except = null;
        }
    }
}