namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class AccountTextBridge
    {
        public System.Guid AccountId { get; set; }

        public Account Account { get; set; }

        public System.Guid TextId { get; set; }

        public Text Text { get; set; }
    }
}
