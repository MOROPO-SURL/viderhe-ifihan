namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Models.View
{
    public class SessionViewModel
    {
        public string UserName { get; set; }

        public System.Guid AccountId { get; set; }

        public string AccountName { get; set; }

        public Cloud.Api.Common.Models.PersonIdentityDisplayModel Identity { get; set; }

        public override string ToString()
        {
            if (Identity.LastName == null) return Identity.Name;

            return string.Format("{0} {1}", Identity.Name, Identity.LastName);
        }
    }
}
