namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.View
{
    public class GradientViewModel
    {
        public System.Guid Id { get; set; }

        public System.DateTime CreateAt { get; set; }

        public MagicGradients.IGradientSource Source { get; set; }

        public string About { get; set; }
    }
}
