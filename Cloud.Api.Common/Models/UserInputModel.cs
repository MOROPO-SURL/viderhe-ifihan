namespace MOROPO.VIDERHE.Cloud.Api.Common.Models
{
    public class UserInputModel
    {
        public string Id { get; set; }

        public bool Enabled { get; set; }

        public bool PasswordChangeRequired { get; set; }

        public string NewPassword { get; set; }
    }
}
