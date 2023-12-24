using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Behaviors.Contract;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Dashboard.Presentation.Pages
{
    public partial class CorporativeMarqueeOverlayConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<CorporativeMarqueeOverlayConfigurationPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Collections.Generic.List<IFormFieldValidationBehavior> validationBehaviors;

        private System.Action<string> successfulCompleteCallbackAction;

        public CorporativeMarqueeOverlayConfigurationPage(string serializedContext, System.Action<string> successfulCompleteCallbackAction)
            : base(Factories.CorporativeMarqueeOverlayConfigurationPageModelFactory.Build(serializedContext))
        {
            validationBehaviors = new System.Collections.Generic.List<IFormFieldValidationBehavior>();

            InitializeComponent();

            this.successfulCompleteCallbackAction = successfulCompleteCallbackAction;

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            IsEnabled = true;

            if (BindingContextPageModel.InformationSourceKind != null) return;

            BindingContextPageModel.InformationSourceKind = Overlaying.Presentation.Enumerations.CorporativeInformationSourceKind.Managed;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            BindingContextPageModel.ResetValidationState();

            foreach (var validationBehavior in validationBehaviors)
            {
                var result = validationBehavior.Evaluate();

                if (!BindingContextPageModel.IsValid) continue;

                if (!result) BindingContextPageModel.IsValid = false;
            }

            if (!BindingContextPageModel.IsValid) return;

            this.NavigationPopPageAsync();

            var model = new Overlaying.Presentation.Models.Context.CorporativeMarqueeOverlayContextModel
            {
                InformationSourceKind = BindingContextPageModel.InformationSourceKind.Value,
                InformationSource = BindingContextPageModel.InformationSource,
                InformationSourceUpdateMinuteInterval = BindingContextPageModel.InformationSourceUpdateMinuteInterval,
                FailbackMessage = BindingContextPageModel.FailbackMessage,
                Head = BindingContextPageModel.Head,
                Tail = BindingContextPageModel.Tail,
                Separator = BindingContextPageModel.Separator,
                BackgroundColor = BindingContextPageModel.BackgroundColor.ToHex(),
                TextColor = BindingContextPageModel.TextColor.ToHex(),
                FrontierColor = BindingContextPageModel.FrontierColor.ToHex(),
                LogoOutlineColor = BindingContextPageModel.LogoOutlineColor.ToHex(),
                IsDateTimePresentationRequired = BindingContextPageModel.IsDateTimePresentationRequired
            };

            if (BindingContextPageModel.IsRectangle19x6LogoSizeModeSelected)
            {
                model.LogoSizeMode = Overlaying.Presentation.Enumerations.MarqueeLogoSizeMode.Rectangle19x6;
            }
            else if (BindingContextPageModel.IsRectangle4x3LogoSizeModeSelected)
            {
                model.LogoSizeMode = Overlaying.Presentation.Enumerations.MarqueeLogoSizeMode.Rectangle4x3;
            }
            else
            {
                model.LogoSizeMode = Overlaying.Presentation.Enumerations.MarqueeLogoSizeMode.Square1x1;
            }

            successfulCompleteCallbackAction.Invoke(Newtonsoft.Json.JsonConvert.SerializeObject(model));
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

        #region IValidableFormPage implementation

        public void AddValidationBehavior(IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Add(validationBehavior);
        }

        public void RemoveValidationBehavior(IFormFieldValidationBehavior validationBehavior)
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