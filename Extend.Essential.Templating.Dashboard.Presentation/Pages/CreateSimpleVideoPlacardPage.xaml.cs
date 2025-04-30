using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Extend.Essential.Templating.Descriptors;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Behaviors.Contract;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages.Contract;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Pages
{
    public partial class CreateSimpleVideoPlacardPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<CreateSimpleVideoPlacardPageModel>, IValidableFormPage
    {
        private readonly System.Collections.Generic.List<IFormFieldValidationBehavior> validationBehaviors;

        private SimpleVideoTemplateDescriptor templateDescriptor;
        private System.Action successfulCompleteCallbackAction;

        public CreateSimpleVideoPlacardPage(VideoViewModel videoViewModel, SimpleVideoTemplateDescriptor templateDescriptor, System.Action successfulCompleteCallbackAction)
            : base(new CreateSimpleVideoPlacardPageModel
            {
                Video = videoViewModel,
                Label = videoViewModel.About
            })
        {
            validationBehaviors = new System.Collections.Generic.List<IFormFieldValidationBehavior>();

            InitializeComponent();

            this.templateDescriptor = templateDescriptor;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            Title = string.Format("Nuevo Cartel ({0})", templateDescriptor.Name);
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
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
                var client = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new PlacardInputModel
                {
                    Label = BindingContextPageModel.Label,
                    TemplateId = templateDescriptor.Id,
                    PlayerOrientationSupportKind = BindingContextPageModel.PlayerOrientationSupportKind.FromConfiguration(),
                    SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.SimpleVideoPlacardContextModel
                    {
                        RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                        Video = BindingContextPageModel.Video.ToContextModel(),
                        StrechAspectKind = BindingContextPageModel.StrechAspectKind,
                        Muted = BindingContextPageModel.Muted
                    }),
                    Tags = BindingContextPageModel.Tags.ToArray()
                };

                if (BindingContextPageModel.DefineBeginAt)
                {
                    model.BeginAt = BindingContextPageModel.BeginAt;
                }

                if (BindingContextPageModel.DefineEndAt)
                {
                    model.EndAt = BindingContextPageModel.EndAt;
                }

                await client.CreateAsync(model);
            }).ContinueWith((System.Threading.Tasks.Task task) =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        Xamarin.Forms.DependencyService.Get<IExceptionHandleHelperFacade>().HandleException(task.Exception);
                    }
                    else
                    {
                        Xamarin.Forms.DependencyService.Get<INotificationPresenterFacade>().PresentNotification("Información", "Cambios aplicados con éxito.");

                        this.NavigationPopPageAsync();

                        successfulCompleteCallbackAction.Invoke();
                    }
                });
            });
        }

        private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopPageAsync();
        }

        private void VideoPlayButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.VideoDetailPage(BindingContextPageModel.Video));
        }

        private void AddTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Support.Presentation.Dashboard.Pages.Popup.TagPickPopupPage(TagGroup.Placard, PickTagSuccess_Callback, BindingContextPageModel.Tags.ToArray()));
        }

        private void RemoveTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Quitar Etiqueta", "Está seguro quitar esta etiqueta de este cartel?", "Quitar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => BindingContextPageModel.Tags.Remove((sender as Xamarin.Forms.BindableObject).BindingContext as TagDisplayModel));
            });
        }

        private void PickTagSuccess_Callback(TagDisplayModel model)
        {
            BindingContextPageModel.Tags.Add(model);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            templateDescriptor = null;
            successfulCompleteCallbackAction = null;
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