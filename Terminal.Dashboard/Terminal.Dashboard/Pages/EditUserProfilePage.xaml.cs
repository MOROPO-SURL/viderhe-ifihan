using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class EditUserProfilePage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.EditUserProfilePageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private System.Action successCallbackAction;

        private bool hasChangesFlag;
        private byte[] imagePickedData;

        public EditUserProfilePage(System.Action successCallbackAction) : base(new Models.Page.EditUserProfilePageModel
        {
            TargetUserId = Managers.SessionManager.Instance.Moderator.User.Id,
            TargetIdentityName = Managers.SessionManager.Instance.Moderator.Identity.Name,
            TargetIdentityLastName = Managers.SessionManager.Instance.Moderator.Identity.LastName,
            TargetIdentityImageSource = Managers.SessionManager.Instance.Moderator.Identity.Image != null ?
                Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(Managers.SessionManager.Instance.Moderator.Identity.Image.Id)) :
                Xamarin.Forms.ImageSource.FromUri(new System.Uri(Helpers.ConstantProvisioningHelper.Instance.FallbackUserProfileImageUrl)),
            TargetIdentitySex = Managers.SessionManager.Instance.Moderator.Identity.Sex,
            TargetIdentityAbout = Managers.SessionManager.Instance.Moderator.Identity.About
        })
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            this.successCallbackAction = successCallbackAction;

            InitializeComponent();

            BindingContextPageModel.PropertyChanged += PageModel_PropertyChanged;
        }

        protected override bool OnBackButtonPressed()
        {
            CancelToolbarItem_Clicked(this, System.EventArgs.Empty);

            return true;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            imagePickedData = null;
            successCallbackAction = null;
        }

        private void PageModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            hasChangesFlag = true;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (!hasChangesFlag && !SetPasswordSwitch.IsToggled)
            {
                this.NavigationPopPageAsync();

                return;
            }

            BindingContextPageModel.ResetValidationState();

            foreach (var validationBehavior in validationBehaviors)
            {
                var result = validationBehavior.Evaluate();

                if (!BindingContextPageModel.IsValid) continue;

                if (!result) BindingContextPageModel.IsValid = false;
            }

            if (!BindingContextPageModel.IsValid) return;

            BindingContextPageModel.IsBusy = true;

            var client = new Cloud.Api.Connect.Clients.ModeratorsApiConnectClient(Managers.SessionManager.Instance);

            var model = new Cloud.Api.Common.Models.ModeratorInputModel
            {
                Id = Managers.SessionManager.Instance.Moderator.Id,
                IsPrivileged = Managers.SessionManager.Instance.Moderator.IsPrivileged,
                User = new Cloud.Api.Common.Models.UserInputModel
                {
                    Id = Managers.SessionManager.Instance.Moderator.User.Id,
                    Enabled = Managers.SessionManager.Instance.Moderator.User.Enabled,
                    PasswordChangeRequired = Managers.SessionManager.Instance.Moderator.User.PasswordChangeRequired,
                    NewPassword = BindingContextPageModel.TargetUserNewPassword
                },
                Identity = new Cloud.Api.Common.Models.PersonIdentityInputModel
                {
                    Id = Managers.SessionManager.Instance.Moderator.Identity.Id,
                    Name = BindingContextPageModel.TargetIdentityName,
                    LastName = BindingContextPageModel.TargetIdentityLastName,
                    Sex = BindingContextPageModel.TargetIdentitySex
                }
            };

            if (imagePickedData != null)
            {
                model.Identity.Image = new Cloud.Api.Common.Models.ImageInputModel
                {
                    ContentData = imagePickedData,
                    ContentType = BindingContextPageModel.TargetIdentityImageContentType
                };
            }

            client.EditAsync(model).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception == null && !task.IsCanceled)
                    {
                        Managers.SessionManager.Instance.Moderator.Identity.Name = BindingContextPageModel.TargetIdentityName;
                        Managers.SessionManager.Instance.Moderator.Identity.LastName = BindingContextPageModel.TargetIdentityLastName;
                        Managers.SessionManager.Instance.Moderator.Identity.Sex = BindingContextPageModel.TargetIdentitySex;

                        Xamarin.Forms.DependencyService.Get<Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade>().PresentNotification("Información", string.Format("Cambios aplicados con éxito.{0}{0}Algunos cambios se mostrarán en le próximo inicio de sesión.", System.Environment.NewLine));

                        this.NavigationPopPageAsync();

                        successCallbackAction.Invoke();
                    }
                    else
                    {
                        BindingContextPageModel.IsBusy = false;

                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                });
            });
        }

        private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (!hasChangesFlag)
            {
                this.NavigationPopPageAsync();

                return;
            }

            DisplayAlert("Confirmar", "Está seguro que desea regresar sin guardar los cambios?", "Regresar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    this.NavigationPopPageAsync();
                });
            });
        }

        private async void PickImageActionableView_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (!Xamarin.Essentials.MediaPicker.IsCaptureSupported) PresentForImagePick();

            var action = await DisplayActionSheet("Seleccionar Imágen de Perfil desde", "Cancelar", null, Helpers.ConstantProvisioningHelper.ACTIONSHEET_PICKIMAGE_OPTION_CAMARA, Helpers.ConstantProvisioningHelper.ACTIONSHEET_PICKIMAGE_OPTION_GALLERY);

            if (action == Helpers.ConstantProvisioningHelper.ACTIONSHEET_PICKIMAGE_OPTION_CAMARA)
            {
                var permission = await Xamarin.Essentials.Permissions.CheckStatusAsync<Xamarin.Essentials.Permissions.Camera>();

                if (permission != Xamarin.Essentials.PermissionStatus.Granted)
                {
                    permission = await Xamarin.Essentials.Permissions.RequestAsync<Xamarin.Essentials.Permissions.Camera>();
                }

                if (permission != Xamarin.Essentials.PermissionStatus.Granted)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Aviso", string.Format("El permiso para acceder a cámara del dispositivo es necesario para esta funcionalidad.{0}{0}Deberá permitir el acceso en los ajustes del sistema para la aplicación.", System.Environment.NewLine), "Aceptar");

                        BindingContextPageModel.IsBusy = false;
                        BindingContextPageModel.BusyProgressMessage = string.Empty;
                    });

                    return;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = true;
                    BindingContextPageModel.BusyProgressMessage = "Capturando imagen para el perfil ...";
                });

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(1)).ContinueWith(delayTask =>
                    {
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            BindingContextPageModel.BusyProgressMessage = "Preparando imagen para recortar ...";
                        });
                    });
                });

                await Xamarin.Essentials.MediaPicker.CapturePhotoAsync().ContinueWith(PickedImageContinuationTask);
            }
            else if (action == Helpers.ConstantProvisioningHelper.ACTIONSHEET_PICKIMAGE_OPTION_GALLERY)
            {
                PresentForImagePick();
            }
        }

        private void PickedImageCroppingComplete_Callback(SkiaSharp.SKBitmap result)
        {
            if (result != null)
            {
                using (var skImage = SkiaSharp.SKImage.FromBitmap(result))
                {
                    using (var skData = skImage.Encode(SkiaSharp.SKEncodedImageFormat.Jpeg, 75))
                    {
                        imagePickedData = skData.ToArray();
                    }
                }

                result.Dispose();

                BindingContextPageModel.TargetIdentityImageSource = Xamarin.Forms.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedData));
            }

            this.NavigationPopModalPageAsync();

            BindingContextPageModel.IsBusy = false;
            BindingContextPageModel.BusyProgressMessage = string.Empty;
        }

        private async void PresentForImagePick()
        {
            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS)
            {
                var permission = await Xamarin.Essentials.Permissions.CheckStatusAsync<Xamarin.Essentials.Permissions.Photos>();

                if (permission != Xamarin.Essentials.PermissionStatus.Granted)
                {
                    permission = await Xamarin.Essentials.Permissions.RequestAsync<Xamarin.Essentials.Permissions.Photos>();
                }

                if (permission != Xamarin.Essentials.PermissionStatus.Granted)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Aviso", string.Format("El permiso para acceder a las fotos del dispositivo es necesario para esta funcionalidad.{0}{0}Deberá permitir el acceso en los ajustes del sistema para la aplicación.", System.Environment.NewLine), "Aceptar");

                        BindingContextPageModel.IsBusy = false;
                        BindingContextPageModel.BusyProgressMessage = string.Empty;
                    });

                    return;
                }
            }
            else
            {
                var permission = await Xamarin.Essentials.Permissions.CheckStatusAsync<Xamarin.Essentials.Permissions.StorageRead>();

                if (permission != Xamarin.Essentials.PermissionStatus.Granted)
                {
                    permission = await Xamarin.Essentials.Permissions.RequestAsync<Xamarin.Essentials.Permissions.StorageRead>();
                }

                if (permission != Xamarin.Essentials.PermissionStatus.Granted)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Aviso", string.Format("El permiso para acceder a las fotos del dispositivo es necesario para esta funcionalidad.{0}{0}Deberá permitir el acceso en los ajustes del sistema para la aplicación.", System.Environment.NewLine), "Aceptar");

                        BindingContextPageModel.IsBusy = false;
                        BindingContextPageModel.BusyProgressMessage = string.Empty;
                    });

                    return;
                }
            }

            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                BindingContextPageModel.IsBusy = true;
                BindingContextPageModel.BusyProgressMessage = "Seleccionando imagen para el perfil ...";
            });

            await Xamarin.Essentials.MediaPicker.PickPhotoAsync().ContinueWith(PickedImageContinuationTask);
        }

        private async System.Threading.Tasks.Task PickedImageContinuationTask(System.Threading.Tasks.Task<Xamarin.Essentials.FileResult> task)
        {
            if (task.Result == null)
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;
                    BindingContextPageModel.BusyProgressMessage = string.Empty;
                });

                return;
            }

            await System.Threading.Tasks.Task.Delay(System.TimeSpan.FromMilliseconds(100));

            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                BindingContextPageModel.BusyProgressMessage = "Preparando imagen para recortar ...";
            });

            SkiaSharp.SKBitmap croppingImageTarget = null;

            using (var imageFileStream = await task.Result.OpenReadAsync())
            {
                using (var skStream = new SkiaSharp.SKManagedStream(imageFileStream))
                {
                    croppingImageTarget = SkiaSharp.SKBitmap.Decode(skStream);
                }
            }

            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                BindingContextPageModel.TargetIdentityImageContentType = task.Result.ContentType;
                BindingContextPageModel.BusyProgressMessage = "Recortando imagen ...";

                this.NavigationPushModalPageAsync(new Xamarin.Forms.NavigationPage(new UserProfileImageCroppingPage(croppingImageTarget, PickedImageCroppingComplete_Callback)));
            });
        }

        #region IValidableFormPage implementation

        public void AddValidationBehavior(Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Add(validationBehavior);
        }

        public void RemoveValidationBehavior(Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior validationBehavior)
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
    }
}