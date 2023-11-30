using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.Page;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class EditUserProfilePageModel : FormPageModel
    {
        private string targetUserNewPassword;
        private string targetUserNewPasswordConfirmation;
        private string targetIdentityName;
        private string targetIdentityLastName;
        private Xamarin.Forms.ImageSource targetIdentityImageSource;
        private Framework.Guama.Identity.Persistence.Enumerations.Sex targetIdentitySex;
        private string targetIdentityAbout;

        public string TargetUserId { get; set; }

        public string TargetUserNewPassword { get => targetUserNewPassword; set => SetProperty(ref targetUserNewPassword, value); }

        public string TargetUserNewPasswordConfirmation { get => targetUserNewPasswordConfirmation; set => SetProperty(ref targetUserNewPasswordConfirmation, value); }

        public string TargetIdentityName { get => targetIdentityName; set => SetProperty(ref targetIdentityName, value); }

        public string TargetIdentityLastName { get => targetIdentityLastName; set => SetProperty(ref targetIdentityLastName, value); }

        public Xamarin.Forms.ImageSource TargetIdentityImageSource { get => targetIdentityImageSource; set => SetProperty(ref targetIdentityImageSource, value); }

        public string TargetIdentityImageContentType { get; set; }

        public Framework.Guama.Identity.Persistence.Enumerations.Sex TargetIdentitySex { get => targetIdentitySex; set => SetProperty(ref targetIdentitySex, value); }

        public string TargetIdentityAbout { get => targetIdentityAbout; set => SetProperty(ref targetIdentityAbout, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            TargetIdentityImageSource = null;
        }
    }
}
