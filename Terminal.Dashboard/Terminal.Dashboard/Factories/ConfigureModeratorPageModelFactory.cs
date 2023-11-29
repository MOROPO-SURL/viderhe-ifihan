using MOROPO.VIDERHE.Support.Presentation.Managers;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Factories
{
    public static class ConfigureModeratorPageModelFactory
    {
        public static Models.Page.ConfigureModeratorPageModel Build(Models.View.ModeratorViewModel target)
        {
            var result = new Models.Page.ConfigureModeratorPageModel();

            if (target == null) return result;

            result.TargetId = target.Model.Id;
            result.TargetUserId = target.Model.User.Id;
            result.TargetUserEnabled = target.Model.User.Enabled;
            result.TargetPrivileged = target.Model.IsPrivileged;
            result.TargetUserPasswordChangeRequired = target.Model.User.PasswordChangeRequired;
            result.TargetIdentityName = target.Model.Identity.Name;
            result.TargetIdentityLastName = target.Model.Identity.LastName;
            //result.TargetIdentityBornDate = target.Model.Identity.BornDate;
            //result.TargetIdentityAlias = target.Model.Identity.Alias;
            //result.TargetIdentityCivilStatus = target.Model.Identity.CivilStatus;
            result.TargetIdentitySex = target.Model.Identity.Sex;
            result.TargetIdentityImageId = target.Model.Identity.Image?.Id;
            result.TargetIdentityImageSource = target.Model.Identity.Image != null ?
                Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("{0}://{1}/media/moderator/{2}", SessionMemoryManager.Instance.UseSSL ? "https" : "http", SessionMemoryManager.Instance.Host, target.Model.Identity.Image.Id))) :
                Xamarin.Forms.ImageSource.FromUri(new System.Uri(Helpers.ConstantProvisioningHelper.Instance.FallbackUserProfileImageUrl));

            return result;
        }
    }
}
