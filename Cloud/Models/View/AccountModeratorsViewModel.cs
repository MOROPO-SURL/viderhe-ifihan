namespace MOROPO.VIDERHE.Cloud.Models.View
{
    public class AccountModeratorsViewModel
    {
        public AccountModeratorsViewModel()
        {
            Moderators = new System.Collections.Generic.List<ModeratorDisplayViewModel>();
        }

        public AccountDisplayViewModel Account { get; set; }

        public System.Collections.Generic.List<ModeratorDisplayViewModel> Moderators { get; set; }
    }
}
