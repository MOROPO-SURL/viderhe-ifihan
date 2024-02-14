using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Pages
{
    public partial class AVProductionImagesDefinitionPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.AVProductionImagesDefinitionPageModel>
    {
        private System.Action definitionCallbackAction;

        public AVProductionImagesDefinitionPage(System.Action definitionCallbackAction, Service.Hotel.OTT.API.Common.Models.AVProductionDisplayModel target) 
            : base(Factories.AVProductionImagesDefinitionPageModelFactory.Build(target))
        {
            InitializeComponent();

            this.definitionCallbackAction = definitionCallbackAction;
        }

        protected override bool OnBackButtonPressed()
        {
            var rootPage = Parent as AVProductionModificationTabbedPage;

            rootPage.CurrentPage = rootPage.Children[0];

            return true;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            definitionCallbackAction = null;
        }

        private async void PickPosterImageButton_Clicked(object sender, System.EventArgs eventArgs)
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

            await Xamarin.Essentials.MediaPicker.PickPhotoAsync().ContinueWith(PickedPosterImageContinuationTask);
        }

        private async void PickPlacardImageButton_Clicked(object sender, System.EventArgs eventArgs)
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

            await Xamarin.Essentials.MediaPicker.PickPhotoAsync().ContinueWith(PickedPlacardImageContinuationTask);
        }

        private async System.Threading.Tasks.Task PickedPosterImageContinuationTask(System.Threading.Tasks.Task<Xamarin.Essentials.FileResult> task)
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
                BindingContextPageModel.BusyProgressMessage = "Preparando imagen ...";
            });

            SkiaSharp.SKBitmap croppingImageTarget = null;

            using (var imageFileStream = await task.Result.OpenReadAsync())
            {
                using (var skStream = new SkiaSharp.SKManagedStream(imageFileStream))
                {
                    croppingImageTarget = SkiaSharp.SKBitmap.Decode(skStream);
                }
            }

            using (var skImage = SkiaSharp.SKImage.FromBitmap(croppingImageTarget))
            {
                using (var skData = skImage.Encode(SkiaSharp.SKEncodedImageFormat.Jpeg, 75))
                {
                    var currentImageSource = BindingContextPageModel.PosterImageSource;

                    var imagePickedData = skData.ToArray();

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        BindingContextPageModel.PosterImageSource = Xamarin.Forms.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedData));

                        BindingContextPageModel.IsBusy = false;
                        BindingContextPageModel.BusyProgressMessage = string.Empty;

                        DisplayAlert("Confirmar", "Está seguro que desea aplicar estos cambios para el poster de la producción?", "Aplicar", "Cancelar").ContinueWith(_task =>
                        {
                            if (!_task.Result)
                            {
                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    BindingContextPageModel.PosterImageSource = currentImageSource;

                                    currentImageSource = null;
                                });

                                return;
                            }

                            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => BindingContextPageModel.IsBusy = true);

                            var model = new Service.Hotel.OTT.API.Common.Models.ImageInputModel
                            {
                                Id = BindingContextPageModel.PosterImageId,
                                Content = imagePickedData,
                                Extension = "jpg"
                            };

                            imagePickedData = null;

                            var apiConnectClient = new Service.Hotel.OTT.API.Connect.Clients.AVProductionsAPIConnectClient(Managers.SessionManager.Instance);

                            var apiConnectClientTask = apiConnectClient.EditImagePosterAsync(BindingContextPageModel.Id, model);

                            apiConnectClientTask.ContinueWith(__task =>
                            {
                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    if (task.Exception == null && !__task.IsCanceled)
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
                        });
                    });
                }
            }

            croppingImageTarget.Dispose();
        }

        private async System.Threading.Tasks.Task PickedPlacardImageContinuationTask(System.Threading.Tasks.Task<Xamarin.Essentials.FileResult> task)
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
                BindingContextPageModel.BusyProgressMessage = "Preparando imagen ...";
            });

            SkiaSharp.SKBitmap croppingImageTarget = null;

            using (var imageFileStream = await task.Result.OpenReadAsync())
            {
                using (var skStream = new SkiaSharp.SKManagedStream(imageFileStream))
                {
                    croppingImageTarget = SkiaSharp.SKBitmap.Decode(skStream);
                }
            }

            using (var skImage = SkiaSharp.SKImage.FromBitmap(croppingImageTarget))
            {
                using (var skData = skImage.Encode(SkiaSharp.SKEncodedImageFormat.Jpeg, 75))
                {
                    var currentImageSource = BindingContextPageModel.PlacardImageSource;

                    var imagePickedData = skData.ToArray();

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        BindingContextPageModel.PlacardImageSource = Xamarin.Forms.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedData));

                        BindingContextPageModel.IsBusy = false;
                        BindingContextPageModel.BusyProgressMessage = string.Empty;

                        DisplayAlert("Confirmar", "Está seguro que desea aplicar estos cambios para el cartel de la producción?", "Aplicar", "Cancelar").ContinueWith(_task =>
                        {
                            if (!_task.Result)
                            {
                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    BindingContextPageModel.PlacardImageSource = currentImageSource;

                                    currentImageSource = null;
                                });

                                return;
                            }

                            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => BindingContextPageModel.IsBusy = true);

                            var model = new Service.Hotel.OTT.API.Common.Models.ImageInputModel
                            {
                                Id = BindingContextPageModel.PlacardImageId,
                                Content = imagePickedData,
                                Extension = "jpg"
                            };

                            imagePickedData = null;

                            var apiConnectClient = new Service.Hotel.OTT.API.Connect.Clients.AVProductionsAPIConnectClient(Managers.SessionManager.Instance);

                            var apiConnectClientTask = apiConnectClient.EditImagePlacardAsync(BindingContextPageModel.Id, model);

                            apiConnectClientTask.ContinueWith(__task =>
                            {
                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    if (task.Exception == null && !__task.IsCanceled)
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
                        });
                    });
                }
            }

            croppingImageTarget.Dispose();
        }
    }
}