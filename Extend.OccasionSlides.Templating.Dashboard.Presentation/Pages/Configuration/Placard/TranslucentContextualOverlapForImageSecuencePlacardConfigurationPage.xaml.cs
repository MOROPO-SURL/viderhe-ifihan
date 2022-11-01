using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Extensions;
using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Placard;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages.Configuration.Placard
{
    public partial class TranslucentContextualOverlapForImageSecuencePlacardConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<TranslucentContextualOverlapForImageSecuencePlacardConfigurationPageModel>
    {
        private const string OPTION_COMMON_CANCEL = "Cancelar";
        private const string OPTION_COMMON_EDIT = "Modificar";
        private const string OPTION_COMMON_DELETE = "Eliminar";

        private const string OPTION_CREATE_CONTENT_BLOCK_TEXT = "Texto";
        private const string OPTION_CREATE_CONTENT_BLOCK_HEADERTEXT = "Texto Encabezado";

        private const string OPTION_FRAME_ORDERTO_BEFORE = "Aumentar Prioridad";
        private const string OPTION_FRAME_ORDERTO_AFTER = "Disminuir Prioridad";

        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private System.Action successfulCompleteCallbackAction;

        public TranslucentContextualOverlapForImageSecuencePlacardConfigurationPage(System.Action successfulCompleteCallbackAction)
            : this(null, successfulCompleteCallbackAction)
        {
        }

        public TranslucentContextualOverlapForImageSecuencePlacardConfigurationPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action successfulCompleteCallbackAction)
            : base(Factories.Placard.TranslucentContextualOverlapForImageSecuencePlacardConfigurationPageModelFactory.Build(placardViewModel))
        {
            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new Descriptors.TranslucentContextualOverlapForImageSecuenceTemplateDescriptor();

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
                var client = new Cloud.Api.Connect.Clients.PlacardsApiConnectClient(Xamarin.Forms.DependencyService.Get<SAPRESSC.Core.Api.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                if (placardViewModel == null)
                {
                    await client.CreateAsync(new Cloud.Api.Common.Models.PlacardInputModel
                    {
                        Label = BindingContextPageModel.Label,
                        TemplateId = Descriptors.TranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.Placard.TranslucentContextualOverlapForImageSecuencePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            OverlapSize = BindingContextPageModel.OverlapSize,
                            OverlapShapeKind = BindingContextPageModel.OverlapShapeKind,
                            OverlapAlignment = BindingContextPageModel.OverlapAlignment,
                            OverlapBackgroundColor = BindingContextPageModel.OverlapBackgroundColor.ToHex(),
                            ContentBlocks = BindingContextPageModel.ContentBlocks.Select(item => item.ToContextModel()).ToArray(),
                            PresentedPictureSlideSecuence = new Essential.Templating.Models.Context.PictureSlideSecuencePlacardContextModel
                            {
                                Slides = BindingContextPageModel.PresentedSlides.Select(item => new Essential.Templating.Models.Context.PictureSlideContextModel
                                {
                                    Image = new Common.Templating.Models.Context.ImageContextModel { Id = item.Image.Id, ThumbnailId = item.Image.ThumbnailId },
                                    LayoutMode = item.LayoutMode
                                }).ToArray(),
                                PicturePresentationSecounds = BindingContextPageModel.PictureSlidePresentationSecounds,
                            }
                        })
                    });
                }
                else
                {
                    await client.EditAsync(new Cloud.Api.Common.Models.PlacardInputModel
                    {
                        Id = placardViewModel.Id,
                        Label = BindingContextPageModel.Label,
                        TemplateId = placardViewModel.Template.Id,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Models.Context.Placard.TranslucentContextualOverlapForImageSecuencePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            OverlapSize = BindingContextPageModel.OverlapSize,
                            OverlapShapeKind = BindingContextPageModel.OverlapShapeKind,
                            OverlapAlignment = BindingContextPageModel.OverlapAlignment,
                            OverlapBackgroundColor = BindingContextPageModel.OverlapBackgroundColor.ToHex(),
                            ContentBlocks = BindingContextPageModel.ContentBlocks.Select(item => item.ToContextModel()).ToArray(),
                            PresentedPictureSlideSecuence = new Essential.Templating.Models.Context.PictureSlideSecuencePlacardContextModel
                            {
                                Slides = BindingContextPageModel.PresentedSlides.Select(item => new Essential.Templating.Models.Context.PictureSlideContextModel
                                {
                                    Image = new Common.Templating.Models.Context.ImageContextModel { Id = item.Image.Id, ThumbnailId = item.Image.ThumbnailId },
                                    LayoutMode = item.LayoutMode
                                }).ToArray(),
                                PicturePresentationSecounds = BindingContextPageModel.PictureSlidePresentationSecounds,
                            }
                        })
                    });
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

        private void IncludeImagesButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.ImagesPickPage(BindingContextPageModel.PresentedSlides.Select(item => item.Image).ToArray(), ImagesSelected_Callback));
        }

        private void ImageDeleteButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Está seguro que desea eliminar esta imagen de la secuencia?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var slide = (sender as Xamarin.Forms.BindableObject).BindingContext as Essential.Templating.Dashboard.Presentation.Models.View.PictureSlideViewModel;

                    BindingContextPageModel.PresentedSlides.Remove(slide);
                });
            });
        }

        private void ImagesSelected_Callback(Support.Presentation.Models.View.ImageViewModel[] selection)
        {
            foreach (var item in selection)
            {
                BindingContextPageModel.PresentedSlides.Add(new Essential.Templating.Dashboard.Presentation.Models.View.PictureSlideViewModel { Image = item });
            }
        }

        private void AddContentBlockButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var options = new string[] { OPTION_CREATE_CONTENT_BLOCK_TEXT, OPTION_CREATE_CONTENT_BLOCK_HEADERTEXT };

            DisplayActionSheet("Nuevo Bloque de Contenido", OPTION_COMMON_CANCEL, null, options).ContinueWith(actionSheetTask =>
            {
                switch (actionSheetTask.Result)
                {
                    case OPTION_CREATE_CONTENT_BLOCK_TEXT:
                        this.NavigationPushPageAsync(new Block.TextContentBlockConfigurationPage(ContentBlockCreation_Callback));

                        break;

                    case OPTION_CREATE_CONTENT_BLOCK_HEADERTEXT:
                        this.NavigationPushPageAsync(new Block.HeaderTextContentBlockConfigurationPage(ContentBlockCreation_Callback));

                        break;

                    default:
                        break;
                }
            });
        }

        private void ContentBlockOptionsButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var target = (sender as Xamarin.Forms.BindableObject).BindingContext as Templating.Presentation.Models.View.Block.Contract.AbstractContentBlockViewModel;

            var extraOptions = new System.Collections.Generic.List<string>
            {
                OPTION_COMMON_EDIT,
                //if (targetFrameViewModel.CanOrderUp)
                //{
                //    extraOptions.Add(OPTION_FRAME_ORDERTO_BEFORE);
                //}

                //if (targetFrameViewModel.CanOrderDown)
                //{
                //    extraOptions.Add(OPTION_FRAME_ORDERTO_AFTER);
                //}

                OPTION_COMMON_DELETE
            };

            DisplayActionSheet("Opciones de Bloque de Contenido", OPTION_COMMON_CANCEL, null, extraOptions.ToArray()).ContinueWith(actionSheetTask =>
            {
                switch (actionSheetTask.Result)
                {
                    case OPTION_COMMON_EDIT:
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            target.LaunchConfigurationPage(this, ContentBlockEdition_Callback);
                        });

                        break;

                    case OPTION_COMMON_DELETE:
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            DisplayAlert("Confirmar", "Esta seguro que desea eliminar el bloque informativo seleccionado?", OPTION_COMMON_DELETE, OPTION_COMMON_CANCEL).ContinueWith(dialogTask =>
                            {
                                if (!dialogTask.Result) return;

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    var targetIndex = BindingContextPageModel.ContentBlocks.IndexOf(target);

                                    BindingContextPageModel.ContentBlocks.RemoveAt(targetIndex);

                                    for (var index = targetIndex; index < BindingContextPageModel.ContentBlocks.Count; index++)
                                    {
                                        var item = BindingContextPageModel.ContentBlocks.ElementAt(index);

                                        item.Priority = index;
                                    }
                                });
                            });
                        });

                        break;

                    case OPTION_FRAME_ORDERTO_BEFORE:
                        //BindingContextPageModel.IsBusy = true;

                        //System.Threading.Tasks.Task.Run(async () =>
                        //{
                        //    var client = new Cloud.Api.Connect.Clients.FramesApiConnectClient(Managers.SessionManager.Instance);

                        //    await client.OrderUpAsync(target.Id);
                        //}).ContinueWith(task =>
                        //{
                        //    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        //    {
                        //        if (task.Exception != null && !task.IsCanceled)
                        //        {
                        //            BindingContextPageModel.IsBusy = false;

                        //            (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);
                        //        }
                        //        else
                        //        {
                        //            Presenters.NotificationPresenter.Instance.PresentNotification("Información", "Prioridad del marco aumentada con exito.");

                        //            LoadCurrentScreenplayFrames();
                        //        }
                        //    });
                        //});

                        break;

                    case OPTION_FRAME_ORDERTO_AFTER:
                        //BindingContextPageModel.IsBusy = true;

                        //System.Threading.Tasks.Task.Run(async () =>
                        //{
                        //    var client = new Cloud.Api.Connect.Clients.FramesApiConnectClient(Managers.SessionManager.Instance);

                        //    await client.OrderDownAsync(target.Id);
                        //}).ContinueWith(task =>
                        //{
                        //    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        //    {
                        //        if (task.Exception != null && !task.IsCanceled)
                        //        {
                        //            BindingContextPageModel.IsBusy = false;

                        //            (Xamarin.Forms.Application.Current as IExceptionHandleHelperFacade).HandleException(task.Exception);
                        //        }
                        //        else
                        //        {
                        //            Presenters.NotificationPresenter.Instance.PresentNotification("Información", "Prioridad del marco disminuida con exito.");

                        //            LoadCurrentScreenplayFrames();
                        //        }
                        //    });
                        //});

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

            BindingContextPageModel.ContentBlocks.Add(model);
        }

        private void ContentBlockEdition_Callback(Templating.Presentation.Models.View.Block.Contract.AbstractContentBlockViewModel model)
        {
            var target = BindingContextPageModel.ContentBlocks.First(item => item.Id == model.Id);

            target.Merge(model);
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            placardViewModel = null;
            successfulCompleteCallbackAction = null;
        }
    }
}