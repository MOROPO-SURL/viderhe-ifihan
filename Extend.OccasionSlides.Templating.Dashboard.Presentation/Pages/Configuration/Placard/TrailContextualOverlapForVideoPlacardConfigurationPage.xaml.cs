using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Placard;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages.Configuration.Placard
{
    public partial class TrailContextualOverlapForVideoPlacardConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<TrailContextualOverlapForVideoPlacardConfigurationPageModel>
    {
        private const string OPTION_COMMON_CANCEL = "Cancelar";
        private const string OPTION_COMMON_EDIT = "Modificar";
        private const string OPTION_COMMON_DELETE = "Eliminar";

        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private System.Action successfulCompleteCallbackAction;

        public TrailContextualOverlapForVideoPlacardConfigurationPage(System.Action successfulCompleteCallbackAction)
            : this(null, successfulCompleteCallbackAction)
        {
        }

        public TrailContextualOverlapForVideoPlacardConfigurationPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action successfulCompleteCallbackAction)
            : base(Factories.Placard.TrailContextualOverlapForVideoPlacardConfigurationPageModelFactory.Build(placardViewModel))
        {
            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new Descriptors.TrailContextualOverlapForVideoTemplateDescriptor();

                Title = string.Format("Nuevo Marco ({0})", templateDescriptor.Name);

                return;
            }

            Title = string.Format("Modificando Marco ({0})", placardViewModel.Template.Name);
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(async () =>
            {
                var client = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<MOROPO.SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                if (placardViewModel == null)
                {
                    var model = new Cloud.Api.Common.Models.PlacardInputModel
                    {
                        Label = BindingContextPageModel.Label,
                        TemplateId = Descriptors.TrailContextualOverlapForVideoTemplateDescriptor.ID,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.Placard.TrailContextualOverlapForVideoPlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ContextedVideo = BindingContextPageModel.ContextedVideo.ToContextModel(),
                            IsContextedVideoFramed = BindingContextPageModel.IsContextedVideoFramed,
                            ContextedVideoCenteredAtPresentation = BindingContextPageModel.ContextedVideoCenteredAtPresentation,
                            OverlapTrailMode = BindingContextPageModel.OverlapTrailMode,
                            OverlapSize = BindingContextPageModel.OverlapSize,
                            OverlapShapeKind = BindingContextPageModel.OverlapShapeKind,
                            OverlapAlignment = BindingContextPageModel.OverlapAlignment,
                            OverlapBackgroundColor = BindingContextPageModel.OverlapBackgroundColor.ToHex(),
                            ContentBlocks = BindingContextPageModel.ContentBlocks.Select(item => item.Target.ToContextModel()).ToArray()
                        }, new Newtonsoft.Json.JsonSerializerSettings
                        {
                            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
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
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.Placard.TrailContextualOverlapForVideoPlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ContextedVideo = BindingContextPageModel.ContextedVideo.ToContextModel(),
                            IsContextedVideoFramed = BindingContextPageModel.IsContextedVideoFramed,
                            ContextedVideoCenteredAtPresentation = BindingContextPageModel.ContextedVideoCenteredAtPresentation,
                            OverlapTrailMode = BindingContextPageModel.OverlapTrailMode,
                            OverlapSize = BindingContextPageModel.OverlapSize,
                            OverlapShapeKind = BindingContextPageModel.OverlapShapeKind,
                            OverlapAlignment = BindingContextPageModel.OverlapAlignment,
                            OverlapBackgroundColor = BindingContextPageModel.OverlapBackgroundColor.ToHex(),
                            ContentBlocks = BindingContextPageModel.ContentBlocks.Select(item => item.Target.ToContextModel()).ToArray()
                        }, new Newtonsoft.Json.JsonSerializerSettings
                        {
                            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
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

        private void AddContentBlockButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Presenters.ContentBlockCreationSheetPresenter.PresentForCreate(this, ContentBlockCreation_Callback);
        }

        private void PickContextedVideoButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.VideoPickPage(ContextedVideoPicked_Callback, BindingContextPageModel.ContextedVideo));
        }

        private void ContextedVideoPlayButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.VideoDetailPage(BindingContextPageModel.ContextedVideo));
        }

        private void ContextedVideoPicked_Callback(Support.Presentation.Models.View.VideoViewModel selection)
        {
            BindingContextPageModel.ContextedVideo = selection;
        }

        private void ContentBlockOptionsButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var model = (sender as Xamarin.Forms.BindableObject).BindingContext as Templating.Presentation.Models.View.Block.Contract.AbstractContentBlockViewModel;

            var extraOptions = new System.Collections.Generic.List<string>
            {
                OPTION_COMMON_EDIT,
                OPTION_COMMON_DELETE
            };

            DisplayActionSheet("Opciones de Bloque de Contenido", OPTION_COMMON_CANCEL, null, extraOptions.ToArray()).ContinueWith(actionSheetTask =>
            {
                switch (actionSheetTask.Result)
                {
                    case OPTION_COMMON_EDIT:
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            Presenters.ContentBlockCreationSheetPresenter.PresentForEdit(model, this, ContentBlockEdition_Callback);
                        });

                        break;

                    case OPTION_COMMON_DELETE:
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            DisplayAlert("Confirmar", "Esta seguro que desea eliminar el bloque de contenido seleccionado?", OPTION_COMMON_DELETE, OPTION_COMMON_CANCEL).ContinueWith(dialogTask =>
                            {
                                if (!dialogTask.Result) return;

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    var target = BindingContextPageModel.ContentBlocks.First(item => item.Target == model);

                                    BindingContextPageModel.ContentBlocks.Remove(target);

                                    UpdatePriorities();
                                });
                            });
                        });

                        break;

                    case OPTION_COMMON_CANCEL:
                    default:
                        break;
                }
            });
        }

        private void ContentBlockCreation_Callback(Templating.Presentation.Models.View.Block.Contract.AbstractContentBlockViewModel model)
        {
            model.Priority = BindingContextPageModel.ContentBlocks.Count;

            BindingContextPageModel.ContentBlocks.Add(new Models.View.ContentBlockCollectionItemViewModel { Target = model });
        }

        private void ContentBlockEdition_Callback(Templating.Presentation.Models.View.Block.Contract.AbstractContentBlockViewModel model)
        {
            var current = BindingContextPageModel.ContentBlocks.First(item => item.Target.Id == model.Id);

            current.Target.Merge(model);
        }

        private void ContentBlockCollectionViewDropGestureRecognizer_Drop(object sender, Xamarin.Forms.DropEventArgs e)
        {
            var dropItem = (sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.ContentBlockCollectionItemViewModel;

            var beingDraggedItem = BindingContextPageModel.ContentBlocks.First(i => i.IsBeingDragged);

            if (dropItem == null || beingDraggedItem == dropItem) return;

            BindingContextPageModel.ContentBlocks.Remove(beingDraggedItem);

            if (dropItem.Target.Priority == BindingContextPageModel.ContentBlocks.Count)
            {
                BindingContextPageModel.ContentBlocks.Add(beingDraggedItem);
            }
            else
            {
                BindingContextPageModel.ContentBlocks.Insert(dropItem.Target.Priority, beingDraggedItem);
            }

            dropItem.IsBeingDraggedOverAtStart = false;
            dropItem.IsBeingDraggedOverAtEnd = false;

            UpdatePriorities();

            e.Handled = true;
        }

        private void ContentBlockCollectionViewDropGestureRecognizer_DragLeave(object sender, Xamarin.Forms.DragEventArgs e)
        {
            foreach (var item in BindingContextPageModel.ContentBlocks)
            {
                item.IsBeingDraggedOverAtStart = false;
                item.IsBeingDraggedOverAtEnd = false;
            }
        }

        private void ContentBlockCollectionViewDropGestureRecognizer_DragOver(object sender, Xamarin.Forms.DragEventArgs e)
        {
            var dragOverItem = (sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.ContentBlockCollectionItemViewModel;

            var beingDraggedItem = BindingContextPageModel.ContentBlocks.FirstOrDefault(item => item.IsBeingDragged);

            foreach (var item in BindingContextPageModel.ContentBlocks)
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
                        item.IsBeingDraggedOverAtStart = item.Target.Priority < beingDraggedItem.Target.Priority;
                        item.IsBeingDraggedOverAtEnd = item.Target.Priority > beingDraggedItem.Target.Priority;
                    }
                }
                else
                {
                    item.IsBeingDraggedOverAtStart = false;
                    item.IsBeingDraggedOverAtEnd = false;
                }
            }
        }

        private void ContentBlockCollectionItemViewDragGestureRecognizer_DragStarting(object sender, Xamarin.Forms.DragStartingEventArgs e)
        {
            var target = (sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.ContentBlockCollectionItemViewModel;

            foreach (var item in BindingContextPageModel.ContentBlocks)
            {
                item.IsBeingDragged = target == item;
            }
        }

        private void ContentBlockCollectionItemViewDragGestureRecognizer_DropCompleted(object sender, Xamarin.Forms.DropCompletedEventArgs e)
        {
            var beingDraggedItem = (sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.ContentBlockCollectionItemViewModel;

            beingDraggedItem.IsBeingDragged = false;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            placardViewModel = null;
            successfulCompleteCallbackAction = null;
        }

        private void UpdatePriorities()
        {
            var counter = 0;

            foreach (var item in BindingContextPageModel.ContentBlocks)
            {
                item.Target.Priority = counter++;
            }
        }
    }
}