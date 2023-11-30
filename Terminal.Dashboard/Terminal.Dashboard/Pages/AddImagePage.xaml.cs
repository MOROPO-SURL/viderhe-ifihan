using MOROPO.VIDERHE.Support.Presentation.Dashboard.Behaviors.Contract;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages.Contract;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Terminal.Dashboard.Factories;
using MOROPO.VIDERHE.Terminal.Dashboard.Managers;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Pages
{
    public partial class AddImagePage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<AddImagePageModel>, IValidableFormPage
    {
        private readonly System.Collections.Generic.List<IFormFieldValidationBehavior> validationBehaviors;

        private Plugin.FilePicker.Abstractions.FileData targetFileData;

        private System.Action successCallbackAction;

        public AddImagePage(Plugin.FilePicker.Abstractions.FileData targetFileData, System.Action successCallbackAction)
            : base(AddImagePageModelFactory.Build(targetFileData))
        {
            validationBehaviors = new System.Collections.Generic.List<IFormFieldValidationBehavior>();

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
                var extension = System.IO.Path.GetExtension(targetFileData.FilePath).ToLowerInvariant();

                var contentType = string.Format("image/{0}", extension.Substring(1));

                if (extension == "jpg")
                {
                    contentType = "image/jpeg";
                }

                var client = new Cloud.Api.Connect.Clients.ImagesApiConnectClient(SessionManager.Instance.HttpClientHelper);

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

                        (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);

                        return;
                    }

                    Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Cambios aplicados con éxito.");

                    this.NavigationPopPageAsync();
                });
            });
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
    }
}