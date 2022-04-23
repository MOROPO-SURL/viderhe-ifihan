using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Pages
{
    public partial class CenteredTraslucentIntroOverImagePlacardConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.CenteredTraslucentIntroOverImagePlacardConfigurationPageModel>
    {
        private const string OPTION_COMMON_CANCEL = "Cancelar";
        private const string OPTION_COMMON_EDIT = "Modificar";
        private const string OPTION_COMMON_DELETE = "Eliminar";

        private const string OPTION_FRAME_ORDERTO_BEFORE = "Aumentar Prioridad";
        private const string OPTION_FRAME_ORDERTO_AFTER = "Disminuir Prioridad";

        private Support.Presentation.Models.View.PlacardViewModel placardViewModel;
        private System.Action successfulCompleteCallbackAction;

        public CenteredTraslucentIntroOverImagePlacardConfigurationPage(System.Action successfulCompleteCallbackAction)
            : this(null, successfulCompleteCallbackAction)
        {
        }

        public CenteredTraslucentIntroOverImagePlacardConfigurationPage(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action successfulCompleteCallbackAction)
            : base(Factories.CenteredTraslucentIntroOverImagePlacardConfigurationPageModelFactory.Build(placardViewModel))
        {
            InitializeComponent();

            this.placardViewModel = placardViewModel;
            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            if (placardViewModel == null)
            {
                var templateDescriptor = new Descriptors.CenteredTraslucentIntroOverImageTemplateDescriptor();

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
                        TemplateId = Descriptors.CenteredTraslucentIntroOverImageTemplateDescriptor.ID,
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Presentation.Models.Context.CenteredTraslucentIntroOverImagePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ScreenPresentationTime = System.TimeSpan.FromSeconds(BindingContextPageModel.ScreenPresentationTimeSecounds),
                            HeadImage = BindingContextPageModel.HeaderImage?.ToContextModel(),
                            BackgroundImage = BindingContextPageModel.BackgroundImage.ToContextModel(),
                            BackgroundImageZoomingEnabled = BindingContextPageModel.BackgroundImageZoomingEnabled,
                            ContentBoxPresentationKind = BindingContextPageModel.ContentBoxPresentationKind,
                            OverlapOpacity = BindingContextPageModel.OverlapOpacity / 100d,
                            OverlapBackgroundColor = BindingContextPageModel.OverlapBackgroundColor.ToHex(),
                            TextColor = BindingContextPageModel.TextColor.ToHex(),
                            Title = BindingContextPageModel.Title,
                            TitleFontFamily = BindingContextPageModel.TitleFontFamily,
                            TitleFontSize = BindingContextPageModel.TitleFontSize,
                            ContentBlocks = BindingContextPageModel.ContentBlocks.ToArray()
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
                        SerializedContext = Newtonsoft.Json.JsonConvert.SerializeObject(new Templating.Presentation.Models.Context.CenteredTraslucentIntroOverImagePlacardContextModel
                        {
                            RequireUnobstructedPresetation = BindingContextPageModel.RequireUnobstructedPresetation,
                            ScreenPresentationTime = System.TimeSpan.FromSeconds(BindingContextPageModel.ScreenPresentationTimeSecounds),
                            HeadImage = BindingContextPageModel.HeaderImage?.ToContextModel(),
                            BackgroundImage = BindingContextPageModel.BackgroundImage.ToContextModel(),
                            BackgroundImageZoomingEnabled = BindingContextPageModel.BackgroundImageZoomingEnabled,
                            ContentBoxPresentationKind = BindingContextPageModel.ContentBoxPresentationKind,
                            OverlapOpacity = BindingContextPageModel.OverlapOpacity / 100d,
                            OverlapBackgroundColor = BindingContextPageModel.OverlapBackgroundColor.ToHex(),
                            TextColor = BindingContextPageModel.TextColor.ToHex(),
                            Title = BindingContextPageModel.Title,
                            TitleFontFamily = BindingContextPageModel.TitleFontFamily,
                            TitleFontSize = BindingContextPageModel.TitleFontSize,
                            ContentBlocks = BindingContextPageModel.ContentBlocks.ToArray()
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

        private void PickBackgroundImageButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.ImagePickPage(BackgroundImagePicked_Callback, BindingContextPageModel.BackgroundImage));
        }

        private void AddContentBlockButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Block.TextContentBlockConfigurationPage(TextContentBlockCreation_Callback));
        }

        private void ContentBlockOptionsButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var target = (sender as Xamarin.Forms.BindableObject).BindingContext as Templating.Presentation.Models.TextContentBlockModel;

            var extraOptions = new System.Collections.Generic.List<string>
            {
                OPTION_COMMON_EDIT
            };

            //if (targetFrameViewModel.CanOrderUp)
            //{
            //    extraOptions.Add(OPTION_FRAME_ORDERTO_BEFORE);
            //}

            //if (targetFrameViewModel.CanOrderDown)
            //{
            //    extraOptions.Add(OPTION_FRAME_ORDERTO_AFTER);
            //}

            extraOptions.Add(OPTION_COMMON_DELETE);

            DisplayActionSheet("Opciones de Bloque Informativo", OPTION_COMMON_CANCEL, null, extraOptions.ToArray()).ContinueWith(actionSheetTask =>
            {
                switch (actionSheetTask.Result)
                {
                    case OPTION_COMMON_EDIT:
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            this.NavigationPushPageAsync(new Block.TextContentBlockConfigurationPage(target, TextContentBlockEdition_Callback));
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

        private void TitleFontFamilyClearButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.TitleFontFamily = null;
        }

        private void TitleFontFamilyPickButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.EmbeddedFontFamilyNamePickPage(TitleFontFamilyPicked_Callback));
        }

        private void TitleFontFamilyPicked_Callback(string selection)
        {
            BindingContextPageModel.TitleFontFamily = selection;
        }

        private void BackgroundImagePicked_Callback(Support.Presentation.Models.View.ImageViewModel selection)
        {
            BindingContextPageModel.BackgroundImage = selection;
        }

        private void TextContentBlockCreation_Callback(Templating.Presentation.Models.TextContentBlockModel model)
        {
            model.Priority = BindingContextPageModel.ContentBlocks.Count;

            BindingContextPageModel.ContentBlocks.Add(model);
        }

        private void TextContentBlockEdition_Callback(Templating.Presentation.Models.TextContentBlockModel model)
        {
            var target = BindingContextPageModel.ContentBlocks.First(item => item.Id == model.Id);

            target.Header = model.Header;
            target.HeaderFontSize = model.HeaderFontSize;
            target.IsHeaderVisible = model.IsHeaderVisible;
            target.Content = model.Content;
            target.ContentFontSize = model.ContentFontSize;
            target.ContentMaxLine = model.ContentMaxLine;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            placardViewModel = null;
            successfulCompleteCallbackAction = null;
        }
    }
}