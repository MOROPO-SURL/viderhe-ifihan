namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Pages
{
    public partial class AVProductionModificationTabbedPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.TabbedPage
    {
        public AVProductionModificationTabbedPage(System.Action definitionCallbackAction, Service.Hotel.OTT.API.Common.Models.AVProductionDisplayModel target)
        {
            InitializeComponent();

            Children.Add(new AVProductionGeneralDefinitionPage(definitionCallbackAction, target));
            Children.Add(new AVProductionImagesDefinitionPage(definitionCallbackAction, target));
        }
    }
}