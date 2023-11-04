namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Extensions
{
    public static class ImageDisplayModelExtensions
    {
        public static Xamarin.Forms.ImageSource ToImageSource(this MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models.ImageDisplayModel target)
        {
            return Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/media/images/{2}.{3}", "http", Managers.SessionManager.Instance.Server, target.Id, target.Extension)));
        }
    }
}
