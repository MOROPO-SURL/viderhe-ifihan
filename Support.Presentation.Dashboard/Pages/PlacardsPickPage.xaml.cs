using SmartSolucionesCuba.Viderhe.Support.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Pages
{
    public partial class PlacardsPickPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.PlacardsPickPageModel>
    {
        private System.Action<Models.View.PlacardOverviewViewModel[]> placardsSelectedCallbackAction;
        private Cloud.Api.Common.Models.Filter.PlacardFilterModel filter;
        private int limit;

        private Cloud.Api.Common.Models.PlacardDisplayModel[] rawPlacards;
        private int currentItemsPageNumber;

        public PlacardsPickPage(System.Action<Models.View.PlacardOverviewViewModel[]> placardsSelectedCallbackAction, int limit = 25) : this(placardsSelectedCallbackAction, null, limit) { }

        public PlacardsPickPage(System.Action<Models.View.PlacardOverviewViewModel[]> placardsSelectedCallbackAction, Cloud.Api.Common.Models.Filter.PlacardFilterModel filter = null, int limit = 25)
            : base(new Models.Page.PlacardsPickPageModel { IsBusy = true })
        {
            InitializeComponent();

            this.placardsSelectedCallbackAction = placardsSelectedCallbackAction;
            this.filter = filter;
            this.limit = limit;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (rawPlacards != null) return;

            LoadNextItemsPage(true);
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
            if (!restart)
            {
                PresentNextItemsPage();

                return;
            }

            BindingContextPageModel.IsBusy = true;

            var placardsApiConnectClient = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            currentItemsPageNumber = 0;

            var requestTask = placardsApiConnectClient.GetAsync();

            if (filter != null) requestTask = placardsApiConnectClient.FilterAsync(filter);

            requestTask.ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        Xamarin.Forms.DependencyService.Get<Presentation.Helpers.Facade.IExceptionHandleHelperFacade>().HandleException(task.Exception, () =>
                        {
                            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => this.NavigationPopPageAsync());
                        });
                    }
                    else
                    {
                        rawPlacards = task.Result;

                        PresentNextItemsPage();
                    }
                });
            });
        }

        private void PresentNextItemsPage()
        {
            currentItemsPageNumber++;

            if (currentItemsPageNumber == 1)
            {
                BindingContextPageModel.SelectablePlacards.Clear();
            }

            var targetPlacads = rawPlacards.Skip((currentItemsPageNumber - 1) * limit).Take(limit);

            foreach (var item in targetPlacads)
            {
                BindingContextPageModel.SelectablePlacards.Add(new Models.View.SelectableModelViewModel<Models.View.PlacardOverviewViewModel> { Model = new Models.View.PlacardOverviewViewModel(item.ToViewModel(), true) });
            }

            BindingContextPageModel.HasMoreImages = currentItemsPageNumber < (rawPlacards.Length / limit);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            placardsSelectedCallbackAction = null;
            filter = null;
        }
    }
}