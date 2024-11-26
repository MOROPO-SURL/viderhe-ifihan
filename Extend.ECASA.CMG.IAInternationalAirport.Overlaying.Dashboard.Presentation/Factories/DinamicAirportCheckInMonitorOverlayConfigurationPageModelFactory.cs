namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Dashboard.Presentation.Factories
{
    internal static class DinamicAirportCheckInMonitorOverlayConfigurationPageModelFactory
    {
        internal static Models.Page.DinamicAirportCheckInMonitorOverlayConfigurationPageModel Build(string serializedContext)
        {
            try
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Overlaying.Presentation.Models.Context.DinamicAirportCheckInMonitorOverlayContextModel>(serializedContext);

                return new Models.Page.DinamicAirportCheckInMonitorOverlayConfigurationPageModel
                {
                    APIServer = context.APIServer,
                    UseSSL = context.UseSSL,
                    AllowAnyCertificate = context.AllowAnyCertificate,
                    APIKey = context.APIKey,
                    UpdateInterval = context.UpdateInterval,
                    Number = context.Number,
                    UseCarrierColors = context.UseCarrierColors,
                    PrimaryBackgroundColor = Xamarin.Forms.Color.FromHex(context.PrimaryBackgroundColor),
                    PrimaryTextColor = Xamarin.Forms.Color.FromHex(context.PrimaryTextColor),
                    SecoundaryBackgroundColor = Xamarin.Forms.Color.FromHex(context.SecoundaryBackgroundColor),
                    SecoundaryTextColor = Xamarin.Forms.Color.FromHex(context.SecoundaryTextColor),
                    AccentColor = Xamarin.Forms.Color.FromHex(context.AccentColor),
                    PrePresentationTime = context.PrePresentationTime,
                    PostPresentationTime = context.PostPresentationTime,
                    PreCheckInHeadLabel = context.PreCheckInHeadLabel,
                    OpenCheckInLabel = context.OpenCheckInLabel,
                    ClosedCheckInLabel = context.ClosedCheckInLabel,
                    ShowClock = context.ShowClock,
                    InactivePresentationMode = context.InactivePresentationMode,
                    ActivePresentationMode = context.ActivePresentationMode
                };
            }
            catch
            {
                return new Models.Page.DinamicAirportCheckInMonitorOverlayConfigurationPageModel();
            }
        }
    }
}
