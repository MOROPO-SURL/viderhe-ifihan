namespace SmartSolucionesCuba.Viderhe.Cloud.SignalR.Connect.Dashboard.Hubs
{
    public interface IDashboardHub
    {
        void PlayerPresentNextFrame(string playerId);

        void PlayerPresentPreviousFrame(string playerId);

        void PlayerPresentInterventionScreenplay(string playerId, System.Guid screenplayId);

        void PlayerPresentInterventionPlacard(string playerId, System.Guid placardId);

        void PlayerRestarScreenplay(string playerId, Common.Enumerations.ScreenplayHandlingImmediacyMode immediancyMode);

        void PlayerReloadScreenplay(string playerId, Common.Enumerations.ScreenplayHandlingImmediacyMode immediancyMode);

        void PlayerSetAudioEnabled(string playerId, bool enabled);

        void PlayerSetAudioLevel(string playerId, int percent);

        void PlayerClose(string playerId, bool restart = false);

        void PlayerShutdown(string playerId, bool restart = false);
    }
}
