namespace SmartSolucionesCuba.Viderhe.Cloud.SignalR.Connect.Dashboard.Hubs
{
    public interface IDashboardHub
    {
        void PlayerPresentNextFrame(string[] playerIds);

        void PlayerPresentPreviousFrame(string[] playerIds);

        void PlayerPresentInterventionScreenplay(string[] playerIds, System.Guid screenplayId);

        void PlayerPresentInterventionPlacard(string[] playerIds, System.Guid placardId);

        void PlayerRestartScreenplay(string[] playerIds, Common.Enumerations.ScreenplayHandlingImmediacyMode immediancyMode);

        void PlayerReloadScreenplay(string[] playerIds, Common.Enumerations.ScreenplayHandlingImmediacyMode immediancyMode);

        void PlayerSetAudioEnabled(string[] playerIds, bool enabled);

        void PlayerSetAudioLevel(string[] playerIds, int percent);

        void PlayerClose(string[] playerIds, bool restart = false);

        void PlayerShutdown(string[] playerIds, bool restart = false);
    }
}
