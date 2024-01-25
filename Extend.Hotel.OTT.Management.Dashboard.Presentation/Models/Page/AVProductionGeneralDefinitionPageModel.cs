using MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models;
using System.Collections.ObjectModel;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Models.Page
{
    public class AVProductionGeneralDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string title;
        private bool enabled;
        private System.TimeSpan duration;
        private int year;
        private string about;
        private string argument;
        private Service.Hotel.OTT.Persistence.Enumerations.Language language;
        private AVCategoryDisplayModel category;
        private int rate;
        private int? ageEdge;
        private CountryDisplayModel country;

        public AVProductionGeneralDefinitionPageModel()
        {
            Id = System.Guid.NewGuid();
            Rate = 5;
            Duration = System.TimeSpan.FromMinutes(45);
            Language = Service.Hotel.OTT.Persistence.Enumerations.Language.Spanish;

            Genres = new ObservableCollection<AVGenreDisplayModel>();
            Countries = new ObservableCollection<CountryDisplayModel>();
            ProducerHouses = new ObservableCollection<AVProducerHouseDisplayModel>();

            AvailableCategories = new ObservableCollection<AVCategoryDisplayModel>();
            AvailableCountries = new ObservableCollection<CountryDisplayModel>();
        }

        public System.Guid Id { get; set; }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public bool Enabled { get => enabled; set => SetProperty(ref enabled, value); }

        public System.TimeSpan Duration { get => duration; set => SetProperty(ref duration, value); }

        public int Year { get => year; set => SetProperty(ref year, value); }

        public string About { get => about; set => SetProperty(ref about, value); }

        public string Argument { get => argument; set => SetProperty(ref argument, value); }

        public Service.Hotel.OTT.Persistence.Enumerations.Language Language { get => language; set => SetProperty(ref language, value); }

        public AVCategoryDisplayModel Category { get => category; set => SetProperty(ref category, value); }

        public int Rate { get => rate; set => SetProperty(ref rate, value); }

        public int? AgeEdge { get => ageEdge; set => SetProperty(ref ageEdge, value); }

        public CountryDisplayModel Country { get => country; set => SetProperty(ref country, value); }

        public ObservableCollection<AVGenreDisplayModel> Genres { get; set; }

        public ObservableCollection<AVProducerHouseDisplayModel> ProducerHouses { get; set; }

        public ObservableCollection<CountryDisplayModel> Countries { get; set; }

        public ObservableCollection<AVCategoryDisplayModel> AvailableCategories { get; private set; }

        public ObservableCollection<CountryDisplayModel> AvailableCountries { get; private set; }
    }
}
