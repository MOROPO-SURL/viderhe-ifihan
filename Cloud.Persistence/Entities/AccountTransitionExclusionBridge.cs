namespace SmartSolucionesCuba.Videre.Cloud.Persistence.Entities
{
    public class AccountTransitionExclusionBridge
    {
        public System.Guid AccountId { get; set; }

        public Account Account { get; set; }

        public System.Guid TransitionId { get; set; }

        public Transition Transition { get; set; }
    }
}
