namespace SmartSolucionesCuba.Viderhe.Extend.HotelOTT.Management.Dashboard.Presentation.Models.Page
{
    public class ApiKeyDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string name;
        private string token;
        private bool enabled;
        private bool hasFullAccess;
        private System.DateTime? expirateAt;
        private string host;

        public ApiKeyDefinitionPageModel()
        {
            Id = System.Guid.NewGuid();
            Roles = new System.Collections.ObjectModel.ObservableCollection<MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.RoleDisplayModel>();
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Token { get => token; set => SetProperty(ref token, value); }

        public bool Enabled { get => enabled; set => SetProperty(ref enabled, value); }

        public bool HasFullAccess { get => hasFullAccess; set => SetProperty(ref hasFullAccess, value); }

        public System.DateTime? ExpirateAt { get => expirateAt; set => SetProperty(ref expirateAt, value); }

        public string Host { get => host; set =>SetProperty(ref host, value); }

        public System.Collections.ObjectModel.ObservableCollection<MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Models.RoleDisplayModel> Roles { get; set; }
    }
}
