using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Pages
{
    public partial class AddVideoPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.AddVideoPageModel>
    {
        private const int SEGMENT_MB_LENGTH = 1;
        private const int SEGMENT_READ_BUFFER_LENGTH = 1024;

        private Plugin.FilePicker.Abstractions.FileData targetFileData;

        private System.Action successCallbackAction;

        public AddVideoPage(Plugin.FilePicker.Abstractions.FileData targetFileData, System.Action successCallbackAction)
            : base(Factories.AddVideoPageModelFactory.Build(targetFileData))
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
            BindingContextPageModel.BusyProgressMessage = "Eviando ...";

            System.Threading.Tasks.Task.Run(async () =>
            {
                var extension = System.IO.Path.GetExtension(targetFileData.FileName).ToLowerInvariant();

                var contentType = string.Format("video/{0}", extension.Substring(1));

                var segmentLength = SEGMENT_MB_LENGTH * (1024 * 1024);

                int segmentCount = 1;

                var videoId = System.Guid.NewGuid();

                using (var pickedFileStream = targetFileData.GetStream())
                {
                    if (pickedFileStream.Length > segmentLength)
                    {
                        var preciseSegmentCount = (double)pickedFileStream.Length / segmentLength;

                        segmentCount = (int)System.Math.Ceiling(preciseSegmentCount);
                    }

                    var buffer = new byte[SEGMENT_READ_BUFFER_LENGTH];

                    var currentSegment = segmentCount;

                    while (currentSegment > 0)
                    {
                        using (var memoryStream = new System.IO.MemoryStream())
                        {
                            var bytesRemaining = segmentLength;
                            var bytesReaded = 0;

                            while (bytesRemaining > 0 && (bytesReaded = pickedFileStream.Read(buffer, 0, System.Math.Min(bytesRemaining, SEGMENT_READ_BUFFER_LENGTH))) > 0)
                            {
                                memoryStream.Write(buffer, 0, bytesReaded);

                                bytesRemaining -= bytesReaded;
                            }

                            var client = new Cloud.Api.Connect.Clients.VideosApiClient(Managers.SessionManager.Instance.HttpClientHelper);

                            if (currentSegment > 1)
                            {
                                var ordererSegment = segmentCount - currentSegment + 1;

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => { BindingContextPageModel.BusyProgressMessage = string.Format("Eviando {0}% ...", (int)System.Math.Ceiling((double)(ordererSegment * 100 / segmentCount))); });

                                await client.UploadSegmentAsync(videoId, string.Empty, memoryStream.ToArray(), contentType, "file", targetFileData.FileName, ordererSegment);
                            }
                            else
                            {
                                // Send last segment
                                await client.UploadSegmentAsync(videoId, BindingContextPageModel.About, memoryStream.ToArray(), contentType, "file", targetFileData.FileName);

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => { BindingContextPageModel.BusyProgressMessage = string.Format("Eviando {0}% ...", 100); });
                            }
                        }

                        currentSegment = currentSegment - 1;
                    }
                }
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null)
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