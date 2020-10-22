namespace SmartSolucionesCuba.Videre.Cloud.Managers
{
    public class UserProfileManager : SAPRESSC.Core.Web.Security.Managers.Facade.IUserProfileManagerFacade
    {
        public SAPRESSC.Core.Web.Security.Models.View.IUserProfileViewModel GetUserProfile(string username)
        {
            return new Models.View.UserProfileViewModel();
        }

        public void UpdateUserProfile(string username, SAPRESSC.Core.Web.Security.Models.View.IUserProfileViewModel profileModel)
        {
        }
    }
}
