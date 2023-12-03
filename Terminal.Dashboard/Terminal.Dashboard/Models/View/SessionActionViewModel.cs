namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.View
{
    public class SessionActionViewModel : ActionViewModel
    {
        private ModeratorViewModel moderator;

        public ModeratorViewModel Moderator { get => moderator; set => SetProperty(ref moderator, value); }
    }
}
