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
                    BackgroundColor = Xamarin.Forms.Color.FromHex(context.BackgroundColor),
                    AccentColor = Xamarin.Forms.Color.FromHex(context.AccentColor),
                    PrePresentationTime = context.PrePresentationTime,
                    PostPresentationTime = context.PostPresentationTime
                };
            }
            catch
            {
                return new Models.Page.DinamicAirportCheckInMonitorOverlayConfigurationPageModel();
            }
        }
    }
}
