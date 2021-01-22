using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Dashboard.Presentation.Pages
{
    public partial class AdvicesMarqueeOverlayConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.AdvicesMarqueeOverlayConfigurationPageModel>
    {
        private System.Action<string> successfulCompleteCallbackAction;

        public AdvicesMarqueeOverlayConfigurationPage(string serializedContext, System.Action<string> successfulCompleteCallbackAction)
            : base(Factories.AdvicesMarqueeOverlayConfigurationPageModelFactory.Build(serializedContext))
        {
            InitializeComponent();

            Title = string.Format("Configurar Mascara ({0})", Descriptors.AdvicesMarqueeOverlayDescriptor.NAME);

            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopPageAsync();

            successfulCompleteCallbackAction.Invoke(Newtonsoft.Json.JsonConvert.SerializeObject(new Overlaying.Presentation.Models.Context.AdvicesMarqueeOverlayContextModel
            {
                ServerName = BindingContextPageModel.ServerName?.Trim(),
                IsSecureServer = BindingContextPageModel.IsSecureServer,
                Head = BindingContextPageModel.Head?.Trim(),
                Tail = BindingContextPageModel.Tail?.Trim(),
                AdviseSeparator = BindingContextPageModel.AdviseSeparator?.Trim()
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