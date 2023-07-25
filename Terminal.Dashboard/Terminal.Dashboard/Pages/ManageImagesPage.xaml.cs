using SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Models.View;
using SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Support.Presentation.Models.View;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class ManageImagesPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ManageImagesPageModel>
    {
        private int currentItemsPageNumber;
        private int currentImageCollectionViewCellColumnCount = 3;
        private int pagingLimit = 15;

        public ManageImagesPage() : base(new Models.Page.ManageImagesPageModel())
        {
            InitializeComponent();
        }

        private void ImageOverviewDetailButton_Clicked(object sender, System.EventArgs e)
        {
            var targetModel = (sender as Xamarin.Forms.BindableObject).BindingContext as OverviewViewModel<ImageViewModel>;

            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.ImageDetailPage(targetModel.Presented, model =>
            {
                this.NavigationPushPageAsync(new EditImagePage(model));
            }));
        }

        private void ImageOverviewDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar esta imagen?", "Aceptar", "Cancelar").ContinueWith(async task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = true;
                });

                var client = new Cloud.Api.Connect.Clients.ImagesApiConnectClient(Managers.SessionManager.Instance.HttpClientHelper);

                System.Exception failException = null;

                try
                {
                    await client.DeleteAsync(((sender as Xamarin.Forms.BindableObject).BindingContext as OverviewViewModel<ImageViewModel>).Presented.Id);
                }
                catch (System.Exception ex)
                {
                    failException = ex;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (failException == null)
                    {
                        Xamarin.Forms.DependencyService.Get<Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade>().PresentNotification("Información", "Imagen eliminada con éxito.");

                        RequiredReload_Callback();
                    }
                    else
                    {
                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(failException);
                    }
                });
            });
        }

        private void AddToolbarItem_Activated(object sender, System.EventArgs e)
        {
            if (BindingContextPageModel.IsBusy) return;

            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(() =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                {
                    try
                    {
                        string[] fileSelector = null;

                        switch (Xamarin.Forms.Device.RuntimePlatform)
                        {
                            case Xamarin.Forms.Device.Android:
                                fileSelector = new string[] { "image/*" };

                                break;

                            case Xamarin.Forms.Device.UWP:
                                fileSelector = new string[] { ".jpg", ".jpeg", ".png", ".bmp" };

                                break;

                            case Xamarin.Forms.Device.WPF:
                            default:
                                fileSelector = new string[] { "Imágenes Soportadas|*.jpg;*.jpeg;*.png;*.bmp" };

                                break;
                        }

                        var targetFileData = await Plugin.FilePicker.CrossFilePicker.Current.PickFile(fileSelector);

                        if (targetFileData != null)
                        {
                            await this.NavigationPushPageAsync(new AddImagePage(targetFileData, RequiredReload_Callback));
                        }
                    }
                    finally
                    {
                        BindingContextPageModel.IsBusy = false;
                    }                   
                });
            });
        }

        private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            RequiredReload_Callback();
        }

        private void LoadNextPageButtton_Clicked(object sender, System.EventArgs eventArgs)
        {
            LoadNextItemsPage();
        }

        private void ImageCollectionWrapperStackLayout_SizeChanged(object sender, System.EventArgs eventArgs)
        {
            if (ImageCollectionView.Width < 0 || ImageCollectionView.Height < 0) return;

            if (BindingContextPageModel.IsBusy) return;

            LoadNextItemsPage(true);
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

        private void RequiredReload_Callback()
        {
            LoadNextItemsPage(true);
        }

        private void LoadNextItemsPage(bool restart = false)
        {
            BindingContextPageModel.IsBusy = true;

            if (restart)
            {
                CalculateCollectionPagingMetrics();

                currentItemsPageNumber = 0;

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

            var imagesApiConnectClient = new Cloud.Api.Connect.Clients.ImagesApiConnectClient(Managers.SessionManager.Instance.HttpClientHelper);

            imagesApiConnectClient.GetPageAsync(++currentItemsPageNumber, pagingLimit).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        if (currentItemsPageNumber == 1)
                        {
                            if (BindingContextPageModel.Items == null)
                            {
                                BindingContextPageModel.Items = new System.Collections.ObjectModel.ObservableCollection<OverviewViewModel<ImageViewModel>>();
                            }
                            else
                            {
                                BindingContextPageModel.Items.Clear();
                            }
                        }

                        foreach (var item in task.Result.List)
                        {
                            BindingContextPageModel.Items.Add(new OverviewViewModel<ImageViewModel>(item.ToViewModel(), true));
                        }

                        BindingContextPageModel.HasMoreItems = task.Result.HasNext && task.Result.List.Count > 0;
                    }

                    BindingContextPageModel.IsBusy = false;
                });
            });
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