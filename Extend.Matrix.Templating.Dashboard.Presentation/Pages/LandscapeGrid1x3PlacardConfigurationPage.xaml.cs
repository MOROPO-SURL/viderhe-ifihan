using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Dashboard.Presentation.Pages
{
    public partial class LandscapeGrid1x3PlacardConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.LandscapeGrid1x3PlacardConfigurationPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private System.Action successfulCompleteCallbackAction;

        public LandscapeGrid1x3PlacardConfigurationPage(System.Action successfulCompleteCallbackAction)
            : this(null, successfulCompleteCallbackAction)
        {
        }

        public LandscapeGrid1x3PlacardConfigurationPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action successfulCompleteCallbackAction)
            : base(Factories.LandscapeGrid1x3PlacardConfigurationPageFactory.Build(placardViewModel))
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new Descriptors.LandscapeGrid1x3TemplateDescriptor();

                Title = string.Format("Nuevo Marco ({0})", templateDescriptor.Name);

                return;
            }

            Title = string.Format("Modificando Marco ({0})", placardViewModel.Template.Name);
        }

        private void IncludeOneOfThreePlacardsButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.PlacardsPickPage(OneOfThreePlacardsSelected_Callback, new Cloud.Api.Common.Models.Filter.PlacardFilterModel
            {
                PlayerOrientationSupportKind = Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait
            }, item =>
            {
                if (item.PlayerOrientationSupportKind == null)
                {
                    var descriptor = Support.Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptorById(item.Template.Id);

                    return descriptor.PlayerOrientationSupport == Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait || descriptor.PlayerOrientationSupport == Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;
                }

                return true;
            }));
        }

        private void IncludeTwoOfThreePlacardsButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.PlacardsPickPage(TwoOfThreePlacardsSelected_Callback, new Cloud.Api.Common.Models.Filter.PlacardFilterModel
            {
                PlayerOrientationSupportKind = Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait
            }, item =>
            {
                if (item.PlayerOrientationSupportKind == null)
                {
                    var descriptor = Support.Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptorById(item.Template.Id);

                    return descriptor.PlayerOrientationSupport == Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait || descriptor.PlayerOrientationSupport == Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;
                }

                return true;
            }));
        }

        private void IncludeThreeOfThreePlacardsButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.PlacardsPickPage(ThreeOfThreePlacardsSelected_Callback, new Cloud.Api.Common.Models.Filter.PlacardFilterModel
            {
                PlayerOrientationSupportKind = Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait
            }, item =>
            {
                if (item.PlayerOrientationSupportKind == null)
                {
                    var descriptor = Support.Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptorById(item.Template.Id);

                    return descriptor.PlayerOrientationSupport == Common.Templating.Enumerations.PlayerOrientationSupportKind.Portrait || descriptor.PlayerOrientationSupport == Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;
                }

                return true;
            }));
        }

        private void PlacardOneOfThreeDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este marco de la secuencia?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var item = (sender as Xamarin.Forms.BindableObject).BindingContext as Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel;

                    BindingContextPageModel.OneOfThreeTargetPlacards.Remove(item);
                });
            });
        }

        private void PlacardTowOfThreeDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este marco de la secuencia?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var item = (sender as Xamarin.Forms.BindableObject).BindingContext as Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel;

                    BindingContextPageModel.TwoOfThreeTargetPlacards.Remove(item);
                });
            });
        }

        private void PlacardThreeOfThreeDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar este marco de la secuencia?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var item = (sender as Xamarin.Forms.BindableObject).BindingContext as Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel;

                    BindingContextPageModel.ThreeOfThreeTargetPlacards.Remove(item);
                });
            });
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
                var client = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                if (placardViewModel == null)
                {
                    var model = new Cloud.Api.Common.Models.PlacardInputModel
                    {
                        Label = BindingContextPageModel.Label,
                        TemplateId = Descriptors.LandscapeGrid1x3TemplateDescriptor.ID,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.LandscapeGrid1x3PlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            OneOfThreeTargetPlacards = BindingContextPageModel.OneOfThreeTargetPlacards.Select(item => item.Placard.Id.ToString()).ToArray(),
                            TwoOfThreeTargetPlacards = BindingContextPageModel.TwoOfThreeTargetPlacards.Select(item => item.Placard.Id.ToString()).ToArray(),
                            ThreeOfThreeTargetPlacards = BindingContextPageModel.ThreeOfThreeTargetPlacards.Select(item => item.Placard.Id.ToString()).ToArray()
                        })
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
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.LandscapeGrid1x3PlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            OneOfThreeTargetPlacards = BindingContextPageModel.OneOfThreeTargetPlacards.Select(item => item.Placard.Id.ToString()).ToArray(),
                            TwoOfThreeTargetPlacards = BindingContextPageModel.TwoOfThreeTargetPlacards.Select(item => item.Placard.Id.ToString()).ToArray(),
                            ThreeOfThreeTargetPlacards = BindingContextPageModel.ThreeOfThreeTargetPlacards.Select(item => item.Placard.Id.ToString()).ToArray()
                        })
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
            this.NavigationPopPageAsync();
        }

        private void OneOfThreePlacardsSelected_Callback(Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel[] selection)
        {
            foreach (var item in selection)
            {
                BindingContextPageModel.OneOfThreeTargetPlacards.Add(item);
            }
        }

        private void TwoOfThreePlacardsSelected_Callback(Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel[] selection)
        {
            foreach (var item in selection)
            {
                BindingContextPageModel.TwoOfThreeTargetPlacards.Add(item);
            }
        }

        private void ThreeOfThreePlacardsSelected_Callback(Support.Presentation.Dashboard.Models.View.PlacardOverviewViewModel[] selection)
        {
            foreach (var item in selection)
            {
                BindingContextPageModel.ThreeOfThreeTargetPlacards.Add(item);
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