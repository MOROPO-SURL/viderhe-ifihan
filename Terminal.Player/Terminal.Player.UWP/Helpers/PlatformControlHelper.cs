[assembly: Xamarin.Forms.Dependency(typeof(SmartSolucionesCuba.Videre.Terminal.Player.UWP.Helpers.PlatformControlHelper))]

namespace SmartSolucionesCuba.Videre.Terminal.Player.UWP.Helpers
{
    public class PlatformControlHelper : Player.Helpers.Facade.IPlatformControlHelperFacade
    {
        public int GetAudioLevel()
        {
            return (int)Windows.UI.Xaml.ElementSoundPlayer.Volume * 100;
        }

        public bool IsAudioEnabled()
        {
            return Windows.UI.Xaml.ElementSoundPlayer.State != Windows.UI.Xaml.ElementSoundPlayerState.Off;
        }

        public void SetAudioEnabled(bool enabled)
        {
            Windows.UI.Xaml.ElementSoundPlayer.State = enabled ? Windows.UI.Xaml.ElementSoundPlayerState.On : Windows.UI.Xaml.ElementSoundPlayerState.Off;
        }

        public void SetAudioLevel(int percent)
        {
            Windows.UI.Xaml.ElementSoundPlayer.Volume = percent / 100;
        }

        public void Shutdown(bool restart)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("shutdown", string.Format("/{0} /t 0", restart ? "r" : "s"))
            {
                CreateNoWindow = true,
                UseShellExecute = false
            });
        }
    }
}
