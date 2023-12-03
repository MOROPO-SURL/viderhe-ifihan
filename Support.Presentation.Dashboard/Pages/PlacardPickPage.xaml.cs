using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;
using MOROPO.VIDERHE.Support.Presentation.Extensions;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages
{
    public partial class PlacardPickPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<PlacardPickPageModel>
    {
        private System.Action<PlacardDisplayModel, object> itemPickedCallbackAction;

        private int currentPlacardsPageNumber;
        private int currentPlacardCollectionViewCellColumnCount = 3;
        private int placardPageLimit = 15;

        private object callbackParam;

        public PlacardPickPage(System.Action<PlacardDisplayModel, object> itemPickedCallbackAction, object callbackParam)
            : base(new PlacardPickPageModel
            {
                IsBusy = false
            })
        {
            InitializeComponent();

            this.itemPickedCallbackAction = itemPickedCallbackAction;
            this.callbackParam = callbackParam;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            itemPickedCallbackAction = null;
            callbackParam = null;
        }

        private void PlacardOverviewCollectionView_Scrolled(object sender, Xamarin.Forms.ItemsViewScrolledEventArgs eventArgs)
        {
            UpdatePlacardOverviewLoadByScrollContext(eventArgs);
        }

        private void PlacardOverviewCollectionWrapperView_SizeChanged(object sender, System.EventArgs eventArgs)
        {
            if (PlacardOverviewCollectionView.Width < 0 || PlacardOverviewCollectionView.Height < 0) return;

            if (BindingContextPageModel.IsBusy) return;

            LoadNextItemsPage(true);
        }

        private void PlacardOverviewPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.IsBusy = true;

            var target = (sender as Xamarin.Forms.BindableObject).BindingContext as PlacardOverviewViewModel;

            itemPickedCallbackAction.Invoke(new Cloud.Api.Common.Models.PlacardDisplayModel
            {
                Id = target.Placard.Id,
                Label = target.Placard.Label,
                PlayerOrientationSupportKind = target.Placard.PlayerOrientationSupportKind,
                SerializedContext = target.Placard.SerializedContext
            }, callbackParam);

            this.NavigationPopPageAsync();
        }

        private void LoadNextPageButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            LoadNextItemsPage();
        }

        private void LoadNextItemsPage(bool restart = false)
        {
            BindingContextPageModel.IsBusy = true;

            if (restart)
            {
                CalculatePlacardPresentationMetrics();

                currentPlacardsPageNumber = 0;

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

            var placardsApiConnectClient = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            placardsApiConnectClient.GetPaginateAsync(++currentPlacardsPageNumber, placardPageLimit).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        if (currentPlacardsPageNumber == 1)
                        {
                            BindingContextPageModel.Items = new System.Collections.ObjectModel.ObservableCollection<PlacardOverviewViewModel>(task.Result.List.Select(item => new PlacardOverviewViewModel(item.ToViewModel())));
                        }
                        else
                        {
                            foreach (var item in task.Result.List)
                            {
                                BindingContextPageModel.Items.Add(new PlacardOverviewViewModel(item.ToViewModel(), true));
                            }
                        }

                        BindingContextPageModel.HasMoreItems = task.Result.HasNext && task.Result.List.Count > 0;
                    }

                    BindingContextPageModel.IsBusy = false;
                });
            });

        }

        private void CalculatePlacardPresentationMetrics()
        {
            var collumnReazon = PlacardOverviewCollectionView.Width / (200 + 10);

            currentPlacardCollectionViewCellColumnCount = System.Convert.ToInt32(System.Math.Round(collumnReazon, System.MidpointRounding.ToEven));

            if (currentPlacardCollectionViewCellColumnCount > collumnReazon)
            {
                currentPlacardCollectionViewCellColumnCount--;
            }

            if (currentPlacardCollectionViewCellColumnCount <= 0)
            {
                currentPlacardCollectionViewCellColumnCount = 1;
            }

            var collectionViewCellWidth = (PlacardOverviewCollectionView.Width - ((currentPlacardCollectionViewCellColumnCount - 1) * 10)) / currentPlacardCollectionViewCellColumnCount;

            var collectionViewCellHeight = collectionViewCellWidth + (collectionViewCellWidth * 0.20);

            var availableVerticalHeight = PlacardOverviewCollectionView.Height;

            var rowCount = 0;

            while (availableVerticalHeight > 0)
            {
                rowCount++;

                availableVerticalHeight -= collectionViewCellHeight + 10;
            }

            placardPageLimit = currentPlacardCollectionViewCellColumnCount * rowCount;
        }

        private void UpdatePlacardOverviewLoadByScrollContext(Xamarin.Forms.ItemsViewScrolledEventArgs scrollEventArgs)
        {
            if (scrollEventArgs.FirstVisibleItemIndex < 0 || scrollEventArgs.LastVisibleItemIndex < 0) return;

            if (scrollEventArgs.FirstVisibleItemIndex > 0)
            {
                for (int index = 0; index < scrollEventArgs.FirstVisibleItemIndex; index++)
                {
                    if (BindingContextPageModel.Items == null || BindingContextPageModel.Items.Count <= index) return;

                    BindingContextPageModel.Items.ElementAtOrDefault(index)?.ReleasePlacardModel();
                }
            }

            if (BindingContextPageModel.Items == null) return;

            var loadToEnd = BindingContextPageModel.Items.Count - scrollEventArgs.LastVisibleItemIndex - 1 <= currentPlacardCollectionViewCellColumnCount * 2;

            var effectiveLastVisibleItemIndex = loadToEnd ? BindingContextPageModel.Items.Count - 1 : scrollEventArgs.LastVisibleItemIndex + (currentPlacardCollectionViewCellColumnCount * 2);

            for (int index = scrollEventArgs.FirstVisibleItemIndex; index <= effectiveLastVisibleItemIndex; index++)
            {
                if (BindingContextPageModel.Items == null || BindingContextPageModel.Items.Count <= index) return;

                BindingContextPageModel.Items.ElementAt(index).LoadPlacardModel();
            }

            // TODO Find a better way to handle scrollEventArgs values for UWP
            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.UWP) return;

            if (loadToEnd) return;

            if (BindingContextPageModel.Items == null) return;

            if (effectiveLastVisibleItemIndex < BindingContextPageModel.Items.Count - 1)
            {
                for (int index = effectiveLastVisibleItemIndex + 1; index < BindingContextPageModel.Items.Count; index++)
                {
                    if (BindingContextPageModel.Items == null || BindingContextPageModel.Items.Count <= index) break;

                    BindingContextPageModel.Items.ElementAtOrDefault(index)?.ReleasePlacardModel();
                }
            }
        }
    }
}