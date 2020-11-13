using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Videre.Extend.Essential.Overlaying.Dashboard.Presentation.Pages
{
    public partial class SimpleHighlightsOverlayConfigurationPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.SimpleHighlightsOverlayConfigurationPageModel>
    {
        private System.Action<string> successfulCompleteCallbackAction;

        public SimpleHighlightsOverlayConfigurationPage(string serializedContext, System.Action<string> successfulCompleteCallbackAction)
            : base(Factories.SimpleHighlightsOverlayConfigurationPageModelFactory.Build(serializedContext))
        {
            InitializeComponent();

            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopPageAsync();

            successfulCompleteCallbackAction.Invoke(Newtonsoft.Json.JsonConvert.SerializeObject(new Overlaying.Presentation.Models.Context.SimpleHighlightsContextModel
            {
                Header = BindingContextPageModel.Header,
                Highlights = BindingContextPageModel.Highlights
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