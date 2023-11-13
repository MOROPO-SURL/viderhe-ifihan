namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Extensions
{
    public static class ImageDisplayModelExtensions
    {
        public static Xamarin.Forms.ImageSource ToImageSource(this MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.ImageDisplayModel target, Models.View.Contract.AbstractInteroperablePlacardViewModel interoperableModel)
        {
            return Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/media/images/{2}.{3}", interoperableModel.UseSSL ? "https" : "http", interoperableModel.APIServer, target.Id, target.Extension))); ;
        }
    }
}
