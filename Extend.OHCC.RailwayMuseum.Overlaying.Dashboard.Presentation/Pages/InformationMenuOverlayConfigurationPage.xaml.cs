using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Overlaying.Dashboard.Presentation.Pages
{
    public partial class InformationMenuOverlayConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.InformationMenuOverlayConfigurationPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private System.Action<string> successfulCompleteCallbackAction;

        public InformationMenuOverlayConfigurationPage(string serializedContext, System.Action<string> successfulCompleteCallbackAction)
            : base(Factories.InformationMenuOverlayConfigurationPageModelFactory.Build(serializedContext))
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();

            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            BindingContextPageModel.ResetValidationState();

            foreach (var validationBehavior in validationBehaviors)
            {
                var result = validationBehavior.Evaluate();

                if (!BindingContextPageModel.IsValid) continue;

                if (!result) BindingContextPageModel.IsValid = false;
            }

            if (!BindingContextPageModel.IsValid) return;

            this.NavigationPopPageAsync();

            successfulCompleteCallbackAction.Invoke(Newtonsoft.Json.JsonConvert.SerializeObject(new Overlaying.Presentation.Models.Context.InformationMenuOverlayContextModel
            {
                RailwayMuseumAboutUri = BindingContextPageModel.RailwayMuseumAboutUri,
                RailwayMuseumOfferUri = BindingContextPageModel.RailwayMuseumOfferUri,
                RailwayMuseumBillboardUri = BindingContextPageModel.RailwayMuseumBillboardUri,
                OHCCAboutUri = BindingContextPageModel.OHCCAboutUri,
                OHCCOfferUri = BindingContextPageModel.OHCCOfferUri,
                OHCCBillboardUri = BindingContextPageModel.OHCCBillboardUri,
                CallToActionMessage = BindingContextPageModel.CallToActionMessage,
                CallToActionMessageFontSize = BindingContextPageModel.CallToActionMessageFontSize
            }));
        }

        private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            this.NavigationPopPageAsync();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            successfulCompleteCallbackAction = null;
        }

        #region IValidableFormPage implementation

        public void AddValidationBehavior(Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Add(validationBehavior);
        }

        public void RemoveValidationBehavior(Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Remove(validationBehavior);
        }

        public void AddValidationMessage(string label, string message)
        {
            BindingContextPageModel.ValidationMessages.Add(new Support.Presentation.Dashboard.Models.View.ValidationMessageViewModel
            {
                Caption = label,
                Message = message
            });
        }

        #endregion
    }
}