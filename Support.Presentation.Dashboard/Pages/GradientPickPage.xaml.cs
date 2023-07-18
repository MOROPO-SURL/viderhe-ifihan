using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Pages
{
    public partial class GradientPickPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.GradientPickPageModel>
    {
        private System.Action<Models.View.GradientViewModel> itemPickedCallbackAction;

        private Models.View.GradientViewModel except;
        
        private int currentItemsPageNumber;

        public GradientPickPage(System.Action<Models.View.GradientViewModel> itemPickedCallbackAction, Models.View.GradientViewModel except = null)
            : base(new Models.Page.GradientPickPageModel
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

            var targetModel = (sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.GradientViewModel;

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

            var apiConnectClient = new Cloud.Api.Connect.Clients.GradientsApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            apiConnectClient.GetPaginateAsync(++currentItemsPageNumber).ContinueWith(task =>
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
                            if (except != null && except.Id == item.Id) continue;

                            BindingContextPageModel.Items.Add(new Models.View.GradientViewModel
                            {
                                Id = item.Id,
                                About = item.About,
                                Source = MagicGradients.CssGradientSource.Parse(item.Data),
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