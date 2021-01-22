using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class AddImagePage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.AddImagePageModel>
    {
        private Plugin.FilePicker.Abstractions.FileData targetFileData;

        private System.Action successCallbackAction;

        public AddImagePage(Plugin.FilePicker.Abstractions.FileData targetFileData, System.Action successCallbackAction)
            : base(Factories.AddImagePageModelFactory.Build(targetFileData))
        {
            this.targetFileData = targetFileData;
            this.successCallbackAction = successCallbackAction;

            InitializeComponent();            
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            targetFileData = null;

            successCallbackAction?.Invoke();

            successCallbackAction = null;
        }

        private void CancelToolbarItem_Activated(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopPageAsync();
        }

        private void ApplyToolbarItem_Activated(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(async () =>
            {
                var extension = System.IO.Path.GetExtension(targetFileData.FilePath).ToLowerInvariant();

                var contentType = string.Format("image/{0}", extension.Substring(1));

                if (extension == "jpg")
                {
                    contentType = "image/jpeg";
                }

                var client = new Cloud.Api.Connect.Clients.ImagesApiClient(Managers.SessionManager.Instance.HttpClientHelper);

                using (var imageFileStream = targetFileData.GetStream())
                {
                    var imageData = new byte[imageFileStream.Length];

                    await imageFileStream.ReadAsync(imageData, 0, imageData.Length);

                    await client.UploadAsync(BindingContextPageModel.About, imageData, contentType, "file", targetFileData.FileName);
                }
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null || task.IsCanceled)
                    {
                        BindingContextPageModel.IsBusy = false;

                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);

                        return;
                    }

                    Presenters.NotificationPresenter.Instance.PresentNotification("Información", "Cambios aplicados con éxito.");

                    this.NavigationPopPageAsync();
                });
            });
        }
    }
}