namespace SmartSolucionesCuba.Viderhe.Cloud.Models.SignalR
{
    public class PlayerContextSignalRModel
    {
        public PlayerContextSignalRModel()
        {
            AudioEnabled = false;
            AudioLevel = -1;
        }

        public string ConnectionId { get; set; }

        public string PlayerId { get; set; }

        public System.Guid AccountId { get; set; }

        public int AudioLevel { get; set; }


        public bool AudioEnabled { get; set; }
    }
}
