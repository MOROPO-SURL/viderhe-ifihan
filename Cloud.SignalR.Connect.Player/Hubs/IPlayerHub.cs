namespace MOROPO.VIDERHE.Cloud.SignalR.Connect.Player.Hubs
{
    public interface IPlayerHub
    {
        void NotifyPlayingPlacard(System.Guid placardId);

        void UpdateEnvironmentConfiguration(int audioLevel, bool audioEnabled);
    }
}
