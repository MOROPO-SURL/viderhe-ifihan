namespace SmartSolucionesCuba.Videre.Terminal.Player.Helpers.Facade
{
    public interface IPlatformControlHelperFacade
    {
        void SetAudioLevel(int percent);

        int GetAudioLevel();

        void SetAudioEnabled(bool enabled);

        bool IsAudioEnabled();

        void Shutdown(bool restart);
    }
}
