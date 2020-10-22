namespace SmartSolucionesCuba.Videre.Cloud.Persistence.Entities
{
    public class AccountTemplateExclusionBridge
    {
        public System.Guid AccountId { get; set; }

        public Account Account { get; set; }

        public System.Guid TemplateId { get; set; }

        public Template Template { get; set; }
    }
}
