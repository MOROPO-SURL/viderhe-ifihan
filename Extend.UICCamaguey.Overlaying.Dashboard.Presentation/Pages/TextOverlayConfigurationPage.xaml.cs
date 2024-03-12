using MOROPO.VIDERHE.Extend.UICCamaguey.Overlaying.Dashboard.Presentation.Factories;
using MOROPO.VIDERHE.Extend.UICCamaguey.Overlaying.Dashboard.Presentation.Models.Page;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.UICCamaguey.Overlaying.Dashboard.Presentation.Pages
{
    public partial class TextOverlayConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<TextOverlayConfigurationPageModel>
    {
        private System.Action<string> successfulCompleteCallbackAction;

        public TextOverlayConfigurationPage(string serializedContext, System.Action<string> successfulCompleteCallbackAction)
            : base(TextOverlayConfigurationPageModelFactory.Build(serializedContext))
        {
            InitializeComponent();

            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopPageAsync();

            successfulCompleteCallbackAction.Invoke(Newtonsoft.Json.JsonConvert.SerializeObject(new Overlaying.Presentation.Models.Context.TextOverlayContextModel
            {
                Head = BindingContextPageModel.Head,
                Tail = BindingContextPageModel.Tail,
                Text = BindingContextPageModel.Text
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