namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions
{
    public static class ImageDisplayModelExtensions
    {
        public static Xamarin.Forms.ImageSource ToImageSource(this Service.ECASA.CMG.InterFIDS.API.Common.Models.ImageDisplayModel target, Overlaying.Presentation.Models.Context.DinamicAirportCheckInMonitorOverlayContextModel context)
        {
            return Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/media/images/{2}.{3}", context.UseSSL ? "https" : "http", context.APIServer, target.Id, target.Extension))); ;
        }
    }
}
