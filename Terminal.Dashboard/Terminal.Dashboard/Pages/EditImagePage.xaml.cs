using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class EditImagePage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.EditImagePageModel>
    {
        public EditImagePage(Support.Presentation.Models.View.ImageViewModel imageViewModel)
            : base(new Models.Page.EditImagePageModel
            {
                Image = imageViewModel
            })
        {
            InitializeComponent();
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
                var client = new Cloud.Api.Connect.Clients.ImagesApiClient(Managers.SessionManager.Instance.HttpClientHelper);

                await client.EditAsync(new Cloud.Api.Common.Models.ImageInputModel
                {
                    Id = BindingContextPageModel.Image.Id,
                    About = BindingContextPageModel.Image.About
                });
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