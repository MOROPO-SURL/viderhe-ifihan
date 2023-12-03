using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Managers;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Models.Page;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Pages
{
    public partial class ApiKeysManagementPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<ApiKeysManagementPageModel>
    {
        public ApiKeysManagementPage() : base(new ApiKeysManagementPageModel())
        {
            InitializeComponent();

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            IsEnabled = true;

            LoadItems();
        }

        private void AddToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            if (BindingContextPageModel.IsBusy) return;

            this.NavigationPushPageAsync(new ApiKeyDefinitionPage(ReloadItems));
        }

        private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            ReloadItems();
        }

        private void ItemTapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            BindingContextPageModel.Target = (sender as Xamarin.Forms.BindableObject).BindingContext as Service.ECASA.CMG.InterFIDS.API.Common.Models.ApiKeyDisplayModel;

            ItemsCollectionView.SelectedItems.Clear();
        }

        private void CloseDetailPopupButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.Target = null;
        }

        private void TargetEditButton_Cliked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new ApiKeyDefinitionPage(ReloadItems, BindingContextPageModel.Target));
        }

        private void TargetRemoveButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(deleteAskTask =>
            {
                if (!deleteAskTask.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => BindingContextPageModel.IsBusy = true);

                var apiConnectClient = new Service.ECASA.CMG.InterFIDS.API.Connect.Backend.Clients.ApiKeysAPIConnectClient(SessionManager.Instance);

                apiConnectClient.Delete(BindingContextPageModel.Target.Id).ContinueWith(targetDeleteTask =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        BindingContextPageModel.IsBusy = false;

                        if (targetDeleteTask.Exception != null || targetDeleteTask.IsCanceled)
                        {
                            (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(deleteAskTask.Exception);
                        }
                        else
                        {
                            ReloadItems();
                        }
                    });
                });
            });
        }

        private void ReloadItems()
        {
            BindingContextPageModel.Target = null;

            LoadItems();
        }

        private void LoadItems()
        {
            BindingContextPageModel.IsBusy = true;

            BindingContextPageModel.Items?.Clear();

            var apiConnectClient = new Service.ECASA.CMG.InterFIDS.API.Connect.Backend.Clients.ApiKeysAPIConnectClient(SessionManager.Instance);

            apiConnectClient.GetAsync().ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);

                        this.NavigationPopPageAsync();
                    }
                    else
                    {
                        if (task.Result.Length > 0)
                        {
                            if (BindingContextPageModel.Items == null)
                            {
                                BindingContextPageModel.Items = new System.Collections.ObjectModel.ObservableCollection<Service.ECASA.CMG.InterFIDS.API.Common.Models.ApiKeyDisplayModel>(task.Result);
                            }
                            else
                            {
                                foreach (var model in task.Result)
                                {
                                    BindingContextPageModel.Items.Add(model);
                                }
                            }
                        }
                        else
                        {
                            BindingContextPageModel.Items = null;
                        }
                    }

                    BindingContextPageModel.IsBusy = false;
                });
            });
        }
    }
}