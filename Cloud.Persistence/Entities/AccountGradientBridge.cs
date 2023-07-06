namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class AccountGradientBridge
    {
        public System.Guid AccountId { get; set; }

        public Account Account { get; set; }

        public System.Guid GradientId { get; set; }

        public Gradient Gradient { get; set; }
    }
}
