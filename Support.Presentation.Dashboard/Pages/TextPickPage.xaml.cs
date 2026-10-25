using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages
{
    public partial class TextPickPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<TextPickPageModel>
    {
        private System.Action<TextViewModel> itemPickedCallbackAction;

        private int currentItemsPageNumber;

        public TextPickPage(System.Action<TextViewModel> itemPickedCallbackAction)
            : base(new TextPickPageModel
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

            var targetModel = (sender as Xamarin.Forms.BindableObject).BindingContext as TextViewModel;

            itemPickedCallbackAction.Invoke(targetModel);

            this.NavigationPopPageAsync();
        }

        private void LoadNextPageButtton_Clicked(object sender, System.EventArgs eventArgs)
        {
            LoadNextItemsPage();
        }

        private void LoadNextItemsPage(bool restart = false)
        {
            BindingContextPageModel.IsBusy = true;

            if (restart) currentItemsPageNumber = 0;

            var apiConnectClient = new Cloud.Api.Connect.Clients.TextsApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            apiConnectClient.GetPaginateAsync(++currentItemsPageNumber).ContinueWith(task =>
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
                            BindingContextPageModel.Items.Add(new TextViewModel
                            {
                                Id = item.Id,
                                About = item.About,
                                Content = item.Content,
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