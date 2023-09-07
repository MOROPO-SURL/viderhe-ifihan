namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Models.Page
{
    public class ApiKeyDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string name;
        private string token;
        private bool enabled;
        private bool hasFullAccess;
        private bool isExpirable;
        private System.DateTime expirateAtDate;
        private System.TimeSpan expirateAtTime;
        private string host;

        public ApiKeyDefinitionPageModel()
        {
            var tomorrow = System.DateTime.Now.AddDays(1);

            Id = System.Guid.NewGuid();
            Roles = new System.Collections.ObjectModel.ObservableCollection<MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.RoleDisplayModel>();
            expirateAtDate = tomorrow.Date;
            expirateAtTime = tomorrow.TimeOfDay;
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Token { get => token; set => SetProperty(ref token, value); }

        public bool Enabled { get => enabled; set => SetProperty(ref enabled, value); }

        public bool HasFullAccess { get => hasFullAccess; set => SetProperty(ref hasFullAccess, value); }

        public bool IsExpirable { get => isExpirable; set => SetProperty(ref isExpirable, value); }

        public System.DateTime ExpirateAtDate { get => expirateAtDate; set => SetProperty(ref expirateAtDate, value); }

        public System.TimeSpan ExpirateAtTime { get => expirateAtTime; set => SetProperty(ref expirateAtTime, value); }

        public string Host { get => host; set => SetProperty(ref host, value); }

        public System.Collections.ObjectModel.ObservableCollection<MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.RoleDisplayModel> Roles { get; set; }
    }
}
