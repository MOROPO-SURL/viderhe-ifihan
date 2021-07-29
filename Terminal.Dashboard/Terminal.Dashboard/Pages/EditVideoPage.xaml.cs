using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class EditVideoPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.EditVideoPageModel>
    {
        public EditVideoPage(Support.Presentation.Models.View.VideoViewModel videoViewModel)
            : base(new Models.Page.EditVideoPageModel
            {
                Video = videoViewModel
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
                var client = new Cloud.Api.Connect.Clients.VideosApiConnectClient(Managers.SessionManager.Instance.HttpClientHelper);

                await client.EditAsync(new Cloud.Api.Common.Models.VideoInputModel
                {
                    Id = BindingContextPageModel.Video.Id,
                    About = BindingContextPageModel.Video.About
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