using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages
{
    public partial class GradientPickPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.GradientPickPageModel>
    {
        private System.Action<GradientViewModel> itemPickedCallbackAction;

        private GradientViewModel except;
        
        private int currentItemsPageNumber;
        private int currentGradientCollectionViewCellColumnCount = 3;
        private int pagingLimit = 15;

        public GradientPickPage(System.Action<GradientViewModel> itemPickedCallbackAction, GradientViewModel except = null)
            : base(new Models.Page.GradientPickPageModel())
        {
            InitializeComponent();

            this.itemPickedCallbackAction = itemPickedCallbackAction;
            this.except = except;
        }

        private void ItemPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.IsBusy = true;

            var targetModel = (sender as Xamarin.Forms.BindableObject).BindingContext as OverviewViewModel<GradientViewModel>;

            itemPickedCallbackAction.Invoke(targetModel.Presented);

            this.NavigationPopPageAsync();
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

            var apiConnectClient = new Cloud.Api.Connect.Clients.GradientsApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            apiConnectClient.GetPaginateAsync(++currentItemsPageNumber, pagingLimit).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null)
                    {
                        Xamarin.Forms.DependencyService.Get<IExceptionHandleHelperFacade>().HandleException(task.Exception);
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

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            itemPickedCallbackAction = null;
            except = null;
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