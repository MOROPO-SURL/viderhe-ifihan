using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Factories;
using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Descriptors;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Pages
{
    public partial class AdvicesMarqueeOverlayConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<AdvicesMarqueeOverlayConfigurationPageModel>
    {
        private System.Action<string> successfulCompleteCallbackAction;

        public AdvicesMarqueeOverlayConfigurationPage(string serializedContext, System.Action<string> successfulCompleteCallbackAction)
            : base(AdvicesMarqueeOverlayConfigurationPageModelFactory.Build(serializedContext))
        {
            InitializeComponent();

            Title = string.Format("Configurar Mascara ({0})", AdvicesMarqueeOverlayDescriptor.NAME);

            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopPageAsync();

            successfulCompleteCallbackAction.Invoke(Newtonsoft.Json.JsonConvert.SerializeObject(new Overlaying.Presentation.Models.Context.AdvicesMarqueeOverlayContextModel
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