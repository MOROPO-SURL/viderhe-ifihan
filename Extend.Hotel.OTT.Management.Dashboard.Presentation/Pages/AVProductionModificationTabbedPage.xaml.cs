namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Pages
{
    public partial class AVProductionModificationTabbedPage : XFToolKit.Mvvm.Pages.TabbedPage
    {
        public AVProductionModificationTabbedPage(System.Action definitionCallbackAction, MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.AVProductionDisplayModel target)
        {
            InitializeComponent();

            Children.Add(new AVProductionGeneralDefinitionPage(definitionCallbackAction, target));
            Children.Add(new AVProductionImagesDefinitionPage(definitionCallbackAction, target));
        }
    }
}