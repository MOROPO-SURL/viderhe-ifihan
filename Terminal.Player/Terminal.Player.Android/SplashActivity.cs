using Android.App;

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Droid
{
    [Activity(
        Theme = "@style/AppTheme.Splash", 
        MainLauncher = true, 
        NoHistory = true,
        Icon = "@mipmap/ic_launcher")]
    public class SplashActivity : AndroidX.AppCompat.App.AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();

            System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(3)).ContinueWith(_ =>
            {
                StartActivity(new Android.Content.Intent(Application.Context, typeof(MainActivity)));
            });
        }
    }
}