[assembly: Xamarin.Forms.Dependency(typeof(MOROPO.VIDERHE.Terminal.Player.Droid.Helpers.PlatformControlHelper))]

namespace MOROPO.VIDERHE.Terminal.Player.Droid.Helpers
{
    public class PlatformControlHelper : Player.Helpers.Facade.IPlatformControlHelperFacade
    {
        public int AudioLevel
        {
            get
            {
                var audioManager = (Android.Media.AudioManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.AudioService);

                return audioManager.GetStreamVolume(Android.Media.Stream.Music);
            }
        }

        public bool IsAudioEnabled
        {
            get
            {
                var audioManager = (Android.Media.AudioManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.AudioService);

                return audioManager.IsStreamMute(Android.Media.Stream.Music);
            }
        }

        public void SetAudioEnabled(bool enabled)
        {
            var audioManager = (Android.Media.AudioManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.AudioService);

            audioManager.AdjustStreamVolume(Android.Media.Stream.Music, enabled ? Android.Media.Adjust.Unmute : Android.Media.Adjust.Mute, Android.Media.VolumeNotificationFlags.RemoveSoundAndVibrate);
        }

        public void SetAudioLevel(int percent)
        {
            var audioManager = (Android.Media.AudioManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.AudioService);

            audioManager.SetStreamVolume(Android.Media.Stream.Music, percent, Android.Media.VolumeNotificationFlags.RemoveSoundAndVibrate);
        }

        public System.Threading.Tasks.Task ShutdownAsync(bool restart)
        {
            var shutdownIntent = new Android.Content.Intent(Android.Content.Intent.ActionShutdown);

            shutdownIntent.PutExtra("android.intent.extra.KEY_CONFIRM", true);

            Android.App.Application.Context.StartActivity(shutdownIntent);

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public void Close(bool restart)
        {
            if (restart)
            {
                var launchIntent = Android.App.Application.Context.PackageManager.GetLaunchIntentForPackage(Android.App.Application.Context.PackageName);

                var relaunchIntent = Android.Content.Intent.MakeRestartActivityTask(launchIntent.Component);

                Android.App.Application.Context.StartActivity(relaunchIntent);

                Java.Lang.Runtime.GetRuntime().Exit(0);
            }
            else
            {
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            }
        }

        public void OpenSystemSettings()
        {
            var intent = new Android.Content.Intent(Android.Provider.Settings.ActionSettings);

            intent.AddFlags(Android.Content.ActivityFlags.NewTask);

            Android.App.Application.Context.StartActivity(intent);
        }
    }
}