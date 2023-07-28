using Android.App;
using Android.Content;

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Receivers
{
    [BroadcastReceiver(Enabled = true, DirectBootAware = true, Exported = true)]
    [IntentFilter(new[] 
    { 
        Intent.ActionBootCompleted, 
        Intent.ActionLockedBootCompleted, 
        "android.intent.action.QUICKBOOT_POWERON" 
    }, Priority = (int)IntentFilterPriority.HighPriority)]
    public class BootBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var startMainActivityIntent = new Intent(context, typeof(MainActivity));

            startMainActivityIntent.AddFlags(ActivityFlags.NewTask);

            context.StartActivity(startMainActivityIntent);
        }
    }
}