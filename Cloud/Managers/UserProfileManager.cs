using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Models.View.Contrat;

namespace MOROPO.VIDERHE.Cloud.Managers
{
    public class UserProfileManager : Framework.Guama.Core.Presentation.Web.Security.Managers.Facade.IUserProfileManagerFacade
    {
        public IUserProfileViewModel GetUserProfile(string username)
        {
            return new Models.View.UserProfileViewModel();
        }

        public void PreValidateUserProfile(string username, IUserProfileViewModel profileModel, Microsoft.AspNetCore.Mvc.Controller controller)
        {
        }

        public void UpdateUserProfile(string username, IUserProfileViewModel profileModel)
        {
        }
    }
}
