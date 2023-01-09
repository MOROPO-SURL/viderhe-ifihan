using SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Pages
{
    public partial class PlacardsPickPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.PlacardsPickPageModel>
    {
        private System.Action<Models.View.PlacardOverviewViewModel[]> placardsSelectedCallbackAction;

        private int currentImagesPageNumber;

        public PlacardsPickPage(System.Action<Models.View.PlacardOverviewViewModel[]> placardsSelectedCallbackAction)
            : base(new Models.Page.PlacardsPickPageModel { IsBusy = true })
        {
            InitializeComponent();

            this.placardsSelectedCallbackAction = placardsSelectedCallbackAction;

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            LoadNextItemsPage(true);

            IsEnabled = true;
        }

        private void ApplyToolbarItem_Activated(object sender, System.EventArgs e)
        {
            placardsSelectedCallbackAction.Invoke(BindingContextPageModel.SelectablePlacards.Where(m => m.Selected).Select(m => m.Model).ToArray());

            this.NavigationPopPageAsync();
        }

        private void CancelToolbarItem_Activated(object sender, System.EventArgs e)
        {
            this.NavigationPopPageAsync();
        }

        private void SelectionToggleLabelTapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            ((sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.SelectableModelViewModel<Models.View.PlacardOverviewViewModel>).Selected = !((sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.SelectableModelViewModel<Models.View.PlacardOverviewViewModel>).Selected;
        }

        private void LoadNextPageButtton_Clicked(object sender, System.EventArgs eventArgs)
        {
            LoadNextItemsPage();
        }

        private void LoadNextItemsPage(bool restart = false)
        {
            BindingContextPageModel.IsBusy = true;

            if (restart) currentImagesPageNumber = 0;

            var placardsApiConnectClient = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            placardsApiConnectClient.GetPaginateAsync(++currentImagesPageNumber).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        Xamarin.Forms.DependencyService.Get<Presentation.Helpers.Facade.IExceptionHandleHelperFacade>().HandleException(task.Exception);
                    }
                    else
                    {
                        var relevantImages = task.Result.List.Select(item => new Models.View.PlacardOverviewViewModel(item.ToViewModel(), true)).Select(item => new Models.View.SelectableModelViewModel<Models.View.PlacardOverviewViewModel>
                        {
                            Model = item
                        });

                        if (currentImagesPageNumber == 1)
                        {
                            BindingContextPageModel.SelectablePlacards.Clear();
                        }

                        foreach (var item in relevantImages)
                        {
                            BindingContextPageModel.SelectablePlacards.Add(item);
                        }

                        BindingContextPageModel.HasMoreImages = task.Result.HasNext && task.Result.List.Count > 0;
                    }
                });
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            placardsSelectedCallbackAction = null;
        }
    }
}