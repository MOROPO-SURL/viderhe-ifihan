namespace SmartSolucionesCuba.Viderhe.Cloud.SignalR.Connect.Player.Clients
{
    public interface IPlayerClient
    {
        System.Threading.Tasks.Task PresentNextFrame();
        System.Threading.Tasks.Task PresentPreviousFrame();
        System.Threading.Tasks.Task RestartScreenplay(Common.Enumerations.ScreenplayHandlingImmediacyMode immediancyMode);
        System.Threading.Tasks.Task ReloadScreenplay(Common.Enumerations.ScreenplayHandlingImmediacyMode immediancyMode);
        System.Threading.Tasks.Task SetAudioLevel(int percent);
        System.Threading.Tasks.Task SetAudioEnabled(bool enabled);
        System.Threading.Tasks.Task Close(bool restart);
        System.Threading.Tasks.Task Shutdown(bool restart);
    }
}
