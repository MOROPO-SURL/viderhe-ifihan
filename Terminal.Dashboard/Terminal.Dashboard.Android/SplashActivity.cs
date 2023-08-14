using Android.App;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Droid
{
    [Activity(
        Theme = "@style/SplashTheme",
        MainLauncher = true,
        NoHistory = true,
        Icon = "@mipmap/icon")]
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