namespace SmartSolucionesCuba.Videre.Terminal.Player.Helpers.Facade
{
    public interface IPlatformControlHelperFacade
    {
        void SetAudioLevel(int percent);

        int AudioLevel { get; }

        void SetAudioEnabled(bool enabled);

        bool IsAudioEnabled { get; }

        void Close(bool restart);

        System.Threading.Tasks.Task ShutdownAsync(bool restart);
    }
}
