namespace SmartSolucionesCuba.Viderhe.Cloud.SignalR.Connect.Dashboard.Clients
{
    public interface IDashboardClient
    {
        System.Threading.Tasks.Task PlayerConnected(string playerId);
        System.Threading.Tasks.Task PlayerDisconnected(string playerId);
        System.Threading.Tasks.Task PlayerUpdateEnvironmentConfiguration(string playerId, int audioLevel, bool audioEnabled);
        System.Threading.Tasks.Task PlayingPlacard(string playerId, System.Guid placardId);
    }
}
