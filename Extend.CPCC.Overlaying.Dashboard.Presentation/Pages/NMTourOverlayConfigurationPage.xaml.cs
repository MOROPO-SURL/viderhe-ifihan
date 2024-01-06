using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Factories;
using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Descriptors;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Pages
{
    public partial class NMTourOverlayConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<NMTourOverlayConfigurationPageModel>
    {
        private System.Action<string> successfulCompleteCallbackAction;

        public NMTourOverlayConfigurationPage(string serializedContext, System.Action<string> successfulCompleteCallbackAction)
            : base(NMTourOverlayConfigurationPageModelFactory.Build(serializedContext))
        {
            InitializeComponent();

            Title = string.Format("Configurar Mascara ({0})", NMTourOverlayDescriptor.NAME);

            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;
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
                FailbackMessage = BindingContextPageModel.FailbackMessage
            }));
        }

        private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopPageAsync();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            successfulCompleteCallbackAction = null;
        }
    }
}