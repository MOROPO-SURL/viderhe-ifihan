using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Pages
{
    public partial class ChannelDefinitionPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ChannelDefinitionPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Action definitionCallbackAction;

        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private bool isEditionMode;
        private bool hasChangesFlag;
        private byte[] imagePickedData;

        public ChannelDefinitionPage(System.Action definitionCallbackAction, MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.ChannelDisplayModel target = null) : base(Factories.ChannelDefinitionPageModelFactory.Build(target))
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();

            this.definitionCallbackAction = definitionCallbackAction;

            BindingContextPageModel.PropertyChanged += PageModel_PropertyChanged;

            if (target != null)
            {
                isEditionMode = true;
                Title = "Modificar Canal Televisivo";
            }
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
        }

        private void PageModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            hasChangesFlag = true;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            if (!hasChangesFlag)
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

            var model = new MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.ChannelInputModel
            {
                Id = BindingContextPageModel.Id,
                Name = BindingContextPageModel.Name,
                Enabled = BindingContextPageModel.Enabled,
                Kind = BindingContextPageModel.Kind,
                Description = BindingContextPageModel.Description
            };

            if (imagePickedData != null)
            {
                model.FeatureImageContent = imagePickedData;
                model.FeatureImageContentType = BindingContextPageModel.FeatureImageExtension;
            }

            if (model.Kind == MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Enumerations.ChannelKind.RF)
            {
                model.SourceSerialization = BindingContextPageModel.RadioFrecuencyBand.ToString();
            }
            else
            {
                model.SourceSerialization = BindingContextPageModel.IPTVUrl.ToString();
            }

            var apiConnectClient = new MOROPO.VIDERHE.Service.Hotel.OTT.API.Connect.Clients.ChannelsAPIConnectClient(Managers.SessionManager.Instance);

            var apiConnectClientTask = isEditionMode ? apiConnectClient.EditAsync(model) : apiConnectClient.CreateAsync(model);

            apiConnectClientTask.ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception == null && !task.IsCanceled)
                    {
                        Xamarin.Forms.DependencyService.Get<Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade>().PresentNotification("Información", "Cambios aplicados con éxito.");

                        this.NavigationPopPageAsync();

                        definitionCallbackAction.Invoke();
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

        private async void PickImageButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (!Xamarin.Essentials.MediaPicker.IsCaptureSupported) PresentForImagePick();

            var action = await DisplayActionSheet("Seleccionar imágen desde", "Cancelar", null, ConstantProvisioningHelper.ACTIONSHEET_PICKIMAGE_OPTION_CAMARA, ConstantProvisioningHelper.ACTIONSHEET_PICKIMAGE_OPTION_GALLERY);

            if (action == ConstantProvisioningHelper.ACTIONSHEET_PICKIMAGE_OPTION_CAMARA)
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
                    BindingContextPageModel.BusyProgressMessage = "Capturando imagen ...";
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

                BindingContextPageModel.FeatureImageSource = Xamarin.Forms.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedData));
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
                BindingContextPageModel.BusyProgressMessage = "Seleccionando imagen ...";
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
                BindingContextPageModel.FeatureImageExtension = MimeTypes.MimeTypeMap.GetExtension(task.Result.ContentType);
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