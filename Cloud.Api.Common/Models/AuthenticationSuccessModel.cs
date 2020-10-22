namespace SmartSolucionesCuba.Videre.Cloud.Api.Common.Models
{
    public class AuthenticationSuccessModel
    {
        public string Token { get; set; }

        public string Type { get; set; }

        public int ExpiresInSecond { get; set; }

        public PersonIdentityDisplayModel Identity { get; set; }
    }
}
