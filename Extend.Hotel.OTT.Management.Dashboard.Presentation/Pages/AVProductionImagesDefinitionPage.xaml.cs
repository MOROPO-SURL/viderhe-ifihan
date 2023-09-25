using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Pages
{
    public partial class AVProductionImagesDefinitionPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.AVProductionImagesDefinitionPageModel>
    {
        private readonly System.Action definitionCallbackAction;

        private bool hasChangesFlag;

        public AVProductionImagesDefinitionPage(System.Action definitionCallbackAction, MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.AVProductionDisplayModel target) : base(new Models.Page.AVProductionImagesDefinitionPageModel())
        {
            InitializeComponent();

            this.definitionCallbackAction = definitionCallbackAction;
        }

        protected override bool OnBackButtonPressed()
        {
            if (hasChangesFlag)
            {
                this.NavigationPopPageAsync();

                definitionCallbackAction.Invoke();

                return true;
            }

            return false;
        }

        private void PageModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            hasChangesFlag = true;
        }

        private void PickPosterImageButton_Clicked(object sender, System.EventArgs eventArgs)
        {

        }

        private void PickPlacardImageButton_Clicked(object sender, System.EventArgs eventArgs)
        {

        }
    }
}