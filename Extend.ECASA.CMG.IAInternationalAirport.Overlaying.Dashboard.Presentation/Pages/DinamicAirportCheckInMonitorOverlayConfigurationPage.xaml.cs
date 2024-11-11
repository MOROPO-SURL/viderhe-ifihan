using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Behaviors.Contract;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Dashboard.Presentation.Pages
{
    public partial class DinamicAirportCheckInMonitorOverlayConfigurationPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<DinamicAirportCheckInMonitorOverlayConfigurationPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Collections.Generic.List<IFormFieldValidationBehavior> validationBehaviors;

        private System.Action<string> successfulCompleteCallbackAction;

        public DinamicAirportCheckInMonitorOverlayConfigurationPage(string serializedContext, System.Action<string> successfulCompleteCallbackAction)
            : base(Factories.DinamicAirportCheckInMonitorOverlayConfigurationPageModelFactory.Build(serializedContext))
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

            BindingContextPageModel.IsBusy = true;

            var apiConnectClient = new Cloud.Api.Connect.Clients.PlayersApiConnectClient(Xamarin.Forms.DependencyService.Get<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            apiConnectClient.GetAsync().ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception != null || task.IsCanceled)
                    {
                        this.NavigationPopPageAsync().ContinueWith(_ =>
                        {
                            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                            {
                                Xamarin.Forms.DependencyService.Get<Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade>().HandleException(task.Exception);
                            });
                        });

                        return;
                    }

                    var currentNumber = BindingContextPageModel.Number;

                    BindingContextPageModel.Number = -1;

                    var maxNumber = 0;

                    var unavailableNumbers = new System.Collections.Generic.List<int>();

                    foreach (var item in task.Result)
                    {
                        if (item.OverlayId != Descriptors.DinamicAirportCheckInMonitorOverlayDescriptor.ID) continue;

                        var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Overlaying.Presentation.Models.Context.DinamicAirportCheckInMonitorOverlayContextModel>(item.SerializedOverlayContext);

                        unavailableNumbers.Add(context.Number);

                        if (context.Number > maxNumber) maxNumber = context.Number;
                    }

                    unavailableNumbers.Sort();

                    var availableNumbers = new System.Collections.Generic.List<int>();

                    if (unavailableNumbers.Count > 0)
                    {
                        for (int i = 1; i < maxNumber; i++)
                        {
                            if (unavailableNumbers.Contains(i)) continue;

                            availableNumbers.Add(i);
                        }
                    }

                    var aditionStart = maxNumber + 1;
                    var aditionCount = maxNumber + (5 - availableNumbers.Count);

                    for (int i = aditionStart; i <= aditionCount; i++)
                    {
                        availableNumbers.Add(i);
                    }

                    if (currentNumber != -1)
                    {
                        availableNumbers.Add(currentNumber);

                        availableNumbers.Sort();
                    }

                    BindingContextPageModel.AvailableNumbers = availableNumbers.ToArray();
                    BindingContextPageModel.Number = currentNumber;
                    BindingContextPageModel.IsBusy = false;

                    IsEnabled = true;
                });
            });
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

            successfulCompleteCallbackAction.Invoke(Newtonsoft.Json.JsonConvert.SerializeObject(new Overlaying.Presentation.Models.Context.DinamicAirportCheckInMonitorOverlayContextModel
            {
                APIServer = BindingContextPageModel.APIServer,
                UseSSL = BindingContextPageModel.UseSSL,
                AllowAnyCertificate = BindingContextPageModel.AllowAnyCertificate,
                APIKey = BindingContextPageModel.APIKey,
                UpdateInterval = BindingContextPageModel.UpdateInterval,
                Number = BindingContextPageModel.Number,
                UseCarrierColors = BindingContextPageModel.UseCarrierColors,
                PrimaryBackgroundColor = BindingContextPageModel.PrimaryBackgroundColor.ToHex(),
                PrimaryTextColor = BindingContextPageModel.PrimaryTextColor.ToHex(),
                SecoundaryBackgroundColor = BindingContextPageModel.SecoundaryBackgroundColor.ToHex(),
                SecoundaryTextColor = BindingContextPageModel.SecoundaryTextColor.ToHex(),
                AccentColor = BindingContextPageModel.AccentColor.ToHex(),
                PrePresentationTime = BindingContextPageModel.PrePresentationTime,
                PostPresentationTime = BindingContextPageModel.PostPresentationTime,
                PreCheckInHeadLabel = BindingContextPageModel.PreCheckInHeadLabel,
                OpenCheckInLabel = BindingContextPageModel.OpenCheckInLabel,
                ClosedCheckInLabel = BindingContextPageModel.ClosedCheckInLabel
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