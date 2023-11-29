using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;
using MOROPO.VIDERHE.Support.Presentation.Extensions;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class ManageVideosPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ManageVideosPageModel>
    {
        private int currentItemsPageNumber;
        private int currentVideoCollectionViewCellColumnCount = 3;
        private int pagingLimit = 15;

        public ManageVideosPage() : base(new Models.Page.ManageVideosPageModel())
        {
            InitializeComponent();
        }

        private void VideoOverviewDetailButton_Clicked(object sender, System.EventArgs e)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.VideoDetailPage(((sender as Xamarin.Forms.BindableObject).BindingContext as OverviewViewModel<VideoViewModel>).Presented, model =>
            {
                this.NavigationPushPageAsync(new EditVideoPage(model));
            }));
        }

        private void VideoOverviewDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este video?", "Aceptar", "Cancelar").ContinueWith(async task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = true;
                });

                var client = new Cloud.Api.Connect.Clients.VideosApiConnectClient(Managers.SessionManager.Instance.HttpClientHelper);

                System.Exception failException = null;

                try
                {
                    await client.DeleteAsync(((sender as Xamarin.Forms.BindableObject).BindingContext as OverviewViewModel<VideoViewModel>).Presented.Id);
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
                        Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Video eliminado con éxito.");

                        RequiredReload_Callback();
                    }
                    else
                    {
                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(failException);
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
                                fileSelector = new string[] { "video/*" };

                                break;

                            case Xamarin.Forms.Device.UWP:
                                fileSelector = new string[] { ".mp4", ".mkv", ".avi", ".mpg", ".flv" };

                                break;

                            case Xamarin.Forms.Device.WPF:
                            default:
                                fileSelector = new string[] { "Videos Soportados|*.mp4;*.mkv;*.avi;*.mpg", "*.flv" };

                                break;
                        }

                        var targetFileData = await Plugin.FilePicker.CrossFilePicker.Current.PickFile(fileSelector);

                        if (targetFileData != null)
                        {
                            await this.NavigationPushPageAsync(new AddVideoPage(targetFileData, RequiredReload_Callback));
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

        private void VideoCollectionWrapperStackLayout_SizeChanged(object sender, System.EventArgs eventArgs)
        {
            if (VideoCollectionView.Width < 0 || VideoCollectionView.Height < 0) return;

            if (BindingContextPageModel.IsBusy) return;

            LoadNextItemsPage(true);
        }

        private void VideoCollectionView_Scrolled(object sender, Xamarin.Forms.ItemsViewScrolledEventArgs eventArgs)
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

            var loadToEnd = BindingContextPageModel.Items.Count - eventArgs.LastVisibleItemIndex - 1 <= currentVideoCollectionViewCellColumnCount * 2;

            var effectiveLastVisibleItemIndex = loadToEnd ? BindingContextPageModel.Items.Count - 1 : eventArgs.LastVisibleItemIndex + (currentVideoCollectionViewCellColumnCount * 2);

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

            var videosApiConnectClient = new Cloud.Api.Connect.Clients.VideosApiConnectClient(Managers.SessionManager.Instance.HttpClientHelper);

            videosApiConnectClient.GetPageAsync(++currentItemsPageNumber, pagingLimit).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        if (currentItemsPageNumber == 1)
                        {
                            if (BindingContextPageModel.Items == null)
                            {
                                BindingContextPageModel.Items = new System.Collections.ObjectModel.ObservableCollection<OverviewViewModel<VideoViewModel>>();
                            }
                            else
                            {
                                BindingContextPageModel.Items.Clear();
                            }
                        }

                        foreach (var item in task.Result.List)
                        {
                            BindingContextPageModel.Items.Add(new OverviewViewModel<VideoViewModel>(item.ToViewModel(), true));
                        }

                        BindingContextPageModel.HasMoreItems = task.Result.HasNext && task.Result.List.Count > 0;
                    }

                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void CalculateCollectionPagingMetrics()
        {
            var collumnReazon = VideoCollectionView.Width / (320 + 10);

            currentVideoCollectionViewCellColumnCount = System.Convert.ToInt32(System.Math.Round(collumnReazon, System.MidpointRounding.ToEven));

            if (currentVideoCollectionViewCellColumnCount > collumnReazon)
            {
                currentVideoCollectionViewCellColumnCount--;
            }

            if (currentVideoCollectionViewCellColumnCount <= 0)
            {
                currentVideoCollectionViewCellColumnCount = 1;
            }

            var collectionViewCellWidth = (VideoCollectionView.Width - ((currentVideoCollectionViewCellColumnCount - 1) * 10)) / currentVideoCollectionViewCellColumnCount;

            var collectionViewCellHeight = collectionViewCellWidth / 1.777777777777778 + (collectionViewCellWidth * 0.20);

            var availableVerticalHeight = VideoCollectionView.Height;

            var rowCount = 0;

            while (availableVerticalHeight > 0)
            {
                rowCount++;

                availableVerticalHeight -= collectionViewCellHeight + 10;
            }

            pagingLimit = currentVideoCollectionViewCellColumnCount * rowCount;
        }
    }
}