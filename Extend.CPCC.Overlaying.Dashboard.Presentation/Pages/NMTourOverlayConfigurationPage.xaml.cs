using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Extensions;
using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Factories;
using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Descriptors;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Pages
{
    public partial class NMTourOverlayConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<NMTourOverlayConfigurationPageModel>
    {
        private const string CANCEL_OPTION = "Cancelar";
        private const string MODIFY_OPTION = "Modificar";
        private const string REMOVE_OPTION = "Eliminar";

        private int modifyIndex;

        private System.Action<string> successfulCompleteCallbackAction;

        public NMTourOverlayConfigurationPage(string serializedContext, System.Action<string> successfulCompleteCallbackAction)
            : base(NMTourOverlayConfigurationPageModelFactory.Build(serializedContext))
        {
            InitializeComponent();

            modifyIndex = -1;

            Title = string.Format("Configurar Mascara ({0})", NMTourOverlayDescriptor.NAME);

            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            successfulCompleteCallbackAction = null;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopPageAsync();

            successfulCompleteCallbackAction.Invoke(Newtonsoft.Json.JsonConvert.SerializeObject(new Overlaying.Presentation.Models.Context.NMTourOverlayContextModel
            {
                ServerName = BindingContextPageModel.ServerName?.Trim(),
                IsSecureServer = BindingContextPageModel.IsSecureServer,
                IsRequiredSecurityStrict = BindingContextPageModel.IsRequiredSecurityStrict,
                Head = BindingContextPageModel.Head?.Trim(),
                Tail = BindingContextPageModel.Tail?.Trim(),
                Separator = BindingContextPageModel.Separator?.Trim(),
                FailbackMessage = BindingContextPageModel.FailbackMessage,
                Title = BindingContextPageModel.Title,
                About = BindingContextPageModel.About,
                BannerImage = BindingContextPageModel.BannerImage.ToContextModel(),
                Sections = BindingContextPageModel.Sections.ToArray()
            }));
        }

        private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopPageAsync();
        }

        private void AddInteractiveSectionButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new NMTourOverlaySectionConfigurationPage(InteractiveSectionCreate_Callback));
        }

        private void PickBannerImageButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPushPageAsync(new Support.Presentation.Dashboard.Pages.ImagePickPage(BannerImagePicked_Callback, BindingContextPageModel.BannerImage));
        }

        private void OptionsButton_Clicked(object sender, System.EventArgs e)
        {
            DisplayActionSheet("Opciones", CANCEL_OPTION, REMOVE_OPTION, MODIFY_OPTION).ContinueWith(task =>
            {
                if (task.Result.Equals(CANCEL_OPTION)) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var model = (sender as Xamarin.Forms.BindableObject).BindingContext as Overlaying.Presentation.Models.Context.NMTourOverlaySectionContextModel;

                    switch (task.Result)
                    {
                        case MODIFY_OPTION:
                            modifyIndex = BindingContextPageModel.Sections.IndexOf(model);

                            this.NavigationPushPageAsync(new NMTourOverlaySectionConfigurationPage(model, InteractiveSectionModify_Callback));

                            break;

                        case REMOVE_OPTION:
                            DisplayAlert("Confirmar", "Está seguro que desea eliminar esta sección?", "Eliminar", "Cancelar").ContinueWith(_task =>
                            {
                                if (!_task.Result) return;

                                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                                {
                                    BindingContextPageModel.Sections.Remove(model);
                                });
                            });

                            break;
                    }
                });
            });
        }

        private void BannerImagePicked_Callback(Support.Presentation.Models.View.ImageViewModel selection)
        {
            BindingContextPageModel.BannerImage = selection;
        }

        private void InteractiveSectionCreate_Callback(Overlaying.Presentation.Models.Context.NMTourOverlaySectionContextModel model)
        {
            BindingContextPageModel.Sections.Add(model);
        }

        private void InteractiveSectionModify_Callback(Overlaying.Presentation.Models.Context.NMTourOverlaySectionContextModel model)
        {
            if (modifyIndex == -1) return;

            BindingContextPageModel.Sections[modifyIndex] = model;

            modifyIndex = -1;
        }
    }
}