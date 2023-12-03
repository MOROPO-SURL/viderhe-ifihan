using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Factories;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Descriptors;
using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Pages
{
    public partial class ClassicDeparturesPlacardConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<ClassicOperationsPlacardConfigurationPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private const string BACKGROUND_OPTION_GRADIENT = "Gradiente";
        private const string BACKGROUND_OPTION_IMAGE = "Imagen";
        private const string BACKGROUND_OPTION_VIDEO = "Video";

        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private System.Action successfulCompleteCallbackAction;

        public ClassicDeparturesPlacardConfigurationPage(System.Action successfulCompleteCallbackAction)
            : this(null, successfulCompleteCallbackAction)
        {
        }

        public ClassicDeparturesPlacardConfigurationPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action successfulCompleteCallbackAction)
            : base(ClassicOperationsPlacardConfigurationPageModelFactory.Build(placardViewModel))
        {
            if (placardViewModel == null)
            {
                var index = 0;

                BindingContextPageModel.VisibleColumns = new System.Collections.ObjectModel.ObservableCollection<ClassicOperationColumnCollectionItemViewModel> {
                    new ClassicOperationColumnCollectionItemViewModel { Order = index++, Target = ClassicOperationsColumn.TIME },
                    new ClassicOperationColumnCollectionItemViewModel { Order = index++, Target = ClassicOperationsColumn.CONTEXT },
                    new ClassicOperationColumnCollectionItemViewModel { Order = index++, Target = ClassicOperationsColumn.FLY },
                    new ClassicOperationColumnCollectionItemViewModel { Order = index++, Target = ClassicOperationsColumn.TERMINAL },
                    new ClassicOperationColumnCollectionItemViewModel { Order = index++, Target = ClassicOperationsColumn.STATUS }
                };
                BindingContextPageModel.AvailableColumns = new System.Collections.ObjectModel.ObservableCollection<ClassicOperationsColumn>
                {
                    ClassicOperationsColumn.CARRIER,
                    ClassicOperationsColumn.FLYNUMBER,
                    ClassicOperationsColumn.CATEGORY,
                    ClassicOperationsColumn.GATE
                };
            }
            else
            {
                var classicOperationsColumnUniverse = new System.Collections.ObjectModel.ObservableCollection<ClassicOperationsColumn>
                {
                    ClassicOperationsColumn.TIME,
                    ClassicOperationsColumn.CONTEXT,
                    ClassicOperationsColumn.FLY,
                    ClassicOperationsColumn.TERMINAL,
                    ClassicOperationsColumn.STATUS,
                    ClassicOperationsColumn.CARRIER,
                    ClassicOperationsColumn.FLYNUMBER,
                    ClassicOperationsColumn.CATEGORY,
                    ClassicOperationsColumn.GATE
                };

                BindingContextPageModel.AvailableColumns = new System.Collections.ObjectModel.ObservableCollection<ClassicOperationsColumn>(classicOperationsColumnUniverse.Except(BindingContextPageModel.VisibleColumns.Select(item => item.Target)));
            }

            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new ClassicDeparturesTemplateDescriptor();

                Title = string.Format("Nuevo Cartel ({0})", templateDescriptor.Name);

                return;
            }

            Title = string.Format("Modificando Cartel ({0})", placardViewModel.Template.Name);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            placardViewModel = null;
            successfulCompleteCallbackAction = null;
        }

        private void BackgroundClearButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea retirar el fondo actual?", "Aceptar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.Background = null;
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
                var client = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                if (placardViewModel == null)
                {
                    var model = new Cloud.Api.Common.Models.PlacardInputModel
                    {
                        Label = BindingContextPageModel.Label,
                        TemplateId = ClassicDeparturesTemplateDescriptor.ID,
                        PlayerOrientationSupportKind = BindingContextPageModel.PlayerOrientationSupportKind.FromConfiguration(),
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.Placard.ClassicOperationsPlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ScreenPresentationTime = System.TimeSpan.FromSeconds(BindingContextPageModel.ScreenPresentationTimeSecounds),
                            APIServer = BindingContextPageModel.APIServer,
                            UseSSL = BindingContextPageModel.UseSSL,
                            APIKey = BindingContextPageModel.APIKey,
                            AllowAnyCertificate = BindingContextPageModel.AllowAnyCertificate,
                            UpdateInterval = BindingContextPageModel.UpdateInterval,
                            MaxItemsCount = BindingContextPageModel.MaxItemsCount,
                            TableBackgroundColor = BindingContextPageModel.TableBackgroundColor.ToHex(),
                            TableHeaderTextColor = BindingContextPageModel.TableHeaderTextColor.ToHex(),
                            TableHeaderBackgroundColor = BindingContextPageModel.TableHeaderBackgroundColor.ToHex(),
                            TableHeaderFontSize = BindingContextPageModel.TableHeaderFontSize,
                            PrimaryRowTextColor = BindingContextPageModel.PrimaryRowTextColor.ToHex(),
                            PrimaryRowBackgroundColor = BindingContextPageModel.PrimaryRowBackgroundColor.ToHex(),
                            UseStrippedRows = BindingContextPageModel.UseStrippedRows,
                            SecoundaryRowTextColor = BindingContextPageModel.SecoundaryRowTextColor.ToHex(),
                            SecoundaryRowBackgroundColor = BindingContextPageModel.SecoundaryRowBackgroundColor.ToHex(),
                            RowFontSize = BindingContextPageModel.RowFontSize,
                            Columns = BindingContextPageModel.VisibleColumns.Select(item => item.Target).ToArray(),
                            Background = BindingContextPageModel.Background,
                            ForegroundTransparency = BindingContextPageModel.ForegroundTransparency
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
                        PlayerOrientationSupportKind = BindingContextPageModel.PlayerOrientationSupportKind.FromConfiguration(),
                        TemplateId = placardViewModel.Template.Id,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.Placard.ClassicOperationsPlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ScreenPresentationTime = System.TimeSpan.FromSeconds(BindingContextPageModel.ScreenPresentationTimeSecounds),
                            APIServer = BindingContextPageModel.APIServer,
                            UseSSL = BindingContextPageModel.UseSSL,
                            APIKey = BindingContextPageModel.APIKey,
                            AllowAnyCertificate = BindingContextPageModel.AllowAnyCertificate,
                            UpdateInterval = BindingContextPageModel.UpdateInterval,
                            MaxItemsCount = BindingContextPageModel.MaxItemsCount,
                            TableBackgroundColor = BindingContextPageModel.TableBackgroundColor.ToHex(),
                            TableHeaderTextColor = BindingContextPageModel.TableHeaderTextColor.ToHex(),
                            TableHeaderBackgroundColor = BindingContextPageModel.TableHeaderBackgroundColor.ToHex(),
                            TableHeaderFontSize = BindingContextPageModel.TableHeaderFontSize,
                            PrimaryRowTextColor = BindingContextPageModel.PrimaryRowTextColor.ToHex(),
                            PrimaryRowBackgroundColor = BindingContextPageModel.PrimaryRowBackgroundColor.ToHex(),
                            UseStrippedRows = BindingContextPageModel.UseStrippedRows,
                            SecoundaryRowTextColor = BindingContextPageModel.SecoundaryRowTextColor.ToHex(),
                            SecoundaryRowBackgroundColor = BindingContextPageModel.SecoundaryRowBackgroundColor.ToHex(),
                            RowFontSize = BindingContextPageModel.RowFontSize,
                            Columns = BindingContextPageModel.VisibleColumns.Select(item => item.Target).ToArray(),
                            Background = BindingContextPageModel.Background,
                            ForegroundTransparency = BindingContextPageModel.ForegroundTransparency
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

        private void BackgroundGestureRecognizer_Tapped(object sender, System.EventArgs eventArgs)
        {
            DisplayActionSheet("Seleccione el tipo de fondo a definir:", "Cancelar", null, new string[] { BACKGROUND_OPTION_GRADIENT, BACKGROUND_OPTION_IMAGE }).ContinueWith(displayActionSheetTask =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                {
                    switch (displayActionSheetTask.Result)
                    {
                        case BACKGROUND_OPTION_IMAGE:
                            Support.Presentation.Models.View.ImageViewModel except = null;

                            if (BindingContextPageModel.Background != null && BindingContextPageModel.Background.Kind == BackgroundKind.Image)
                            {
                                except = Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.ImageContextModel>(BindingContextPageModel.Background.SerializedContext).ToViewModel();
                            }

                            var imagePickPage = new Support.Presentation.Dashboard.Pages.ImagePickPage(BackgroundImagePick_Callback, except);

                            await this.NavigationPushPageAsync(imagePickPage);

                            break;

                        case BACKGROUND_OPTION_GRADIENT:
                            await this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.GradientPickPage(BackgroundGradientPick_Callback));

                            break;
                    }
                });
            });
        }

        private void HideColumnButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var item = (ClassicOperationColumnCollectionItemViewModel) (sender as Xamarin.Forms.BindableObject).BindingContext;

            BindingContextPageModel.VisibleColumns.Remove(item);
            BindingContextPageModel.AvailableColumns.Add(item.Target);
        }

        private void ShowColumnButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var item = (ClassicOperationsColumn)(sender as Xamarin.Forms.BindableObject).BindingContext;

            BindingContextPageModel.AvailableColumns.Remove(item);
            BindingContextPageModel.VisibleColumns.Add(new ClassicOperationColumnCollectionItemViewModel { Order = BindingContextPageModel.VisibleColumns.Count, Target = item });
        }

        private void VisibleColumnsStackLayout_DropGestureRecognizer_Drop(object sender, Xamarin.Forms.DropEventArgs e)
        {
            var dropItem = (sender as Xamarin.Forms.BindableObject).BindingContext as ClassicOperationColumnCollectionItemViewModel;

            var beingDraggedItem = BindingContextPageModel.VisibleColumns.First(i => i.IsBeingDragged);

            if (dropItem == null || beingDraggedItem == dropItem) return;

            BindingContextPageModel.VisibleColumns.Remove(beingDraggedItem);

            if (dropItem.Order == BindingContextPageModel.VisibleColumns.Count)
            {
                BindingContextPageModel.VisibleColumns.Add(beingDraggedItem);
            }
            else
            {
                BindingContextPageModel.VisibleColumns.Insert(dropItem.Order, beingDraggedItem);
            }

            dropItem.IsBeingDraggedOverAtStart = false;
            dropItem.IsBeingDraggedOverAtEnd = false;

            ReOrderVisibleColumns();

            e.Handled = true;
        }

        private void VisibleColumnsStackLayout_DropGestureRecognizer_DragLeave(object sender, Xamarin.Forms.DragEventArgs e)
        {
            foreach (var item in BindingContextPageModel.VisibleColumns)
            {
                item.IsBeingDraggedOverAtStart = false;
                item.IsBeingDraggedOverAtEnd = false;
            }
        }

        private void VisibleColumnsStackLayout_DropGestureRecognizer_DragOver(object sender, Xamarin.Forms.DragEventArgs e)
        {
            var dragOverItem = (sender as Xamarin.Forms.BindableObject).BindingContext as ClassicOperationColumnCollectionItemViewModel;

            var beingDraggedItem = BindingContextPageModel.VisibleColumns.FirstOrDefault(item => item.IsBeingDragged);

            foreach (var item in BindingContextPageModel.VisibleColumns)
            {
                if (dragOverItem == item)
                {
                    if (item.IsBeingDragged)
                    {
                        item.IsBeingDraggedOverAtStart = false;
                        item.IsBeingDraggedOverAtEnd = false;
                    }
                    else
                    {
                        item.IsBeingDraggedOverAtStart = item.Order < beingDraggedItem.Order;
                        item.IsBeingDraggedOverAtEnd = item.Order > beingDraggedItem.Order;
                    }
                }
                else
                {
                    item.IsBeingDraggedOverAtStart = false;
                    item.IsBeingDraggedOverAtEnd = false;
                }
            }
        }

        private void VisibleColumnsStackLayout_ItemView_DragGestureRecognizer_DragStarting(object sender, Xamarin.Forms.DragStartingEventArgs e)
        {
            var target = (sender as Xamarin.Forms.BindableObject).BindingContext as ClassicOperationColumnCollectionItemViewModel;

            foreach (var item in BindingContextPageModel.VisibleColumns)
            {
                item.IsBeingDragged = target == item;
            }
        }

        private void VisibleColumnsStackLayout_ItemView_DragGestureRecognizer_DropCompleted(object sender, Xamarin.Forms.DropCompletedEventArgs e)
        {
            var beingDraggedItem = (sender as Xamarin.Forms.BindableObject).BindingContext as ClassicOperationColumnCollectionItemViewModel;

            beingDraggedItem.IsBeingDragged = false;
        }

        private void PickTagSuccess_Callback(Cloud.Api.Common.Models.TagDisplayModel model)
        {
            BindingContextPageModel.Tags.Add(model);
        }

        private void BackgroundImagePick_Callback(Support.Presentation.Models.View.ImageViewModel target)
        {
            BindingContextPageModel.Background = new Templating.Models.Context.BackgroundContextModel
            {
                Kind = BackgroundKind.Image,
                SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(target.ToContextModel())
            };
        }

        private void BackgroundGradientPick_Callback(Support.Presentation.Dashboard.Models.View.GradientViewModel target)
        {
            BindingContextPageModel.Background = new Templating.Models.Context.BackgroundContextModel
            {
                Kind = BackgroundKind.Gradient,
                SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Common.Templating.Models.Context.GradientContextModel
                {
                    Id = target.Id,
                    About = target.About,
                    CreateAt = target.CreateAt,
                    Data = target.Source.Stylesheet
                })
            };
        }

        private void ReOrderVisibleColumns()
        {
            var counter = 0;

            foreach (var item in BindingContextPageModel.VisibleColumns)
            {
                item.Order = counter++;
            }
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