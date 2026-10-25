using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;
using MOROPO.VIDERHE.Support.Presentation.Extensions;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages
{
    public partial class ImagesPickPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<ImagesPickPageModel>
    {
        private ImageViewModel[] exclusionImages;
        private System.Action<ImageViewModel[]> imagesSelectedCallbackAction;

        private int currentImagesPageNumber;

        public ImagesPickPage(ImageViewModel[] exclusionImages, System.Action<ImageViewModel[]> imagesSelectedCallbackAction)
            : base(new ImagesPickPageModel { IsBusy = true })
        {
            InitializeComponent();

            this.exclusionImages = exclusionImages;
            this.imagesSelectedCallbackAction = imagesSelectedCallbackAction;

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            LoadNextImagesPage(true);

            IsEnabled = true;
        }

        private void ApplyToolbarItem_Activated(object sender, System.EventArgs e)
        {
            imagesSelectedCallbackAction.Invoke(BindingContextPageModel.SelectableImages.Where(m => m.Selected).Select(m => m.Model).ToArray());

            this.NavigationPopPageAsync();
        }

        private void CancelToolbarItem_Activated(object sender, System.EventArgs e)
        {
            this.NavigationPopPageAsync();
        }

        private void SelectionToggleLabelTapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            ((sender as Xamarin.Forms.BindableObject).BindingContext as SelectableModelViewModel<ImageViewModel>).Selected = !((sender as Xamarin.Forms.BindableObject).BindingContext as SelectableModelViewModel<ImageViewModel>).Selected;
        }

        private void ImageOverviewDetailButton_Clicked(object sender, System.EventArgs e)
        {
            this.NavigationPushPageAsync(new ImageDetailPage(((sender as Xamarin.Forms.BindableObject).BindingContext as SelectableModelViewModel<ImageViewModel>).Model));
        }

        private void LoadNextPageButtton_Clicked(object sender, System.EventArgs eventArgs)
        {
            LoadNextImagesPage();
        }

        private void LoadNextImagesPage(bool restart = false)
        {
            BindingContextPageModel.IsBusy = true;

            if (restart) currentImagesPageNumber = 0;

            var imagesApiConnectClient = new Cloud.Api.Connect.Clients.ImagesApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper);

            imagesApiConnectClient.GetPageAsync(++currentImagesPageNumber).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        Xamarin.Forms.DependencyService.Get<IExceptionHandleHelperFacade>().HandleException(task.Exception);
                    }
                    else
                    {
                        var relevantImages = task.Result.List.Select(m => m.ToViewModel()).ToArray().Except(exclusionImages).Select(item => new SelectableModelViewModel<ImageViewModel>
                        {
                            Model = item
                        });

                        if (currentImagesPageNumber == 1)
                        {
                            BindingContextPageModel.SelectableImages.Clear();
                        }

                        foreach (var item in relevantImages)
                        {
                            BindingContextPageModel.SelectableImages.Add(item);
                        }

                        BindingContextPageModel.HasMoreImages = task.Result.HasNext && task.Result.List.Count > 0;
                    }
                });
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            exclusionImages = null;
            imagesSelectedCallbackAction = null;
        }
    }
}