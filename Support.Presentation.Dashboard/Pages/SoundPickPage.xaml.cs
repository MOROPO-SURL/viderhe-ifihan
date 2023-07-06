using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Pages
{
    public partial class SoundPickPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.SoundPickPageModel>
    {
        private System.Action<Models.View.SoundViewModel> itemPickedCallbackAction;

        private int currentItemsPageNumber;

        public SoundPickPage(System.Action<Models.View.SoundViewModel> itemPickedCallbackAction)
            : base(new Models.Page.SoundPickPageModel
            {
                IsBusy = true
            })
        {
            InitializeComponent();

            this.itemPickedCallbackAction = itemPickedCallbackAction;

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            LoadNextItemsPage(true);

            IsEnabled = true;
        }

        private void ItemPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.IsBusy = true;

            var targetModel = (sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.SoundViewModel;

            itemPickedCallbackAction.Invoke(targetModel);

            this.NavigationPopPageAsync();
        }

        private void ItemPlayButton_Clicked(object sender, System.EventArgs eventArgs)
        {

        }

        private void LoadNextPageButtton_Clicked(object sender, System.EventArgs eventArgs)
        {
            LoadNextItemsPage();
        }

        private void LoadNextItemsPage(bool restart = false)
        {
            BindingContextPageModel.IsBusy = true;

            if (restart) currentItemsPageNumber = 0;

            var apiConnectClient = new Cloud.Api.Connect.Clients.SoundsApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper);

            apiConnectClient.GetPageAsync(++currentItemsPageNumber).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null)
                    {
                        Xamarin.Forms.DependencyService.Get<Presentation.Helpers.Facade.IExceptionHandleHelperFacade>().HandleException(task.Exception);
                    }
                    else
                    {
                        if (currentItemsPageNumber == 1)
                        {
                            BindingContextPageModel.Items.Clear();
                        }

                        foreach (var item in task.Result.List)
                        {
                            BindingContextPageModel.Items.Add(new Models.View.SoundViewModel
                            {
                                Id = item.Id,
                                About = item.About,
                                Extension = item.Extension,
                                AudioChannelOutput = item.AudioChannelOutput,
                                AudioFormat = item.AudioFormat,
                                Duration = item.Duration,
                                Length = item.Length,
                                ThumbnailId = item.ThumbnailId,
                                CreateAt = item.CreateAt
                            });
                        }

                        BindingContextPageModel.HasMoreItems = task.Result.HasNext && task.Result.List.Count > 0;
                    }
                });
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            itemPickedCallbackAction = null;
        }
    }
}