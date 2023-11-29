using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Behaviors.Contract;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages.Contract;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Presenters.Facade;
using MOROPO.VIDERHE.Support.Presentation.Helpers.Facade;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    public partial class SoundComplementConfigurationPage :
        XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.SoundComplementConfigurationPageModel>,
        IValidableFormPage
    {
        private readonly System.Collections.Generic.List<IFormFieldValidationBehavior> validationBehaviors;

        private bool pageModelHasChanges;
        private PlacardViewModel placardViewModel;
        private System.Action successfulCompleteCallbackAction;

        public SoundComplementConfigurationPage(PlacardViewModel placardViewModel, System.Action successfulCompleteCallbackAction)
            : base(Factories.SoundComplementConfigurationPageModelFactory.Build(placardViewModel))
        {
            validationBehaviors = new System.Collections.Generic.List<IFormFieldValidationBehavior>();

            InitializeComponent();

            BindingContextPageModel.PropertyChanged += PageModelProperty_Changed;

            this.placardViewModel = placardViewModel;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel.ComplementationKind == null)
            {
                Title = "Definiendo Complemento de Audio";

                return;
            }

            Title = "Modificando Complemento de Audio";
        }

        private void PageModelProperty_Changed(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            pageModelHasChanges = true;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (!pageModelHasChanges)
            {
                this.NavigationPopPageAsync();

                return;
            }

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
                var client = new Cloud.Api.Connect.Clients.ComplementationsApiConnectClient(Managers.SessionManager.Instance.HttpClientHelper);

                await client.EditAsync(new Cloud.Api.Common.Models.ComplementationInputModel
                {
                    PlacardId = placardViewModel.Id,
                    ComplementationKind = PlacardComplementationKind.Sound,
                    SerializedComplementation = Newtonsoft.Json.JsonConvert.SerializeObject(new Extend.Common.Templating.Models.Context.SoundComplementContextModel
                    {
                        Sound = new Extend.Common.Templating.Models.Context.SoundContextModel
                        {
                            Id = BindingContextPageModel.Sound.Id,
                            About = BindingContextPageModel.Sound.About,
                            AudioChannelOutput = BindingContextPageModel.Sound.AudioChannelOutput,
                            AudioFormat = BindingContextPageModel.Sound.AudioFormat,
                            CreateAt = BindingContextPageModel.Sound.CreateAt,
                            Duration = BindingContextPageModel.Sound.Duration,
                            Extension = BindingContextPageModel.Sound.Extension,
                            Length = BindingContextPageModel.Sound.Length,
                            ThumbnailId = BindingContextPageModel.Sound.ThumbnailId
                        },
                        Repeat = BindingContextPageModel.Repeat,
                        Delay = BindingContextPageModel.Delay
                    })
                });
            }).ContinueWith(task =>
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

        private void PickSoundButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.SoundPickPage(SoundPicked_Callback, BindingContextPageModel.Sound));
        }

        private void SoundPlayButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            // TODO Implement expected behavior!!
            //this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.VideoDetailPage(BindingContextPageModel.Sound));
        }

        private void SoundPicked_Callback(SoundViewModel selection)
        {
            BindingContextPageModel.Sound = selection;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            BindingContextPageModel.PropertyChanged -= PageModelProperty_Changed;

            placardViewModel = null;
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