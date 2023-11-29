using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class ManageGradientsPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ManageGradientsPageModel>
    {
        private int currentItemsPageNumber;
        private int currentGradientCollectionViewCellColumnCount = 3;
        private int pagingLimit = 15;

        public ManageGradientsPage() : base(new Models.Page.ManageGradientsPageModel())
        {
            InitializeComponent();
        }

        private void ItemDetailButton_Clicked(object sender, System.EventArgs e)
        {
            var targetModel = (sender as Xamarin.Forms.BindableObject).BindingContext as OverviewViewModel<GradientViewModel>;

            this.NavigationPushPageAsync(new ConfigureGradientPage(RequiredReload_Callback, targetModel.Presented));
        }

        private void ItemDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este gradiente?", "Aceptar", "Cancelar").ContinueWith(async task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = true;
                });

                var client = new Cloud.Api.Connect.Clients.GradientsApiConnectClient(Managers.SessionManager.Instance);

                System.Exception failException = null;

                try
                {
                    var targetModel = (sender as Xamarin.Forms.BindableObject).BindingContext as OverviewViewModel<GradientViewModel>;

                    await client.Delete(targetModel.Presented.Id);
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
                        Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Gradiente eliminado con éxito.");

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

            this.NavigationPushPageAsync(new ConfigureGradientPage(RequiredReload_Callback));
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

        private void GradientCollectionWrapperStackLayout_SizeChanged(object sender, System.EventArgs eventArgs)
        {
            if (GradientCollectionView.Width < 0 || GradientCollectionView.Height < 0) return;

            if (BindingContextPageModel.IsBusy) return;

            LoadNextItemsPage(true);
        }

        private void GradientCollectionView_Scrolled(object sender, Xamarin.Forms.ItemsViewScrolledEventArgs eventArgs)
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

            var loadToEnd = BindingContextPageModel.Items.Count - eventArgs.LastVisibleItemIndex - 1 <= currentGradientCollectionViewCellColumnCount * 2;

            var effectiveLastVisibleItemIndex = loadToEnd ? BindingContextPageModel.Items.Count - 1 : eventArgs.LastVisibleItemIndex + (currentGradientCollectionViewCellColumnCount * 2);

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

            var apiConnectClient = new Cloud.Api.Connect.Clients.GradientsApiConnectClient(Managers.SessionManager.Instance);

            apiConnectClient.GetPaginateAsync(++currentItemsPageNumber, pagingLimit).ContinueWith(task =>
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
                                BindingContextPageModel.Items = new System.Collections.ObjectModel.ObservableCollection<OverviewViewModel<GradientViewModel>>();
                            }
                            else
                            {
                                BindingContextPageModel.Items.Clear();
                            }
                        }

                        foreach (var item in task.Result.List)
                        {
                            BindingContextPageModel.Items.Add(new OverviewViewModel<GradientViewModel>(new GradientViewModel
                            {
                                Id = item.Id,
                                About = item.About,
                                CreateAt = item.CreateAt,
                                Source = MagicGradients.CssGradientSource.Parse(item.Data)
                            }));
                        }

                        BindingContextPageModel.HasMoreItems = task.Result.HasNext && task.Result.List.Count > 0;
                    }

                    BindingContextPageModel.IsBusy = false;
                });
            });
        }

        private void CalculateCollectionPagingMetrics()
        {
            var collumnReazon = GradientCollectionView.Width / (320 + 10);

            currentGradientCollectionViewCellColumnCount = System.Convert.ToInt32(System.Math.Round(collumnReazon, System.MidpointRounding.ToEven));

            if (currentGradientCollectionViewCellColumnCount > collumnReazon)
            {
                currentGradientCollectionViewCellColumnCount--;
            }

            if (currentGradientCollectionViewCellColumnCount <= 0)
            {
                currentGradientCollectionViewCellColumnCount = 1;
            }

            var collectionViewCellWidth = (GradientCollectionView.Width - ((currentGradientCollectionViewCellColumnCount - 1) * 10)) / currentGradientCollectionViewCellColumnCount;

            var collectionViewCellHeight = collectionViewCellWidth / 1.777777777777778 + (collectionViewCellWidth * 0.20);

            var availableVerticalHeight = GradientCollectionView.Height;

            var rowCount = 0;

            while (availableVerticalHeight > 0)
            {
                rowCount++;

                availableVerticalHeight -= collectionViewCellHeight + 10;
            }

            pagingLimit = currentGradientCollectionViewCellColumnCount * rowCount;
        }
    }
}