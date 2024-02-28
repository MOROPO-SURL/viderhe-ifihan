using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Factories;
using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Pages
{
    public partial class CornerTileVideoPresentingVideoPlacardConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<CornerTileVideoPresentingVideoPlacardConfigurationPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private System.Action successfulCompleteCallbackAction;

        public CornerTileVideoPresentingVideoPlacardConfigurationPage(System.Action successfulCompleteCallbackAction)
            : this(null, successfulCompleteCallbackAction)
        {
        }

        public CornerTileVideoPresentingVideoPlacardConfigurationPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action successfulCompleteCallbackAction)
            : base(CornerTileVideoPresentingVideoPlacardConfigurationPageModelFactory.Build(placardViewModel))
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new Descriptors.CornerTileVideoPresentingVideoTemplateDescriptor();

                Title = string.Format("Nuevo Cartel ({0})", templateDescriptor.Name);

                return;
            }

            Title = string.Format("Modificando Cartel ({0})", placardViewModel.Template.Name);
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

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

                if (placardViewModel == null)
                {
                    var model = new Cloud.Api.Common.Models.PlacardInputModel
                    {
                        Label = BindingContextPageModel.Label,
                        TemplateId = CornerTileVideoPresentingVideoTemplateDescriptor.ID,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.CornerTileVideoPresentingVideoPlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            PresenterTileVideo = BindingContextPageModel.PresenterTileVideo.ToContextModel(),
                            PresenterTileVideoScreenCorner = BindingContextPageModel.PresenterTileVideoScreenCorner,
                            PresenterTileVideoPlayDelay = BindingContextPageModel.PresenterTileVideoPlayDelay,
                            PresentedVideo = BindingContextPageModel.PresentedVideo.ToContextModel()
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
                }
                else
                {
                    var model = new Cloud.Api.Common.Models.PlacardInputModel
                    {
                        Id = placardViewModel.Id,
                        Label = BindingContextPageModel.Label,
                        TemplateId = placardViewModel.Template.Id,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.CornerTileVideoPresentingVideoPlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            PresenterTileVideo = BindingContextPageModel.PresenterTileVideo.ToContextModel(),
                            PresenterTileVideoScreenCorner = BindingContextPageModel.PresenterTileVideoScreenCorner,
                            PresenterTileVideoPlayDelay = BindingContextPageModel.PresenterTileVideoPlayDelay,
                            PresentedVideo = BindingContextPageModel.PresentedVideo.ToContextModel()
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

                    await client.EditAsync(model);
                }
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        Xamarin.Forms.DependencyService.Get<Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade>().HandleException(task.Exception);
                    }
                    else
                    {
                        Xamarin.Forms.DependencyService.Get<Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade>().PresentNotification("Información", "Cambios aplicados con éxito.");

                        this.NavigationPopPageAsync();

                        successfulCompleteCallbackAction.Invoke();
                    }
                });
            });
        }

        private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            this.NavigationPopPageAsync();
        }

        private void AddTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Support.Presentation.Dashboard.Pages.Popup.TagPickPopupPage(Cloud.Persistence.Enumerations.TagGroup.Placard, PickTagSuccess_Callback, BindingContextPageModel.Tags.ToArray()));
        }

        private void RemoveTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Quitar Etiqueta", "Está seguro quitar esta etiqueta de este cartel?", "Quitar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => BindingContextPageModel.Tags.Remove((sender as Xamarin.Forms.BindableObject).BindingContext as Cloud.Api.Common.Models.TagDisplayModel));
            });
        }

        private void PickTagSuccess_Callback(Cloud.Api.Common.Models.TagDisplayModel model)
        {
            BindingContextPageModel.Tags.Add(model);
        }

        private void PickPresenterTileVideoButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.VideoPickPage(PresenterTileVideoPicked_Callback, BindingContextPageModel.PresenterTileVideo));
        }

        private void PickPresentedVideoButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.VideoPickPage(PresentedVideoPicked_Callback, BindingContextPageModel.PresentedVideo));
        }

        private void PresentedVideoPlayButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.VideoDetailPage(BindingContextPageModel.PresentedVideo));
        }

        private void PresenterTileVideoPlayButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.VideoDetailPage(BindingContextPageModel.PresenterTileVideo));
        }        

        private void PresentedVideoPicked_Callback(Support.Presentation.Models.View.VideoViewModel selection)
        {
            BindingContextPageModel.PresentedVideo = selection;
        }

        private void PresenterTileVideoPicked_Callback(Support.Presentation.Models.View.VideoViewModel selection)
        {
            BindingContextPageModel.PresenterTileVideo = selection;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            placardViewModel = null;
            successfulCompleteCallbackAction = null;
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