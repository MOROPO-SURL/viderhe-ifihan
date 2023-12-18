using MOROPO.VIDERHE.Extend.Matrix.Templating.Dashboard.Presentation.Models.Page;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Dashboard.Presentation.Pages
{
    public partial class LandscapeGrid3st_2x1PlacardConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<LandscapeGrid3st_2x1PlacardConfigurationPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private System.Action successfulCompleteCallbackAction;

        public LandscapeGrid3st_2x1PlacardConfigurationPage(System.Action successfulCompleteCallbackAction)
            : this(null, successfulCompleteCallbackAction)
        {
        }

        public LandscapeGrid3st_2x1PlacardConfigurationPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action successfulCompleteCallbackAction)
            : base(Factories.LandscapeGrid3st_2x1PlacardConfigurationPageModelFactory.Build(placardViewModel))
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new Descriptors.LandscapeGrid3st_2x1TemplateDescriptor();

                Title = string.Format("Nuevo Cartel ({0})", templateDescriptor.Name);

                return;
            }

            Title = string.Format("Modificando Cartel ({0})", placardViewModel.Template.Name);
        }

        private void IncludeOneOfTwoPlacardsButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.PlacardsPickPage(OneOfTwoPlacardsSelected_Callback, new Cloud.Api.Common.Models.Filter.PlacardFilterModel
            {
                PlayerOrientationSupportKind = Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape
            }, item =>
            {
                if (item.PlayerOrientationSupportKind == null)
                {
                    var descriptor = Support.Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptorById(item.Template.Id);

                    return descriptor?.PlayerOrientationSupport == Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape || descriptor?.PlayerOrientationSupport == Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;
                }

                return true;
            }));
        }

        private void IncludeTwoOfTwoSplitOneOfTwoPlacardsButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.PlacardsPickPage(TwoOfTwoSplitOneOfTwoPlacardsSelected_Callback, new Cloud.Api.Common.Models.Filter.PlacardFilterModel
            {
                PlayerOrientationSupportKind = Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape
            }, item =>
            {
                if (item.PlayerOrientationSupportKind == null)
                {
                    var descriptor = Support.Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptorById(item.Template.Id);

                    return descriptor?.PlayerOrientationSupport == Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape || descriptor?.PlayerOrientationSupport == Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;
                }

                return true;
            }));
        }

        private void IncludeTwoOfTwoSplitTwoOfTwoPlacardsButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.PlacardsPickPage(TwoOfTwoSplitTwoOfTwoPlacardsSelected_Callback, new Cloud.Api.Common.Models.Filter.PlacardFilterModel
            {
                PlayerOrientationSupportKind = Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape
            }, item =>
            {
                if (item.PlayerOrientationSupportKind == null)
                {
                    var descriptor = Support.Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptorById(item.Template.Id);

                    return descriptor?.PlayerOrientationSupport == Common.Templating.Enumerations.PlayerOrientationSupportKind.Landscape || descriptor?.PlayerOrientationSupport == Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;
                }

                return true;
            }));
        }

        private void PlacardOneOfTwoDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este cartel de la secuencia?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var item = (sender as Xamarin.Forms.BindableObject).BindingContext as Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel;

                    BindingContextPageModel.OneOfTwoTargetPlacards.Remove(item);
                });
            });
        }

        private void PlacardTwoOfTwoSplitOneOfTwoDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este cartel de la secuencia?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var item = (sender as Xamarin.Forms.BindableObject).BindingContext as Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel;

                    BindingContextPageModel.TwoOfTwoSplitOneOfTwoTargetPlacards.Remove(item);
                });
            });
        }

        private void PlacardTwoOfTwoSplitTwoOfTwoDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este cartel de la secuencia?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var item = (sender as Xamarin.Forms.BindableObject).BindingContext as Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel;

                    BindingContextPageModel.TwoOfTwoSplitTwoOfTwoTargetPlacards.Remove(item);
                });
            });
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
                        TemplateId = Descriptors.LandscapeGrid3st_2x1TemplateDescriptor.ID,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.LandscapeGrid3st_2x1PlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            OneOfTwoTargetPlacards = BindingContextPageModel.OneOfTwoTargetPlacards.Select(item => item.Placard.Id.ToString()).ToArray(),
                            IsOneOfTwoTargetPlacardsScalable = BindingContextPageModel.IsOneOfTwoTargetPlacardsScalable,
                            TwoOfTwoSplitOneOfTwoTargetPlacards = BindingContextPageModel.TwoOfTwoSplitOneOfTwoTargetPlacards.Select(item => item.Placard.Id.ToString()).ToArray(),
                            TwoOfTwoSplitTwoOfTwoTargetPlacards = BindingContextPageModel.TwoOfTwoSplitTwoOfTwoTargetPlacards.Select(item => item.Placard.Id.ToString()).ToArray()
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
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.LandscapeGrid3st_2x1PlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            OneOfTwoTargetPlacards = BindingContextPageModel.OneOfTwoTargetPlacards.Select(item => item.Placard.Id.ToString()).ToArray(),
                            IsOneOfTwoTargetPlacardsScalable = BindingContextPageModel.IsOneOfTwoTargetPlacardsScalable,
                            TwoOfTwoSplitOneOfTwoTargetPlacards = BindingContextPageModel.TwoOfTwoSplitOneOfTwoTargetPlacards.Select(item => item.Placard.Id.ToString()).ToArray(),
                            TwoOfTwoSplitTwoOfTwoTargetPlacards = BindingContextPageModel.TwoOfTwoSplitTwoOfTwoTargetPlacards.Select(item => item.Placard.Id.ToString()).ToArray()
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

        private void OneOfTwoPlacardsSelected_Callback(Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel[] selection)
        {
            foreach (var item in selection)
            {
                BindingContextPageModel.OneOfTwoTargetPlacards.Add(item);
            }
        }

        private void TwoOfTwoSplitOneOfTwoPlacardsSelected_Callback(Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel[] selection)
        {
            foreach (var item in selection)
            {
                BindingContextPageModel.TwoOfTwoSplitOneOfTwoTargetPlacards.Add(item);
            }
        }

        private void TwoOfTwoSplitTwoOfTwoPlacardsSelected_Callback(Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel[] selection)
        {
            foreach (var item in selection)
            {
                BindingContextPageModel.TwoOfTwoSplitTwoOfTwoTargetPlacards.Add(item);
            }
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