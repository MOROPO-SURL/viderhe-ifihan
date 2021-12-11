namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models
{
    public class AuthenticatedSessionModel
    {
        public string Token { get; set; }

        public string Type { get; set; }

        public int ExpiresInSecond { get; set; }

        public ModeratorDisplayModel Moderator { get; set; }
    }
}
