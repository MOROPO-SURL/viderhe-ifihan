namespace SmartSolucionesCuba.Viderhe.Extend.UICCamaguey.Templating.Models.Context
{
    public class CoLabHackathonTeamPlacardContextModel : Common.Templating.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public string Chalange { get; set; }

        public string TeamName { get; set; }

        public string MainMemberName { get; set; }

        public System.Guid MainMemberImageId { get; set; }

        public string CoMemberName { get; set; }

        public System.Guid CoMemberImageId { get; set; }
    }
}
