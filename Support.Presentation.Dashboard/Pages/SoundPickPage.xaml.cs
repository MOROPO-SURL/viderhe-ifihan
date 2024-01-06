using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages
{
    public partial class SoundPickPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<SoundPickPageModel>
    {
        private System.Action<SoundViewModel> itemPickedCallbackAction;

        private SoundViewModel except;

        private int currentItemsPageNumber;

        public SoundPickPage(System.Action<SoundViewModel> itemPickedCallbackAction, SoundViewModel except = null)
            : base(new SoundPickPageModel
            {
                IsBusy = true
            })
        {
            InitializeComponent();

            this.itemPickedCallbackAction = itemPickedCallbackAction;
            this.except = except;

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

            var targetModel = (sender as Xamarin.Forms.BindableObject).BindingContext as SoundViewModel;

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

            var apiConnectClient = new Cloud.Api.Connect.Clients.SoundsApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>().HttpClientHelper);

            apiConnectClient.GetPageAsync(++currentItemsPageNumber).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null)
                    {
                        Xamarin.Forms.DependencyService.Get<IExceptionHandleHelperFacade>().HandleException(task.Exception);
                    }
                    else
                    {
                        if (currentItemsPageNumber == 1)
                        {
                            BindingContextPageModel.Items.Clear();
                        }

                        foreach (var item in task.Result.List)
                        {
                            if (except != null && except.Id == item.Id) continue;

                            BindingContextPageModel.Items.Add(new SoundViewModel
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
            except = null;
        }
    }
}