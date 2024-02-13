namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class AVProductionImagesInputModel
    {
        public byte[] PosterImageContent { get; set; }

        public string PosterImageExtension { get; set; }

        public System.Guid? PosterImageId { get; set; }

        public byte[] PlacardImageContent { get; set; }

        public string PlacardImageExtension { get; set; }

        public System.Guid? PlacardImageId { get; set; }
    }
}
