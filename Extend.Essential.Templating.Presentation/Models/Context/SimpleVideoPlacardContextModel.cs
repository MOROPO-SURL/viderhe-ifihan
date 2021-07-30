namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Models.Context
{
    public class SimpleVideoPlacardContextModel : Common.Templating.Presentation.Models.Context.AbstractPlacardContextModel
    {
        public System.Guid VideoId { get; set; }

        public string VideoExtension { get; set; }

        public System.Guid ThumbnailId { get; set; }

        public string ThumbnailContentType { get; set; }
    }
}