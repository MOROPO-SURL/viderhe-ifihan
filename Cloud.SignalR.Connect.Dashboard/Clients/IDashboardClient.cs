namespace MOROPO.VIDERHE.Cloud.SignalR.Connect.Dashboard.Clients
{
    public interface IDashboardClient
    {
        System.Threading.Tasks.Task OnPlayerConnectedAsync(string playerId);
        System.Threading.Tasks.Task OnPlayerDisconnectedAsync(string playerId);
        System.Threading.Tasks.Task OnPlayerUpdateEnvironmentConfigurationAsync(string playerId, int audioLevel, bool audioEnabled);
        System.Threading.Tasks.Task OnPlayingPlacardAsync(string playerId, System.Guid placardId);
        System.Threading.Tasks.Task OnPlayerActionRequestResultAsync(string playerId, bool success);
    }
}
