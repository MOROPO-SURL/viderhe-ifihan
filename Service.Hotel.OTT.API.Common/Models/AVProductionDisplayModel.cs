using System.Linq;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models
{
    public class AVProductionDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.AVProduction, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Title { get; set; }

        public bool Enabled { get; set; }

        public int Duration { get; set; }

        public int Year { get; set; }

        public string About { get; set; }

        public string Argument { get; set; }

        public Persistence.Enumerations.Language Language { get; set; }

        public AVCategoryDisplayModel Category { get; set; }

        public int Rate { get; set; }

        public int? AgeEdge { get; set; }

        public CountryDisplayModel Country { get; set; }
        
        public ImageDisplayModel PosterImage { get; set; }

        public ImageDisplayModel PlacardImage { get; set; }

        public VideoDisplayModel TrailerVideo { get; set; }

        public VideoDisplayModel Video { get; set; }

        public long? FileSize { get; set; }

        public bool HasSubtitle { get; set; }

        public string VideoFormat { get; set; }

        public Persistence.Enumerations.VideoQuality? VideoQuality { get; set; }

        public string VideoResolution { get; set; }

        public AVGenreDisplayModel[] Genres { get; set; }

        public AVProducerHouseDisplayModel[] ProducerHouses { get; set; }

        public CountryDisplayModel[] Countries { get; set; }

        public void Import(Persistence.Entities.AVProduction entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Enabled = entity.Enabled;
            Duration = entity.Duration;
            Year = entity.Year;
            About = entity.About;
            Argument = entity.Argument;
            Language = entity.Language;
            Rate = entity.Rate;
            AgeEdge = entity.AgeEdge;
            Country = new CountryDisplayModel();
            FileSize = entity.FileSize;
            HasSubtitle = entity.HasSubtitle;
            VideoFormat = entity.VideoFormat;
            VideoQuality = entity.VideoQuality;
            VideoResolution = entity.VideoResolution;
            Genres = entity.GenreBridges.Select(bridge =>
            {
                var model = new AVGenreDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
            Countries = entity.CountryBridges.Select(bridge =>
            {
                var model = new CountryDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();

            Country.Import(entity.Country);

            if (entity.PosterImageId != null)
            {
                PosterImage = new ImageDisplayModel();

                PosterImage.Import(entity.PosterImage);
            }

            if (entity.PlacardImageId != null)
            {
                PlacardImage = new ImageDisplayModel();

                PlacardImage.Import(entity.PlacardImage);
            }

            if (entity.TrailerVideoId != null)
            {
                TrailerVideo = new VideoDisplayModel();

                TrailerVideo.Import(entity.TrailerVideo);
            }

            if (entity.VideoId != null)
            {
                Video = new VideoDisplayModel();

                Video.Import(entity.Video);
            }
        }
    }
}
