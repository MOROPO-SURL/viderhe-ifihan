namespace SmartSolucionesCuba.Viderhe.Extend.UICCamaguey.Templating.Presentation.Models.View
{
    public class CoLabHackathonTeamPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        public string Chalange { get; set; }

        public string TeamName { get; set; }

        public string MainMemberName { get; set; }

        public Xamarin.Forms.ImageSource MainMemberImageSource { get; set; }

        public string CoMemberName { get; set; }

        public Xamarin.Forms.ImageSource CoMemberImageSource { get; set; }
    }
}
