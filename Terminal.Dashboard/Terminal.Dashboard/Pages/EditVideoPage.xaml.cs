using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class EditVideoPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.EditVideoPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        public EditVideoPage(Support.Presentation.Models.View.VideoViewModel videoViewModel)
            : base(new Models.Page.EditVideoPageModel
            {
                Video = videoViewModel
            })
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();
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

        #region IValidableFormPage implementation

        public void AddValidationBehavior(Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Add(validationBehavior);
        }

        public void RemoveValidationBehavior(Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Remove(validationBehavior);
        }

        public void PresentAsNotValid(Xamarin.Forms.View view, Xamarin.Forms.Label label, string message)
        {
            view.BackgroundColor = Xamarin.Forms.Color.Tomato;

            if (view is Xamarin.Forms.Editor)
            {
                (view as Xamarin.Forms.Editor).TextColor = Xamarin.Forms.Color.White;
            }

            BindingContextPageModel.ValidationMessages.Add(new Support.Presentation.Dashboard.Models.View.ValidationMessageViewModel
            {
                Caption = label.Text,
                Message = message
            });
        }

        public void PresentAsValid(Xamarin.Forms.View view, Xamarin.Forms.Label label)
        {
            view.BackgroundColor = Xamarin.Forms.Color.White;

            if (view is Xamarin.Forms.Editor)
            {
                (view as Xamarin.Forms.Editor).TextColor = Xamarin.Forms.Color.Black;
            }
        }

        #endregion
    }
}