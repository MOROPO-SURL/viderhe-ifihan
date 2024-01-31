using MOROPO.VIDERHE.Support.Presentation.Dashboard.Behaviors.Contract;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages.Contract;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Dashboard.Presentation.Pages
{
    public partial class AuroraOTTHotelTVOverlayConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.OTTHotelTVOverlayConfigurationPageModel>, IValidableFormPage
    {
        private readonly System.Collections.Generic.List<IFormFieldValidationBehavior> validationBehaviors;

        private System.Action<string> successfulCompleteCallbackAction;

        public AuroraOTTHotelTVOverlayConfigurationPage(string serializedContext, System.Action<string> successfulCompleteCallbackAction)
            : base(Factories.OTTHotelTVOverlayConfigurationPageModelFactory.Build(serializedContext))
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

            System.Threading.Tasks.Task.Run(async () => 
            {
                var screenplayAPIConnectClient = new Cloud.Api.Connect.Clients.ScreenplaysApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var screenplays = await screenplayAPIConnectClient.GetAsync();

                var brandChannelScreenplayId = BindingContextPageModel.BrandChannelScreenplay?.Id;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    BindingContextPageModel.BrandChannelScreenplay = null;

                    BindingContextPageModel.AvailableScreenplays = screenplays;

                    BindingContextPageModel.BrandChannelScreenplay = screenplays.FirstOrDefault(model => model.Id == brandChannelScreenplayId);
                });
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            successfulCompleteCallbackAction = null;
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

            successfulCompleteCallbackAction.Invoke(Newtonsoft.Json.JsonConvert.SerializeObject(new Overlaying.Presentation.Models.Context.OTTHotelTVOverlayContextModel
            {
                RoomId = BindingContextPageModel.RoomId,
                BrandChannelScreenplayId = BindingContextPageModel.BrandChannelScreenplay.Id
            }));
        }

        private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            this.NavigationPopPageAsync();
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