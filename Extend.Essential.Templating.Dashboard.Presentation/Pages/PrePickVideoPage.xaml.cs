using SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Models.View;
using SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Support.Presentation.Models.View;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Pages
{
    public partial class PrePickVideoPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Support.Presentation.Dashboard.Models.Page.VideoPickPageModel>
    {
        private Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor;
        private System.Action successfulCompleteCallbackAction;
        private System.Action<VideoViewModel, Common.Templating.Descriptors.ITemplateDescriptor, System.Action> videoPickedCallbackAction;

        private int currentVideosPageNumber;
        private int currentVideoCollectionViewCellColumnCount = 3;
        private int pagingLimit = 15;

        public PrePickVideoPage(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action successfulCompleteCallbackAction, System.Action<Support.Presentation.Models.View.VideoViewModel, Common.Templating.Descriptors.ITemplateDescriptor, System.Action> videoPickedCallbackAction)
            : base(new Support.Presentation.Dashboard.Models.Page.VideoPickPageModel())
        {
            InitializeComponent();

            this.templateDescriptor = templateDescriptor;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;
            this.videoPickedCallbackAction = videoPickedCallbackAction;
        }

        private void VideoOverviewPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var targetModel = (sender as Xamarin.Forms.BindableObject).BindingContext as OverviewViewModel<VideoViewModel>;

            videoPickedCallbackAction.Invoke(targetModel.Presented, templateDescriptor, OnSuccessfulComplete);
        }

        private void VideoOverviewDetailButton_Clicked(object sender, System.EventArgs e)
        {
            var targetModel = (sender as Xamarin.Forms.BindableObject).BindingContext as OverviewViewModel<VideoViewModel>;

            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.VideoDetailPage(targetModel.Presented));
        }

        private void OnSuccessfulComplete()
        {
            this.NavigationPopPageAsync();

            successfulCompleteCallbackAction.Invoke();
        }

        private void LoadNextPageButtton_Clicked(object sender, System.EventArgs eventArgs)
        {
            LoadNextVideosPage();
        }

        private void VideoCollectionWrapperStackLayout_SizeChanged(object sender, System.EventArgs eventArgs)
        {
            if (VideoCollectionView.Width < 0 || VideoCollectionView.Height < 0) return;

            if (BindingContextPageModel.IsBusy) return;

            LoadNextVideosPage(true);
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

        private void LoadNextVideosPage(bool restart = false)
        {
            BindingContextPageModel.IsBusy = true;

            if (restart)
            {
                CalculateCollectionPagingMetrics();

                currentVideosPageNumber = 0;

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

            var videosApiConnectClient = new Cloud.Api.Connect.Clients.VideosApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper);

            videosApiConnectClient.GetPageAsync(++currentVideosPageNumber, pagingLimit).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null)
                    {
                        Xamarin.Forms.DependencyService.Get<Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade>().HandleException(task.Exception);
                    }
                    else
                    {
                        if (currentVideosPageNumber == 1)
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
                            BindingContextPageModel.Items.Add(new OverviewViewModel<VideoViewModel>(item.ToViewModel()));
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

            templateDescriptor = null;
            successfulCompleteCallbackAction = null;
            videoPickedCallbackAction = null;
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