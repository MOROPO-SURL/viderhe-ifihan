namespace SmartSolucionesCuba.Viderhe.Cloud.Persistence.Entities
{
    public class AccountModeratorBridge
    {
        public System.Guid AccountId { get; set; }

        public Account Account { get; set; }

        public System.Guid ModeratorId { get; set; }

        public Moderator Moderator { get; set; }
    }
}
