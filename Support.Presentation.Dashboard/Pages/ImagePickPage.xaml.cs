using SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Pages
{
    public partial class ImagePickPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ImagePickPageModel>
    {
        private System.Action<Presentation.Models.View.ImageViewModel> imagePickedCallbackAction;

        private Presentation.Models.View.ImageViewModel except;

        private int currentImagesPageNumber;
        private int currentImageCollectionViewCellColumnCount = 3;
        private int pagingLimit = 15;

        public ImagePickPage(System.Action<Presentation.Models.View.ImageViewModel> imagePickedCallbackAction, Presentation.Models.View.ImageViewModel except = null)
            : base(new Models.Page.ImagePickPageModel())
        {
            InitializeComponent();

            this.except = except;
            this.imagePickedCallbackAction = imagePickedCallbackAction;
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

        private void LoadNextPageButtton_Clicked(object sender, System.EventArgs eventArgs)
        {
            LoadNextImagesPage();
        }

        private void ImageCollectionWrapperStackLayout_SizeChanged(object sender, System.EventArgs eventArgs)
        {
            if (ImageCollectionView.Width < 0 || ImageCollectionView.Height < 0) return;

            if (BindingContextPageModel.IsBusy) return;

            LoadNextImagesPage(true);
        }

        private void ImageCollectionView_Scrolled(object sender, Xamarin.Forms.ItemsViewScrolledEventArgs eventArgs)
        {
            if (eventArgs.FirstVisibleItemIndex < 0 || eventArgs.LastVisibleItemIndex < 0) return;

            if (eventArgs.FirstVisibleItemIndex > 0)
            {
                for (int index = 0; index < eventArgs.FirstVisibleItemIndex; index++)
                {
                    if (BindingContextPageModel.Items == null || BindingContextPageModel.Items.Count <= index) return;

                    BindingContextPageModel.Items.ElementAtOrDefault(index)?.Unpresent();
                }
            }

            if (BindingContextPageModel.Items == null) return;

            var loadToEnd = BindingContextPageModel.Items.Count - eventArgs.LastVisibleItemIndex - 1 <= currentImageCollectionViewCellColumnCount * 2;

            var effectiveLastVisibleItemIndex = loadToEnd ? BindingContextPageModel.Items.Count - 1 : eventArgs.LastVisibleItemIndex + (currentImageCollectionViewCellColumnCount * 2);

            for (int index = eventArgs.FirstVisibleItemIndex; index <= effectiveLastVisibleItemIndex; index++)
            {
                if (BindingContextPageModel.Items == null || BindingContextPageModel.Items.Count <= index) return;

                BindingContextPageModel.Items.ElementAt(index).Present();
            }

            // TODO Find a better way to handle eventArgs values for UWP
            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.UWP) return;

            if (loadToEnd) return;

            if (BindingContextPageModel.Items == null) return;

            if (effectiveLastVisibleItemIndex < BindingContextPageModel.Items.Count - 1)
            {
                for (int index = effectiveLastVisibleItemIndex + 1; index < BindingContextPageModel.Items.Count; index++)
                {
                    if (BindingContextPageModel.Items == null || BindingContextPageModel.Items.Count <= index) break;

                    BindingContextPageModel.Items.ElementAtOrDefault(index)?.Unpresent();
                }
            }
        }

        private void LoadNextImagesPage(bool restart = false)
        {
            BindingContextPageModel.IsBusy = true;

            if (restart)
            {
                CalculateCollectionPagingMetrics();

                currentImagesPageNumber = 0;

                if (BindingContextPageModel.Items != null)
                {
                    foreach (var item in BindingContextPageModel.Items)
                    {
                        item?.Dispose();
                    }

                    BindingContextPageModel.Items.Clear();

                    BindingContextPageModel.Items = null;
                }
            }

            var imagesApiConnectClient = new Cloud.Api.Connect.Clients.ImagesApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper);

            imagesApiConnectClient.GetPageAsync(++currentImagesPageNumber, pagingLimit).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null)
                    {
                        Xamarin.Forms.DependencyService.Get<Presentation.Helpers.Facade.IExceptionHandleHelperFacade>().HandleException(task.Exception);
                    }
                    else
                    {
                        if (currentImagesPageNumber == 1)
                        {
                            if (BindingContextPageModel.Items == null)
                            {
                                BindingContextPageModel.Items = new System.Collections.ObjectModel.ObservableCollection<Models.View.OverviewViewModel<Presentation.Models.View.ImageViewModel>>();
                            }
                            else
                            {
                                BindingContextPageModel.Items.Clear();
                            }
                        }

                        foreach (var item in task.Result.List)
                        {
                            // TODO Find how exept correctly!!
                            //if (except != null && except.Id == item.Id) continue;

                            BindingContextPageModel.Items.Add(new Models.View.OverviewViewModel<Presentation.Models.View.ImageViewModel>(item.ToViewModel()));
                        }

                        BindingContextPageModel.HasMoreItems = task.Result.HasNext && task.Result.List.Count > 0;

                        BindingContextPageModel.IsBusy = false;
                    }
                });
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            imagePickedCallbackAction = null;
            except = null;
        }

        private void CalculateCollectionPagingMetrics()
        {
            var collumnReazon = ImageCollectionView.Width / (320 + 10);

            currentImageCollectionViewCellColumnCount = System.Convert.ToInt32(System.Math.Round(collumnReazon, System.MidpointRounding.ToEven));

            if (currentImageCollectionViewCellColumnCount > collumnReazon)
            {
                currentImageCollectionViewCellColumnCount--;
            }

            if (currentImageCollectionViewCellColumnCount <= 0)
            {
                currentImageCollectionViewCellColumnCount = 1;
            }

            var collectionViewCellWidth = (ImageCollectionView.Width - ((currentImageCollectionViewCellColumnCount - 1) * 10)) / currentImageCollectionViewCellColumnCount;

            var collectionViewCellHeight = collectionViewCellWidth / 1.777777777777778 + (collectionViewCellWidth * 0.20);

            var availableVerticalHeight = ImageCollectionView.Height;

            var rowCount = 0;

            while (availableVerticalHeight > 0)
            {
                rowCount++;

                availableVerticalHeight -= collectionViewCellHeight + 10;
            }

            pagingLimit = currentImageCollectionViewCellColumnCount * rowCount;
        }
    }
}