using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Pages
{
    public partial class ChannelsManagementPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ChannelsManagementPageModel>
    {
        public ChannelsManagementPage() : base(new Models.Page.ChannelsManagementPageModel())
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadItems();
        }

        private void AddToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            if (BindingContextPageModel.IsBusy) return;

            this.NavigationPushPageAsync(new ChannelDefinitionPage(PersitenceChanges_Callback));
        }

        private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            LoadItems();
        }

        private void PersitenceChanges_Callback()
        {
            DisplayAlert("Aviso", "Cambios aplicados con éxito.", "Aceptar");
        }

        private void LoadItems()
        {
            BindingContextPageModel.IsBusy = true;

            BindingContextPageModel.Items.Clear();

            var apiConnectClient = new MOROPO.VIDERHE.Service.Hotel.OTT.API.Connect.Clients.ChannelsAPIConnectClient(Managers.SessionManager.Instance);

            apiConnectClient.GetAsync().ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        foreach (var model in task.Result)
                        {
                            BindingContextPageModel.Items.Add(model);
                        }
                    }
                });
            });
        }
    }
}