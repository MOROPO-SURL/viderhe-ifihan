using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Behaviors.Contract;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages.Contract;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Terminal.Dashboard.Factories;
using MOROPO.VIDERHE.Terminal.Dashboard.Managers;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.View;
using MOROPO.VIDERHE.Terminal.Dashboard.Pages.Contract;
using MOROPO.VIDERHE.Terminal.Dashboard.Providers;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Pages
{
    public partial class ConfigurePlayerPage :
        SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<ConfigurePlayerPageModel>,
        IValidableFormPage,
        IOverlayContextConfigurationPage
    {
        private readonly System.Collections.Generic.List<IFormFieldValidationBehavior> validationBehaviors;
        private readonly bool editing;

        private bool pageModelHasChanges;
        private PlayerViewModel model;
        private Extend.Common.Overlaying.Descriptors.IOverlayDescriptor recoverableOverlay;
        private string recoverableSerializedOverlayContext;

        private System.Action successCallbackAction;

        public ConfigurePlayerPage(System.Action successCallbackAction, PlayerViewModel model = null)
            : base(ConfigurePlayerPageModelFactory.Build(model))
        {
            validationBehaviors = new System.Collections.Generic.List<IFormFieldValidationBehavior>();

            InitializeComponent();

            this.model = model;
            this.successCallbackAction = successCallbackAction;

            editing = model != null;

            if (editing)
            {
                Title = "Modificar Reproductor";

                IdEntry.IsReadOnly = true;
            }
            else
            {
                Title = "Agregar Reproductor";

                ProgramRelaunchToolbarItem.IsEnabled = false;
            }

            BindingContextPageModel.PropertyChanged += PageModel_PropertyChanged;

            IsEnabled = false;

            recoverableOverlay = BindingContextPageModel.Overlay;
            recoverableSerializedOverlayContext = BindingContextPageModel.SerializedOverlayContext;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!IsEnabled)
            {
                IsEnabled = true;

                var client = new Cloud.Api.Connect.Clients.ScreenplaysApiConnectClient(SessionManager.Instance);

                client.GetPaginateAsync().ContinueWith(task =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        OverlayPicker.SelectedIndex = 0;

                        if (task.Exception != null || task.IsCanceled)
                        {
                            (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);

                            successCallbackAction = null;

                            this.NavigationPopPageAsync();
                        }
                        else
                        {
                            var found = false;
                            var index = -1;

                            foreach (var item in task.Result.List)
                            {
                                BindingContextPageModel.Screenplays.Add(item);

                                if (!found)
                                {
                                    index++;

                                    found = BindingContextPageModel.Screenplay != null && item.Id == BindingContextPageModel.Screenplay.Id;
                                }
                            }

                            if (found) ScreenplayPicker.SelectedIndex = index;

                            if (BindingContextPageModel.Overlay != null)
                            {
                                OverlayPicker.SelectedItem = BindingContextPageModel.Overlay;
                            }
                        }

                        BindingContextPageModel.IsBusy = false;

                        pageModelHasChanges = false;
                    });
                });
            }
        }

        protected override bool OnBackButtonPressed()
        {
            CancelToolbarItem_Activated(this, System.EventArgs.Empty);

            return true;
        }

        private void PageModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            pageModelHasChanges = true;
        }

        private void ScreenplayPicker_SelectedIndexChanged(object target, System.EventArgs eventArgs)
        {
            BindingContextPageModel.Screenplay = (target as Xamarin.Forms.Picker).SelectedItem as ScreenplayDisplayModel;
        }

        private void SelectedScreenplayClearButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            ScreenplayPicker.SelectedIndex = -1;
        }

        private void OverlayPicker_SelectedIndexChanged(object target, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel == null || BindingContextPageModel.IsBusy) return;

            BindingContextPageModel.Overlay = (target as Xamarin.Forms.Picker).SelectedItem as Extend.Common.Overlaying.Descriptors.IOverlayDescriptor;
            BindingContextPageModel.SerializedOverlayContext = null;

            if (BindingContextPageModel.Overlay == null) return;

            if (recoverableOverlay != null && BindingContextPageModel.Overlay.Id == recoverableOverlay.Id)
            {
                BindingContextPageModel.SerializedOverlayContext = recoverableSerializedOverlayContext;
            }

            if (BindingContextPageModel.SerializedOverlayContext == null)
            {
                BindingContextPageModel.SerializedOverlayContext = OverlayDefaultSerializedContextProvider.Instance.GetOverlayDefaultContextModel(BindingContextPageModel.Overlay);
            }
        }

        private void OverlayConfigureButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(OverlayConfigurationPageProvider.Instance.GetConfigurationPageByDescriptor(BindingContextPageModel.Overlay, BindingContextPageModel.SerializedOverlayContext, OverlayConfigurationSuccesfulComplete_Callback));
        }

        private void ApplyToolbarItem_Activated(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.ResetValidationState();

            foreach (var validationBehavior in validationBehaviors)
            {
                var result = validationBehavior.Evaluate();

                if (!BindingContextPageModel.IsValid) continue;

                if (!result) BindingContextPageModel.IsValid = false;
            }

            if (!BindingContextPageModel.IsValid) return;

            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(async () =>
            {
                var client = new Cloud.Api.Connect.Clients.PlayersApiConnectClient(SessionManager.Instance);

                var model = new PlayerInputModel
                {
                    Id = BindingContextPageModel.Id,
                    Name = BindingContextPageModel.Name,
                    About = BindingContextPageModel.About,
                    ScreenplayId = BindingContextPageModel.Screenplay?.Id ?? System.Guid.Empty,
                    OverlayId = BindingContextPageModel.Overlay?.Id ?? null,
                    SerializedOverlayContext = BindingContextPageModel.SerializedOverlayContext,
                    Tags = BindingContextPageModel.Tags.ToArray()
                };

                if (editing)
                {
                    await client.EditAsync(model);
                }
                else
                {
                    await client.CreateAsync(model);
                }
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception == null && !task.IsCanceled)
                    {
                        Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Cambios aplicados con éxito.");

                        this.NavigationPopPageAsync();
                    }
                    else
                    {
                        BindingContextPageModel.IsBusy = false;

                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                });
            });
        }

        private void CancelToolbarItem_Activated(object sender, System.EventArgs eventArgs)
        {
            if (!pageModelHasChanges)
            {
                this.NavigationPopPageAsync();

                return;
            }

            DisplayAlert("Confirmar", "Está seguro que desea regresar sin guardar los cambios?", "Regresar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    successCallbackAction = null;

                    this.NavigationPopPageAsync();
                });
            });
        }

        private void AddTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Support.Presentation.Dashboard.Pages.Popup.TagPickPopupPage(TagGroup.Player, PickTagSuccess_Callback, BindingContextPageModel.Tags.ToArray()));
        }

        private void RemoveTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Quitar Etiqueta", "Está seguro quitar esta etiqueta de este reproductor?", "Quitar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => BindingContextPageModel.Tags.Remove((sender as Xamarin.Forms.BindableObject).BindingContext as TagDisplayModel));
            });
        }

        private void ProgramRelaunchToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            this.NavigationPushPageAsync(new ManagePlayerScheduledRelaunchsPage(model));
        }

        private void PickTagSuccess_Callback(TagDisplayModel model)
        {
            BindingContextPageModel.Tags.Add(model);
        }

        private void OverlayConfigurationSuccesfulComplete_Callback(string serializedContext)
        {
            BindingContextPageModel.SerializedOverlayContext = serializedContext;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            BindingContextPageModel.PropertyChanged -= PageModel_PropertyChanged;

            successCallbackAction?.Invoke();

            successCallbackAction = null;
        }

        #region IValidableFormPage implementation

        public void AddValidationBehavior(IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Add(validationBehavior);
        }

        public void RemoveValidationBehavior(IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Remove(validationBehavior);
        }

        public void AddValidationMessage(string label, string message)
        {
            BindingContextPageModel.ValidationMessages.Add(new Support.Presentation.Dashboard.Models.View.ValidationMessageViewModel
            {
                Caption = label,
                Message = message
            });
        }

        #endregion

        #region IOverlayContextConfigurationPage implementation

        public string GetCurrentSerializedOverlayContext()
        {
            return BindingContextPageModel.SerializedOverlayContext;
        }

        #endregion
    }
}