using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Pages
{
    public partial class AccountIdentityConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.AccountIdentityConfigurationPageModel>
    {
        private bool pageModelHasChanges;

        private Plugin.FilePicker.Abstractions.FileData newLogoFileData;
        private Plugin.FilePicker.Abstractions.FileData newSplashFileData;

        public AccountIdentityConfigurationPage() : base(new Models.Page.AccountIdentityConfigurationPageModel
        {
            IsBusy = true
        })
        {
            InitializeComponent();

            BindingContextPageModel.PropertyChanged += PageModelPropertyChanged;

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!IsEnabled)
            {
                IsEnabled = true;

                var accountApiClient = new Cloud.Api.Connect.Clients.AccountApiClient(Managers.SessionManager.Instance);

                accountApiClient.GetCurrentAsync().ContinueWith(task =>
                {
                    if (task.Exception != null)
                    {
                        this.NavigationPopPageAsync();

                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        BindingContextPageModel.Name = task.Result.Name;
                        BindingContextPageModel.PrimaryColor = Xamarin.Forms.Color.FromHex(task.Result.PrimaryColor);
                        BindingContextPageModel.SecoundaryColor = Xamarin.Forms.Color.FromHex(task.Result.SecoundaryColor);
                        BindingContextPageModel.LogoImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(Providers.CloudServerProvider.Instance, task.Result.LogoImageId));
                        BindingContextPageModel.SplashImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(Providers.CloudServerProvider.Instance, task.Result.SplashImageId));

                        BindingContextPageModel.IsBusy = false;

                        Managers.SessionManager.Instance.SyncronizeRequiredAccountInformation(BindingContextPageModel.Name, BindingContextPageModel.PrimaryColor, BindingContextPageModel.SecoundaryColor, task.Result.LogoImageId, task.Result.SplashImageId);

                        pageModelHasChanges = false;
                    }
                });
            }
        }

        private void PageModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            pageModelHasChanges = true;
        }

        private void ApplyToolbarItem_Activated(object sender, System.EventArgs eventArgs)
        {
            if (!pageModelHasChanges)
            {
                this.NavigationPopPageAsync();

                return;
            }

            BindingContextPageModel.IsBusy = true;

            Managers.SessionManager.Instance.UpdateAccountInformationAsync(BindingContextPageModel.Name, BindingContextPageModel.PrimaryColor, BindingContextPageModel.SecoundaryColor, newLogoFileData, newSplashFileData).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception == null)
                    {
                        Presenters.NotificationPresenter.Instance.PresentNotification("Información", "Cambios aplicados con éxito.");

                        this.NavigationPopPageAsync();
                    }
                    else
                    {
                        BindingContextPageModel.IsBusy = false;

                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
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
                    this.NavigationPopPageAsync();
                });
            });
        }

        private void PickLogoImageButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            string[] fileSelector = null;

            switch (Xamarin.Forms.Device.RuntimePlatform)
            {
                case Xamarin.Forms.Device.Android:
                    fileSelector = new string[] { "image/*" };

                    break;

                case Xamarin.Forms.Device.UWP:
                    fileSelector = new string[] { ".jpg", ".jpeg", ".png", ".bmp" };

                    break;

                case Xamarin.Forms.Device.WPF:
                default:
                    fileSelector = new string[] { "Imágenes Soportadas|*.jpg;*.jpeg;*.png;*.bmp" };

                    break;
            }

            Plugin.FilePicker.CrossFilePicker.Current.PickFile(fileSelector).ContinueWith(task =>
            {
                if (task.Result == null) return;

                newLogoFileData = task.Result;

                var imageFormat = System.IO.Path.GetExtension(task.Result.FilePath).Substring(1).ToUpper();

                if (imageFormat.Equals("jpg", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    imageFormat = "JPEG";
                }

                using (var imageFileStream = task.Result.GetStream())
                {
                    var imageData = new byte[imageFileStream.Length];

                    imageFileStream.Read(imageData, 0, imageData.Length);

                    BindingContextPageModel.LogoImageSource = Xamarin.Forms.ImageSource.FromStream(() => new System.IO.MemoryStream(imageData));
                }
            });
        }

        private void PickSplashImageButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            string[] fileSelector = null;

            switch (Xamarin.Forms.Device.RuntimePlatform)
            {
                case Xamarin.Forms.Device.Android:
                    fileSelector = new string[] { "image/*" };

                    break;

                case Xamarin.Forms.Device.UWP:
                    fileSelector = new string[] { ".jpg", ".jpeg", ".png", ".bmp" };

                    break;

                case Xamarin.Forms.Device.WPF:
                default:
                    fileSelector = new string[] { "Imágenes Soportadas|*.jpg;*.jpeg;*.png;*.bmp" };

                    break;
            }

            Plugin.FilePicker.CrossFilePicker.Current.PickFile(fileSelector).ContinueWith(task =>
            {
                if (task.Result == null) return;

                newSplashFileData = task.Result;

                var imageFormat = System.IO.Path.GetExtension(task.Result.FilePath).Substring(1).ToUpper();

                if (imageFormat.Equals("jpg", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    imageFormat = "JPEG";
                }

                using (var imageFileStream = task.Result.GetStream())
                {
                    var imageData = new byte[imageFileStream.Length];

                    imageFileStream.Read(imageData, 0, imageData.Length);

                    BindingContextPageModel.SplashImageSource = Xamarin.Forms.ImageSource.FromStream(() => new System.IO.MemoryStream(imageData));
                }
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            BindingContextPageModel.PropertyChanged -= PageModelPropertyChanged;
        }
    }
}