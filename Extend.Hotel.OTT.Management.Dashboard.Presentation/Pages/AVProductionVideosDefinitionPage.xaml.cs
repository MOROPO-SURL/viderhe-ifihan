using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Pages
{
    public partial class AVProductionVideosDefinitionPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.AVProductionVideosDefinitionPageModel>
    {
        private System.Action definitionCallbackAction;

        public AVProductionVideosDefinitionPage(System.Action definitionCallbackAction, Service.Hotel.OTT.API.Common.Models.AVProductionDisplayModel target)
            : base(Factories.AVProductionVideosDefinitionPageModelFactory.Build(target))
        {
            InitializeComponent();

            this.definitionCallbackAction = definitionCallbackAction;
        }

        protected override bool OnBackButtonPressed()
        {
            var rootPage = Parent as AVProductionModificationTabbedPage;

            rootPage.CurrentPage = rootPage.Children[0];

            return true;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            definitionCallbackAction = null;
        }
    }
}