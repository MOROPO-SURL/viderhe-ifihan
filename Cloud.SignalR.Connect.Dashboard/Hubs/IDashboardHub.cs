namespace SmartSolucionesCuba.Videre.Cloud.SignalR.Connect.Dashboard.Hubs
{
    public interface IDashboardHub
    {
        void PlayerPresentNextFrame(string playerId);

        void PlayerPresentPreviousFrame(string playerId);

        void PlayerRestarScreenplay(string playerId, Common.Enumerations.ScreenplayHandlingImmediacyMode immediancyMode);

        void PlayerReloadScreenplay(string playerId, Common.Enumerations.ScreenplayHandlingImmediacyMode immediancyMode);

        void PlayerSetAudioLevel(string playerId, int percent);

        void PlayerShutdown(string playerId, bool restart = false);
    }
}
