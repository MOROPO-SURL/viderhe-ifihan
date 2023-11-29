using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class ManageSoundsPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.ManageSoundsPageModel>
    {
        private int currentItemsPageNumber;

        public ManageSoundsPage() : base(new Models.Page.ManageSoundsPageModel { IsBusy = true })
        {
            InitializeComponent();

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            RequiredReload_Callback();

            IsEnabled = true;
        }

        private void OverviewPlayButton_Clicked(object sender, System.EventArgs e)
        {
            BindingContextPageModel.Target = (sender as Xamarin.Forms.BindableObject).BindingContext as SoundViewModel;
        }

        private void OverviewEditButton_Clicked(object sender, System.EventArgs e)
        {
            this.NavigationPushPageAsync(new EditSoundPage((sender as Xamarin.Forms.BindableObject).BindingContext as SoundViewModel));
        }

        private void DismissTargetButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.Target = null;
        }

        private void OverviewDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este audio?", "Aceptar", "Cancelar").ContinueWith(async task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = true;
                });

                var client = new Cloud.Api.Connect.Clients.SoundsApiConnectClient(Managers.SessionManager.Instance.HttpClientHelper);

                System.Exception failException = null;

                try
                {
                    await client.DeleteAsync(((sender as Xamarin.Forms.BindableObject).BindingContext as SoundViewModel).Id);
                }
                catch (System.Exception ex)
                {
                    failException = ex;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (failException == null)
                    {
                        Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Audio eliminado con éxito.");

                        RequiredReload_Callback();
                    }
                    else
                    {
                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(failException);
                    }
                });
            });
        }

        private void AddToolbarItem_Activated(object sender, System.EventArgs e)
        {
            if (BindingContextPageModel.IsBusy) return;

            BindingContextPageModel.Target = null;

            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(() =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                {
                    try
                    {
                        string[] fileSelector = null;

                        switch (Xamarin.Forms.Device.RuntimePlatform)
                        {
                            case Xamarin.Forms.Device.Android:
                                fileSelector = new string[] { "audio/mp3" };

                                break;

                            case Xamarin.Forms.Device.UWP:
                                fileSelector = new string[] { ".mp3" };

                                break;

                            case Xamarin.Forms.Device.WPF:
                            default:
                                fileSelector = new string[] { "Audio Soportadas|*.mp3" };

                                break;
                        }

                        var targetFileData = await Plugin.FilePicker.CrossFilePicker.Current.PickFile(fileSelector);

                        if (targetFileData != null)
                        {
                            await this.NavigationPushPageAsync(new AddSoundPage(targetFileData, RequiredReload_Callback));
                        }
                    }
                    finally
                    {
                        BindingContextPageModel.IsBusy = false;
                    }
                });
            });
        }

        private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            BindingContextPageModel.Target = null;

            RequiredReload_Callback();
        }

        private void LoadNextPageButtton_Clicked(object sender, System.EventArgs eventArgs)
        {
            LoadNextItemsPage();
        }

        private void RequiredReload_Callback()
        {
            LoadNextItemsPage(true);
        }

        private void LoadNextItemsPage(bool restart = false)
        {
            BindingContextPageModel.IsBusy = true;

            if (restart) currentItemsPageNumber = 0;

            var imagesApiConnectClient = new Cloud.Api.Connect.Clients.SoundsApiConnectClient(Managers.SessionManager.Instance.HttpClientHelper);

            imagesApiConnectClient.GetPageAsync(++currentItemsPageNumber).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                    else
                    {
                        if (currentItemsPageNumber == 1)
                        {
                            BindingContextPageModel.Items.Clear();
                        }

                        foreach (var item in task.Result.List)
                        {
                            BindingContextPageModel.Items.Add(new SoundViewModel
                            {
                                Id = item.Id,
                                About = item.About,
                                AudioChannelOutput = item.AudioChannelOutput,
                                AudioFormat = item.AudioFormat,
                                CreateAt = item.CreateAt,
                                Duration = item.Duration,
                                Extension = item.Extension.ToUpperInvariant(),
                                Length = item.Length,
                                ThumbnailId = item.ThumbnailId,
                            });
                        }

                        BindingContextPageModel.HasMoreItems = task.Result.HasNext && task.Result.List.Count > 0;
                    }
                });
            });
        }
    }
}